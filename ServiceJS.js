//angular.module("myApp", []).service("myService", function ($http) {

//    //get All Eployee
//    this.getIntroduces = function () {
//        debugger;
//        return $http.get("HomeAdmin/GetAllIntro");
//    };

//    // get Employee By Id
//    this.getIntro = function (introId) {
//        var response = $http({
//            method: "post",
//            url: "HomeAdmin/getIntroducesByNo",
//            params: {
//                id: JSON.stringify(introId)
//            }
//        });
//        return response;
//    }

//    // Update Employee
//    this.updateIntro = function (intro) {
//        var response = $http({
//            method: "post",
//            url: "HomeAdmin/UpdateIntroduce",
//            data: JSON.stringify(intro),
//            dataType: "json"
//        });
//        return response;
//    }

//    // Add Employee
//    this.AddIntro = function (intro) {
//        var response = $http({
//            method: "post",
//            url: "HomeAdmin/AddIntroduce",
//            data: JSON.stringify(intro),
//            dataType: "json"
//        });
//        return response;
//    }

//    //Delete Employee
//    this.DeleteIntro = function (introId) {
//        var response = $http({
//            method: "post",
//            url: "HomeAdmin/DeleteIntroduce",
//            params: {
//                employeeId: JSON.stringify(introId)
//            }
//        });
//        return response;
//    }
//});