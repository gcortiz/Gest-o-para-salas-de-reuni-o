const newLocal = angular.module("PeriodosApp", []);
var app = newLocal;

app.controller("PeriodosController", function ($scope, $http) {
    $http.get('WsAgendaSalaReuniao.asmx/getPeriodos')
        .then(function (response) {
            $scope.periodos = response.data;
        })
});