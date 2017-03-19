(function () {
    'use strict';
    var app = angular.module('AgeRangerApp', ['ngRoute']);
    app.controller('mainController', mainController);

    function mainController($scope)
    {
    }
    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
        .when('/', {
            templateUrl: '../../UI/Home.html',
            controller: 'homeController'
        })
        .when('/Search', {
            templateUrl: '../../UI/Search.html',
            controller: 'searchController'
        })
        .when('/Add', {
            templateUrl: '../../UI/Add.html',
            controller: 'addController'
        })
        .when('/error', {
            templateUrl: '../../UI/Error.html',
        })
        .otherwise({ redirectTo: '/' });
    }]);

})();
