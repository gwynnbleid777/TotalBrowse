(function () {
    'use strict';

    var app = angular.module('app', ['ngResource', 'ngRoute']);

    app.config(['$routeProvider', function ($routeProvider) {

        $routeProvider.when('/welcome', {
            templateUrl: 'app/welcome.html',
            controller: 'welcomeCtrl',
            caseInsensitiveMatch: true
        });
        $routeProvider.when('/driveManager/', {
            templateUrl: 'app/drives/drives.html',
            controller: 'driveCtrl',
            caseInsensitiveMatch: true
        });
        $routeProvider.when('/driveManager/:dName', {
            templateUrl: 'app/directory/directory.html',
            controller: 'directoryCtrl',
            caseInsensitiveMatch: true
        });
        $routeProvider.when('/driveManager/:dName/:dFolder', {
            templateUrl: 'app/directory/folder.html',
            controller: 'directoryCtrl',
            caseInsensitiveMatch: true
        });

        $routeProvider.otherwise({
            redirectTo: '/welcome'
        });
    }]);

    app.run([function () {
    }]);
})();