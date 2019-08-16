const newLocal = angular.module("SalasApp", []);
var app = newLocal;

app.controller("SalasController", function ($scope, $http) {
    $http.get('WsAgendaSalaReuniao.asmx/getSalas')
        .then(function (response) {
            $scope.salas = response.data;
        })
});