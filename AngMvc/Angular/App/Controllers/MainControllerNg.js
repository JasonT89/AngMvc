(function ()
{


    var appModule = angular.module("peopleViewer", []);

    appModule.controller("MainControllerNg", function ($scope, $http)
    {

        $scope.message = "Angular";

        function init()
        {
            $http.get("/Home/SearchPeople").then(onComplete);
        }

        var onComplete = function (response)
        {
            $scope.people = response.data;
        };

        var onError = function (reason)
        {
            $scope.error = reason.error;
        };

        var picturesGet = $http.get("/Home/GetPictures");

        picturesGet.then(function (response)
        {
            $scope.pictures = response.data;
        });

        $scope.search = function (name, searchCriteria)
        {
            //Doesn't work! A "/" doesnt make a difference // Now Works because ?
            $http.get("/Home/SearchPeople/" + name + "?" + searchCriteria)
                .then(onComplete);

            //Works
            //$http.get("/Home/SearchPeople/" + name)
            //    .then(onComplete);
        };

        $scope.edit = function (PersonId)
        {
            $http.get("{Home/Edit/" + PersonId);
        };

        Init();
    });

    appModule.controller('MainControllerNg', [MainControllerNg]);
}());


      