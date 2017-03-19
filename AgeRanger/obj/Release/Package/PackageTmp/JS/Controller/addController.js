(function () {
    'use strict';
    var app = angular.module('AgeRangerApp');
    app.controller('addController', function ($scope, $http, $location) {
        
        $scope.addPeople = function()
        {
           
            $http({
                method: 'Post',
                url: '/people',
                data: $scope.people
            }).then(function successCallback(response) {
                alert("Person Added Successfully.")
                $location.path("#/Add")

            }, function errorCallback(response) {
                $location.path("#/Error")
            });
        }
        $scope.people = 
            {
                firstName: "",
                lastName: "",
                age: 0
            }
    });



})();
