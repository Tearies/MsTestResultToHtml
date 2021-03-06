var angular = require('angular');

var application = angular.module('NUnitReport', [
    require('angular-route'),
    require('angular-animate'),
    require('angular-ui-bootstrap'),
    require('angular-tree-control'),
    'angular.backtop'
]);

application.factory('Report', require('./services/ReportFactory'));
application.service('ReportAdapter', require('./services/ReportAdapter'));
application.service('StateStorage', require('./services/StateStorage'));
application.controller('DashboardController', require('./controllers/DashboardController'));

application.config(['$routeProvider',
    function($routeProvider) {
        $routeProvider.when('/testcase/:TestName', {
            templateUrl: 'views/DashboardView.html',
            controller: 'DashboardController'
        }).when('/testcase', {
            templateUrl: 'views/DashboardView.html',
            controller: 'DashboardController'
        }).otherwise({
            redirectTo: '/testcase'
        });
    }
]);

require('angular-backtop');