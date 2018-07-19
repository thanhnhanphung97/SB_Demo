var app = angular.module("myApp", []);

app.filter('HtmlToPlainText', function () {
    return function (text) {
        return text ? String(text).replace(/<[^>]+>/gm, '') : '';
    };
}
);

app.service('myService', function ($http) {
    this.getIntroduces = function () {
        return $http.get("HomeAdmin/GetAllIntro");
    };

    //Add introduce
    this.AddIntro = function (introduce) {
        var response = $http({
            method: "post",
            url: "HomeAdmin/AddIntroduce",
            data: JSON.stringify(introduce),
            dataType: "json"
        });
        return response;
    }

    // get introduce By Id
    this.getIntro = function (introduceID) {
        var response = $http({
            method: "POST",
            url: "HomeAdmin/getIntroduceByNo",
            params: {
                id: JSON.stringify(introduceID)
            }
        });
        return response;
    }

    // Update introduce
    this.updateIntro = function (introduce) {
        var response = $http({
            method: "post",
            url: "HomeAdmin/UpdateIntroduce",
            data: JSON.stringify(introduce),
            dataType: "json"
        });
        return response;
    }

    //Delete introduce
    this.DeleteIntro = function (introduceID) {
        var response = $http({
            method: "post",
            url: "HomeAdmin/DeleteIntroduce",
            params: {
                Id: JSON.stringify(introduceID)
            }
        })
        return response;
    }

    this.getNews = function () {
        return $http.get("HomeAdmin/GetAllN");
    };

    //Add introduce
    this.AddN = function (New) {
        var response = $http({
            method: "post",
            url: "HomeAdmin/AddNew",
            data: JSON.stringify(New),
            dataType: "json"
        });
        return response;
    }

    // get introduce By Id
    this.getN = function (NewID) {
        var response = $http({
            method: "POST",
            url: "HomeAdmin/getNewByNo",
            params: {
                id: JSON.stringify(NewID)
            }
        });
        return response;
    }

    // Update introduce
    this.updateN = function (New) {
        var response = $http({
            method: "post",
            url: "HomeAdmin/UpdateNew",
            data: JSON.stringify(New),
            dataType: "json"
        });
        return response;
    }

    //Delete introduce
    this.DeleteN = function (NewID) {
        var response = $http({
            method: "post",
            url: "HomeAdmin/DeleteNew",
            params: {
                Id: JSON.stringify(NewID)
            }
        })
        return response;
    }
})

app.controller('myIntroCntrl', function ($scope, myService) {
    $scope.divIntroduce = false;
    GetAllIntroduce();
    function GetAllIntroduce() {
        debugger;
        var getData = myService.getIntroduces();
        debugger;
        getData.then(function (intro) {
            $scope.introduces = intro.data;
        }, function () {
            toastr.error("Error!", "Notification");
        });
    }

    $scope.editIntroduce = function (introduce) {
        debugger;
        document.getElementById('imageIntro').style.display = "block";
        var getdata = myService.getIntro(introduce.Id);
        getdata.then(function (intro) {
            $scope.introduce = intro.data;
            $scope.idIntro = introduce.Id;
            $scope.nameIntro = introduce.Name;
            document.getElementById('imageIntro').src = introduce.Img;
            $scope.imgIntro = introduce.Img;
            $scope.dataIntro = introduce.Data;
            $scope.describeIntro = introduce.Describe;
            $('#textFroalaIntro').froalaEditor('html.set', introduce.Describe);
            $scope.colorIntro = introduce.Color;
            $scope.Action = "Edit";
        }, function () {
            //document.getElementById('imageIntro').src = $scope.Img;
            //$('#textOfFroala').froalaEditor('html.set', $scope.Describe);
        });
        
    }

    $scope.AddUpdateIntro = function ()
    {
        //debugger;
        var html = $('#textFroalaIntro').froalaEditor('html.get');
        $scope.describeIntro = html;
        if ($scope.colorIntro == "") $scope.colorIntro = '#000000';
        var Introduce = {
            Name: $scope.nameIntro,
            Img: $scope.imgIntro,
            Data: $scope.dataIntro,
            Describe: $scope.describeIntro,
            Color: $scope.colorIntro
        };
        var getAction = $scope.Action;
        if (getAction == "Edit")
        {
            Introduce.Id = $scope.idIntro;
            var getData = myService.updateIntro(Introduce);
            getData.then(function (msg) {
                GetAllIntroduce();
                toastr.success("Success!", "Notification");
            }, function () {
                toastr.error("Error!", "Notification");
            });
        }
        else
        {
            var getData = myService.AddIntro(Introduce);
            getData.then(function (msg) {
                GetAllIntroduce();
                toastr.success("Success!", "Notification");
            }, function () {
                toastr.error("Error!", "Notification");
            });
        }
    }
    $scope.deleteIntroduce = function (introduce) {
        if (confirm("Are you sure?")) {
            var getData = myService.DeleteIntro(introduce.Id);
            getData.then(function (msg) {
                GetAllIntroduce();
                toastr.warning("Success!", "Notification");
            }, function () {
                toastr.error("Error!", "Notification");
            });
        }
    };

    $scope.TextUrlImage = function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $scope.imgIntro = url;
            $("#txtImageIntro").val(url);
            document.getElementById("imageIntro").src = url;
            document.getElementById("imageIntro").style.backgroundColor = 'lightgrey';
            document.getElementById("imageIntro").style.display = "block";
            document.getElementById("imageIntro").hidden = false;
            };
        finder.popup();
    }

    $scope.AddIntroduceDiv = function () {
        ClearFields();
        $scope.Action = "Create";
    }

    function ClearFields() {
        $scope.idIntro = null;
        $scope.nameIntro = null;
        $scope.imgIntro = null;
        $scope.dataIntro = null;
        document.getElementById('imageIntro').src = "";
        document.getElementById('imageIntro').style.display = "none";
        $('#textFroalaIntro').froalaEditor('html.set', "");
        $scope.describeIntro = null;
        $scope.colorIntro = null;

        $scope.idN = null;
        $scope.nameN = null;
        $scope.imgN = null;
        document.getElementById('imageN').src = "";
        document.getElementById('imageN').style.display = "none";
        $('#textFroalaN').froalaEditor('html.set', "");
        $scope.describeN = null;
    }

    GetAllNew();
    function GetAllNew() {
        debugger;
        var getData = myService.getNews();
        debugger;
        getData.then(function (N) {
            $scope.News = N.data;
        }, function () {
            toastr.error("Error!", "Notification");
        });
    }

    $scope.editNew = function (New) {
        debugger;
        document.getElementById('imageN').style.display = "block";
        var getdata = myService.getN(New.Id);
        getdata.then(function (N) {
            $scope.New = N.data;
            $scope.idN = New.Id;
            $scope.nameN = New.Name;
            document.getElementById('imageN').src = New.Img;
            $scope.imgN = New.Img;
            $scope.describeN = New.Describe;
            $('#textFroalaN').froalaEditor('html.set', New.Describe);
            $scope.Action = "Edit";
        }, function () {
            //document.getElementById('imageIntro').src = $scope.Img;
            //$('#textOfFroala').froalaEditor('html.set', $scope.Describe);
        });

    }

    $scope.AddUpdateN = function () {
        //debugger;
        var html = $('#textFroalaN').froalaEditor('html.get');
        $scope.describeN = html;
        if ($scope.colorN == "") $scope.colorN = '#000000';
        var New = {
            Name: $scope.nameN,
            Img: $scope.imgN,
            Describe: $scope.describeN,
        };
        var getAction = $scope.Action;
        if (getAction == "Edit") {
            New.Id = $scope.idN;
            var getData = myService.updateN(New);
            getData.then(function (msg) {
                GetAllNew();
                toastr.success("Success!", "Notification");
            }, function () {
                toastr.error("Error!", "Notification");
            });
        }
        else {
            var getData = myService.AddN(New);
            getData.then(function (msg) {
                GetAllNew();
                toastr.success("Success!", "Notification");
            }, function () {
                toastr.error("Error!", "Notification");
            });
        }
    }
    $scope.deleteNew = function (New) {
        if (confirm("Are you sure?")) {
            var getData = myService.DeleteN(New.Id);
            getData.then(function (msg) {
                GetAllNew();
                toastr.warning("Success!", "Notification");
            }, function () {
                toastr.error("Error!", "Notification");
            });
        }
    };

    $scope.TextUrlImageN = function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $scope.imgN = url;
            $("#txtImageN").val(url);
            document.getElementById("imageN").src = url;
            document.getElementById("imageN").style.backgroundColor = 'lightgrey';
            document.getElementById("imageN").style.display = "block";
            document.getElementById("imageN").hidden = false;
        };
        finder.popup();
    }

    $scope.AddNewDiv = function () {
        ClearFields();
        $scope.Action = "Create";
    }
});

