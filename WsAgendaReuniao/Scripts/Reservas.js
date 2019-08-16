const newLocal = angular.module("ReservasApp", []);
var app = newLocal;

app.controller("ReservasController", function ($scope, $http) {
    $http.get('WsAgendaSalaReuniao.asmx/getReservas')
        .then(function (response) {
            $scope.reservas = response.data;
        })
});