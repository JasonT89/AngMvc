(function () {


    var appModule = angular.module("peopleViewer", []);

    appModule.controller("MainControllerNg", function ($scope, $http, peopleService) {

        $scope.message = "Angular";

        var onComplete = function (response) {
            $scope.people2 = response.data;
        };

        var onError = function (reason) {
            $scope.error = reason.message;
        };

        var getPeople = function () {
            peopleService.getPeople().success(function (p) {
                $scope.people = p;
                console.log($scope.people);
            }).error(function (error) {
                $scope.status = 'Unable to load' + error.message;
                console.log($scope.status);
            });
        };

        $http.get('/Home/getPerson').then(onComplete, onError);

        getPeople();
    });

    appModule.factory('peopleService', ['$http', function ($http) {

        var peopleService = {};

        peopleService.getPeople = function () {
            return $http.get('/Home/GetPerson');
        };
        return people;
    }
    ]);


    appModule.controller('MainControllerNg', MainControllerNg);
}());