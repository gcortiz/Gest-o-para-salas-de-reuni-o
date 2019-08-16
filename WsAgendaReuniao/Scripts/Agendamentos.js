const newLocal = angular.module("AgendamentosApp", []);
var app = newLocal;

app.controller("AgendamentosController", function ($scope, $http) {

    $http.get('WsAgendaSalaReuniao.asmx/getFuncionarios')
        .then(function (response) {
            $scope.funcionarios = response.data;
        })

    $http.get('WsAgendaSalaReuniao.asmx/getPeriodos')
        .then(function (response) {
            $scope.periodos = response.data;
        })

    $http.get('WsAgendaSalaReuniao.asmx/getReservas')
        .then(function (response) {
            $scope.reservas = response.data;

            for (let i = 0; i < $scope.reservas.length; i++) {
                $scope.reservas[i].DtDaReserva = $scope.reservas[i].DtDaReserva
                $scope.reservas[i].DtReservada
            }
        })

    $http.get('WsAgendaSalaReuniao.asmx/getSalas')
        .then(function (response) {
            $scope.salas = response.data;
        })

    $scope.Agendar = function (funcionario, sala, periodo, reserva) {

        let obj = {
            IdReserva: 0,
            DtDaReserva: reserva.DtReservada,
            DtReservada: reserva.DtReservada,
            IdFuncionario: funcionario.IdFuncionario,
            IdSala: sala.IdSala,
            IdPeriodo: periodo.IdPeriodo,
            Funcionario: funcionario.Nome,
            Sala: sala.NomeSala,
            Periodo: periodo.NomePeriodo
        };
        $scope.reserva = angular.copy(obj);

        var req = new XMLHttpRequest();
        var url = "WsAgendaSalaReuniao.asmx?op=PostReservas";
        req.open("GET", url, true);
        req.setRequestHeader("Content-Type", "application/json");
        req.onreadystatechange = function () {
            if (req.readyState === 4 && req.status === 200) {
                var json = JSON.parse(req.responseText);
                console.log(json.email + ", " + json.password);
            }
        };
        var data = JSON.stringify({ "dtReservada": obj.DtReservada, "idfuncionario": obj.IdFuncionario, "idsala": obj.IdSala, "idperiodo": obj.IdPeriodo });
        req.send(data);



        delete $scope.funcionario;
        delete $scope.sala;
        delete $scope.periodo;
        delete $scope.resersa;
    }

    $scope.ValidaReserva = function (funcionario, sala, periodo, reserva) {

        let obj = {
            IdReserva: 0,
            DtDaReserva: reserva.DtReservada,
            DtReservada: reserva.DtReservada,
            IdFuncionario: funcionario.IdFuncionario,
            IdSala: sala.IdSala,
            IdPeriodo: periodo.IdPeriodo,
            Funcionario: funcionario.Nome,
            Sala: sala.NomeSala,
            Periodo: periodo.NomePeriodo
        };

        if ($scope.reservas.length > 0) {
            $scope.liberada = 'Sala ocupada.';
            for (let i = 0; i < $scope.reservas.length; i++) {
                if ($scope.reservas[i].DtReservada != obj.DtReservada) {

                    if ($scope.reservas[i].IdSala != obj.IdSala) {

                        if ($scope.reservas[i].IdPeriodo != obj.IdPeriodo) {
                            $scope.liberada = 'Sala disponível para agendar.';
                        }
                    }
                }
            }
        }
    }
});