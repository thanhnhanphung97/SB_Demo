//angular.module("myApp", []).controller("myIntroCntrl", function ($scope, myService) {
//    $scope.divIntroduce = false;
//    GetAllIntroduce();
//    //To Get All Records 
//    function GetAllIntroduce() {
//        debugger;
//        var getData = myService.getIntroduces();
//        debugger;
//        getData.then(function (intro) {
//            $scope.introduces = intro.data;
//        }, function () {
//            alert('Error in getting records');
//        });
//    }

//    $scope.editIntroduce = function (introduce) {
//        debugger;
//        var getData = myService.getIntro(introduce.Id);
//        getData.then(function (intro) {
//            $scope.introduce = intro.data;
//            $scope.Name = introduce.Name;
//            $scope.Img = introduce.Img;
//            $scope.Data = introduce.Data;
//            $scope.Describe = introduce.Describe;
//            $scope.Color = introduce.Color;
//            $scope.Action = "Update";
//            $scope.divIntroduce = true;
//        },
//            function () {
//                alert('Error in getting records');
//            });
//    }

//    $scope.AddUpdateIntro = function () {
//        debugger;
//        var Introduce = {
//            Name: $scope.Name,
//            Img: $scope.Img,
//            Data: $scope.Data,
//            Describe: $scope.Describe,
//            Color: $scope.Color
//        };
//        var getAction = $scope.Action;

//        if (getAction == "Update") {
//            Introduce.Id = $scope.introId;
//            var getData = myService.updateIntro(Introduce);
//            getData.then(function (msg) {
//                GetAllIntro();
//                alert(msg.data);
//                $scope.divIntroduce = false;
//            }, function () {
//                alert('Error in updating record');
//            });
//        } else {
//            var getData = myService.AddIntro(Introduce);
//            getData.then(function (msg) {
//                GetAllIntro();
//                alert(msg.data);
//                $scope.divIntroduce = false;
//            }, function () {
//                alert('Error in adding record');
//            });
//        }
//    }

//    $scope.AddIntroduceDiv = function () {
//        ClearFields();
//        $scope.Action = "Add";
//        $scope.divIntroduce = true;
//    }

//    $scope.deleteIntroduce = function (intro) {
//        var getData = myService.DeleteIntro(intro.Id);
//        getData.then(function (msg) {
//            GetAllIntro();
//            alert('Introduce Deleted');
//        }, function () {
//            alert('Error in Deleting Record');
//        });
//    }

//    function ClearFields() {
//        $scope.Name = "";
//        $scope.Img = "";
//        $scope.Data = "";
//        $scope.Describe = "";
//        $scope.Color = "";
//    }
//});