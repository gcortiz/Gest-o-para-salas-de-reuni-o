const newLocal = angular.module("FuncionariosApp", []);
var app = newLocal;

app.controller("FuncionariosController", function ($scope, $http) {
    $http.get('WsAgendaSalaReuniao.asmx/getFuncionarios')
        .then(function (response) {
            $scope.funcionarios = response.data;
        })
});