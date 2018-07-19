var app = angular.module("myApp", []);
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
    }

});

