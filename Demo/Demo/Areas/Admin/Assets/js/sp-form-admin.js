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
    //
    ////////////////// Partners/////////////////////
    //
    //
    //
    this.getPartners = function () {
        return $http.get("HomeAdmin/GetAllPartners");
    };

    //Add partners
    this.AddPart = function (partner) {
        var response = $http({
            method: "post",
            url: "HomeAdmin/AddPartner",
            data: JSON.stringify(partner),
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
    // get partner By Id
    this.getPart = function (partnerId) {
        var response = $http({
            method: "POST",
            url: "HomeAdmin/getPartnerById",
            params: {
                id: JSON.stringify(partnerId)
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
    // Update partner
    this.updatePart = function (partner) {
        var response = $http({
            method: "post",
            url: "HomeAdmin/UpdatePartner",
            data: JSON.stringify(partner),
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
    //Delete partner
    this.DeletePart = function (partnerId) {
        var response = $http({
            method: "post",
            url: "HomeAdmin/DeletePartner",
            params: {
                Id: JSON.stringify(partnerId)
            }
        })
        return response;
    }
})

app.controller('myIntroCntrl', function ($scope, myService) {
    GetAllIntroduce();
    GetAllPartners();

    function GetAllIntroduce() {
        //debugger;
        var getData = myService.getIntroduces();
        //debugger;
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

    };

    $scope.AddUpdateIntro = function () {
        //debugger;
        var html = $('#textFroalaIntro').froalaEditor('html.get');
        $scope.describeIntro = html;
        if ($scope.colorIntro == "" || $scope.colorIntro == null) $scope.colorIntro = '#000000';
        var Introduce = {
            Name: $scope.nameIntro,
            Img: $scope.imgIntro,
            Data: $scope.dataIntro,
            Describe: $scope.describeIntro,
            Color: $scope.colorIntro
        };
        debugger;
        var getAction = $scope.Action;
        if (getAction == "Edit") {
            Introduce.Id = $scope.idIntro;
            var getData = myService.updateIntro(Introduce);
            getData.then(function (msg) {
                GetAllIntroduce();
                toastr.success("Success!", "Notification");
            }, function () {
                toastr.error("Error!", "Notification");
            });
        }
        else {
            var getData = myService.AddIntro(Introduce);
            getData.then(function (msg) {
                GetAllIntroduce();
                toastr.success("Success!", "Notification");
            }, function () {
                toastr.error("Error!", "Notification");
            });
        }
    };

    $scope.deleteIntroduce = function (introduce) {
        if (confirm("Are you sure?")) {
            var getData = myService.DeleteIntro(introduce.Id);
            getData.then(function (msg) {
                GetAllIntroduce();
                toastr.success("Success!", "Notification");
            }, function () {
                toastr.error("Error!", "Notification");
            });
        }
    };

    $scope.TextUrlImage = function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $scope.imgIntro = url;
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
        
        //
        //partners
        //
        $scope.idPart = null;
        $scope.namePart = null;
        $scope.imgPart = null;
        document.getElementById('imagePart').src = "";
        document.getElementById('imagePart').style.display = "none";
        $('#textFroalaPart').froalaEditor('html.set', "");
        $scope.describePart = null;
        $scope.backgroundPart = null;
        document.getElementById('backgroundPart').src = "";
        document.getElementById('backgroundPart').style.display = "none";
        ///
        //
        //
        
        
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

    //
    //
    //
    //////////////Partner/////////////////////
    //
    //
    //
    function GetAllPartners() {
        //debugger;
        var getData = myService.getPartners();
        //debugger;
        getData.then(function (part) {
            $scope.partners = part.data;
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
        };
        
    $scope.editPartner = function (partner) {
        debugger;
        document.getElementById('imagePart').style.display = "block";
        document.getElementById('backgroundPart').style.display = "block";
        var getdata = myService.getIntro(partner.Id);
        getdata.then(function (part) {
            $scope.partner = part.data;
            $scope.idPart = partner.Id;
            $scope.namePart = partner.Name;
            document.getElementById('imagePart').src = partner.Img;
            $scope.imgPart = partner.Img;
            $scope.describePart = partner.Describe;
            $('#textFroalaPart').froalaEditor('html.set', partner.Describe);
            document.getElementById('backgroundPart').src = partner.Background;
            $scope.backgroundPart = partner.Background;
            $scope.Action = "Edit";
        }, function () {
            //document.getElementById('imageIntro').src = $scope.Img;
            //$('#textOfFroala').froalaEditor('html.set', $scope.Describe);
        });
    }

    $scope.AddUpdatePart = function () {
        //debugger;
        var html = $('#textFroalaPart').froalaEditor('html.get');
        $scope.describePart = html;
        var Partner = {
            Name: $scope.namePart,
            Img: $scope.imgPart,
            Describe: $scope.describePart,
            Background: $scope.backgroundPart
        };
        var getAction = $scope.Action;
        if (getAction == "Edit") {
            Partner.Id = $scope.idPart;
            var getData = myService.updatePart(Partner);
            //debugger;
            getData.then(function (msg) {
                GetAllPartners();
                toastr.success("Success!", "Notification");
            }, function () {
                toastr.error("Error!", "Notification");
            });
        }
        else {
            var getData = myService.AddPart(Partner);
            getData.then(function (msg) {
                GetAllPartners();
                toastr.success("Success!", "Notification");
            }, function () {
                toastr.error("Error!", "Notification");
            });
        }
    }

    $scope.deletePartner = function (Partner) {
        if (confirm("Are you sure?")) {
            var getData = myService.DeletePart(Partner.Id);
            getData.then(function (msg) {
                GetAllPartners();
                toastr.success("Success!", "Notification");
            }, function () {
                toastr.error("Error!", "Notification");
            });
        }
    };

    $scope.TextUrlImagePart = function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $scope.imgPart = url;
            document.getElementById("imagePart").src = url;
            document.getElementById("imagePart").style.backgroundColor = 'lightgrey';
            document.getElementById("imagePart").style.display = "block";
            document.getElementById("imagePart").hidden = false;
        };
        finder.popup();
    }

    $scope.TextUrlBackgroundPart = function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $scope.backgroundPart = url;
            document.getElementById("backgroundPart").src = url;
            document.getElementById("backgroundPart").style.backgroundColor = 'lightgrey';
            document.getElementById("backgroundPart").style.display = "block";
            document.getElementById("backgroundPart").hidden = false;
        };
        finder.popup();
    }

    $scope.AddPartnerDiv = function () {
        ClearFields();
        $scope.Action = "Create";
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
                toastr.success("Success!", "Notification");
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

