﻿angular.module("umbraco").controller("Analytics.ViewController",
    function ($scope, $routeParams, settingsResource, assetsService) {

        //Currently loading /umbraco/general.html
        //Need it to look at /App_Plugins/
        //$scope.dateFilter = settingsResource.getDateFilter();
        //$scope.$watch('dateFilter', function () {
        //    console.log("parent watch");
        //});
        
        var viewName = $routeParams.id;
        viewName = viewName.replace('%20', '-').replace(' ', '-');

        $scope.templatePartialURL = '../App_Plugins/Analytics/backoffice/analyticsTree/partials/' + viewName + '.html';
        $scope.sectionName = $routeParams.id;

        //load the seperat css for the editor to avoid it blocking our js loading
        assetsService.loadCss("/App_Plugins/Analytics/backOffice/AnalyticsTree/icons/css/font-awesome.css");
    });