app.controller('InserirCandidato', function ($scope, CRUDEasyService) {
    GetTodosHorarios();
    GetTodosPeriodos();
    GetTodosConhecimentos();

    $scope.lstNiveis = [0, 1, 2, 3, 4, 5];
    $scope.lstEstados = ['AC', 'AL', 'AP', 'AM', 'BA', 'CE', 'DF', 'ES', 'GO', 'MA', 'MT', 'MS', 'MG', 'PA', 'PB', 'PR', 'PE', 'PI', 'RJ', 'RN', 'RS', 'RO', 'RR', 'SC', 'SP', 'SE', 'TO'];
    $scope.Candidato = { candidatoConhecimentos: [], candidatoHorarios: [], candidatoPeriodos: [] }

    // adiciona/altera um conhecimento ao candidato
    $scope.addConhecimento = function (Id, nivel) {
        var idx = $scope.Candidato.candidatoConhecimentos.findIndex(x => x.IdConhecimento === Id);
        if (idx > -1) {
            $scope.Candidato.candidatoConhecimentos.splice(idx, 1)
            $scope.Candidato.candidatoConhecimentos.push({ IdConhecimento: Id, Nivel: nivel });
        } else {
            $scope.Candidato.candidatoConhecimentos.push({ IdConhecimento: Id, Nivel: nivel });
        }
    }

    // adiciona/remove um horario ao candidato
    $scope.addHorario = function (Id, IdCand) {
        var idx = $scope.Candidato.candidatoHorarios.findIndex(x => x.IdHorario === Id);
        if (idx > -1) {
            $scope.Candidato.candidatoHorarios.splice(idx, 1);
        } else {
            $scope.Candidato.candidatoHorarios.push({ IdHorario: Id });
        }
    }

    // adiciona/remove um periodo ao candidato
    $scope.addPeriodo = function (Id, IdCand) {
        var idx = $scope.Candidato.candidatoPeriodos.findIndex(x => x.IdPeriodo === Id);
        if (idx > -1) {
            $scope.Candidato.candidatoPeriodos.splice(idx, 1);
        } else {
            $scope.Candidato.candidatoPeriodos.push({ IdPeriodo: Id });
        }
    }

    // retorna todos os horarios (usado apenas para montar front)
    function GetTodosHorarios() {
        var result = CRUDEasyService.getHorarios();
        result.then(function (horarios) {
            $scope.lstHorario = horarios.data;
        });
    }

    // retorna todos os periodos (usado apenas para montar front)
    function GetTodosPeriodos() {
        var result = CRUDEasyService.getPeriodos();
        result.then(function (periodos) {
            $scope.lstPeriodo = periodos.data;
        });
    }

    // retorna todos os conhecimentos (usado apenas para montar front)
    function GetTodosConhecimentos() {
        var result = CRUDEasyService.getConhecimentos();
        result.then(function (conhecimentos) {
            $scope.lstConhecimento = conhecimentos.data;
        });
    }

    // adiciona candidatos
    $scope.adicionarCandidato = function () {
        var res = confirm("Deseja adicionar este candidato?");
        if (res == true) {
            var outros = document.getElementById("outros").value;
            if (outros !== null && outros.trim() !== "")
                $scope.Candidato.candidatoConhecimentos.push({ IdConhecimento: 26, DsOutros: outros });
            if ($scope.Candidato.candidatoPeriodos.length === 0 || $scope.Candidato.candidatoHorarios.length === 0)
                alert('Selecione pelo menos um horario e periodo');
            else {
                var result = CRUDEasyService.AdicionarCandidato($scope.Candidato);
                result.then(function (msg) {
                    alert('Candidato inserido');
                    window.location.reload();
                }, function () {
                    alert('Erro ao adicionar o candidato');
                });
            }
        }
    }
});

app.controller('ListarCandidatos', function ($scope, CRUDEasyService) {
    GetTodosHorarios();
    GetTodosPeriodos();
    GetTodosConhecimentos();
    GetTodosCandidatos();

    $scope.divEditar = false;
    $scope.divVisualizar = false;
    $scope.divCandidatos = true;

    $scope.lstNiveis = [0, 1, 2, 3, 4, 5];
    $scope.lstEstados = ['AC', 'AL', 'AP', 'AM', 'BA', 'CE', 'DF', 'ES', 'GO', 'MA', 'MT', 'MS', 'MG', 'PA', 'PB', 'PR', 'PE', 'PI', 'RJ', 'RN', 'RS', 'RO', 'RR', 'SC', 'SP', 'SE', 'TO'];
    $scope.Candidato = { candidatoConhecimentos: [], candidatoHorarios: [], candidatoPeriodos: [] }
    $scope.candidatoEditar = { candidatoConhecimentos: [], candidatoHorarios: [], candidatoPeriodos: [] }
    $scope.candidatoVisualizar = { candidatoConhecimentos: [], candidatoHorarios: [], candidatoPeriodos: [] }

    // preenche os checkbox de horario e periodo do candidato
    $scope.checaExiste = function (Id, Tipo, Div) {
        if (Div === 'Editar') {
            if (Tipo === 'Periodo') {
                var idx = $scope.candidatoEditar.candidatoPeriodos.findIndex(x => x.IdPeriodo === Id);
            } else if (Tipo === 'Horario') {
                var idx = $scope.candidatoEditar.candidatoHorarios.findIndex(x => x.IdHorario === Id);
            }
        } else if (Div === 'Visualizar') {
            if (Tipo === 'Periodo') {
                var idx = $scope.candidatoVisualizar.candidatoPeriodos.findIndex(x => x.IdPeriodo === Id);
            } else if (Tipo === 'Horario') {
                var idx = $scope.candidatoVisualizar.candidatoHorarios.findIndex(x => x.IdHorario === Id);
            }
        }
        return idx;
    }

    // adiciona/altera um conhecimento ao candidato
    $scope.addConhecimento = function (Id, nivel) {
        var idx = $scope.candidatoEditar.candidatoConhecimentos.findIndex(x => x.IdConhecimento === Id);
        $scope.candidatoEditar.candidatoConhecimentos[idx].Nivel = nivel;
    }

    // adiciona/remove um horario ao candidato
    $scope.addHorario = function (Id, IdCand) {
        var idx = $scope.candidatoEditar.candidatoHorarios.findIndex(x => x.IdHorario === Id);
        if (idx > -1) {
            $scope.candidatoEditar.candidatoHorarios.splice(idx, 1);
        } else {
            $scope.candidatoEditar.candidatoHorarios.push({ IdHorario: Id, IdCandidato: IdCand });
        }
    }

    // adiciona/remove um periodo ao candidato
    $scope.addPeriodo = function (Id, IdCand) {
        var idx = $scope.candidatoEditar.candidatoPeriodos.findIndex(x => x.IdPeriodo === Id);
        if (idx > -1) {
            $scope.candidatoEditar.candidatoPeriodos.splice(idx, 1);
        } else {
            $scope.candidatoEditar.candidatoPeriodos.push({ IdPeriodo: Id, IdCandidato: IdCand });
        }
    }

    // retorna todos os horarios (usado apenas para montar front)
    function GetTodosHorarios() {
        var result = CRUDEasyService.getHorarios();
        result.then(function (horarios) {
            $scope.lstHorario = horarios.data;
        });
    }

    // retorna todos os periodos (usado apenas para montar front)
    function GetTodosPeriodos() {
        var result = CRUDEasyService.getPeriodos();
        result.then(function (periodos) {
            $scope.lstPeriodo = periodos.data;
        });
    }

    // retorna todos os conhecimentos (usado apenas para montar front)
    function GetTodosConhecimentos() {
        var result = CRUDEasyService.getConhecimentos();
        result.then(function (conhecimentos) {
            $scope.lstConhecimento = conhecimentos.data;
        });
    }

    // retorna lista de candidatos
    function GetTodosCandidatos() {
        var result = CRUDEasyService.getCandidatos();
        result.then(function (candidato) {
            $scope.lstCandidato = candidato.data;
        });
    }

    // retorna os dados do candidato para editar
    $scope.editarCandidato = function (candidato) {
        var result = CRUDEasyService.getCandidato(candidato.IdCandidato);
        result.then(function (_candidato) {
            $scope.candidatoEditar = _candidato.data;
            $scope.divCandidatos = false;
            $scope.divEditar = true;
            $scope.divVisualizar = false;
        }, function () {
            alert('Erro ao tentar obter os registros do candidato');
        });
    }

    // retorna candidato pelo id
    $scope.visualizarCandidato = function (candidato) {
        var result = CRUDEasyService.getCandidato(candidato.IdCandidato);
        result.then(function (_candidato) {
            $scope.candidatoVisualizar = _candidato.data;
            $scope.divCandidatos = false;
            $scope.divEditar = false;
            $scope.divVisualizar = true;
        }, function () {
            alert('Erro ao tentar obter os registros do candidato');
        })
    }

    // atualiza os dados do candidato
    $scope.atualizarCandidato = function () {
        var res = confirm("Deseja alterar os dados do candidato?");
        if (res == true) {
            if ($scope.candidatoEditar.candidatoPeriodos.length === 0 || $scope.candidatoEditar.candidatoHorarios.length === 0)
                alert('Selecione pelo menos um horario e periodo');
            else {
                var result = CRUDEasyService.AtualizarCandidato($scope.candidatoEditar);
                result.then(function (msg) {
                    alert('Candidato alterado');
                    $scope.divEditar = false;
                    $scope.divCandidatos = true;
                    GetTodosCandidatos();
                }, function () {
                    alert('Erro ao tentar atualizar os registros do candidato');
                });
            }
        }
    }

    // deleta candidato
    $scope.deletarCandidato = function (candidato) {
        var res = confirm("Deseja deletar os dados do candidato?");
        if (res == true) {
            var result = CRUDEasyService.DeletarCandidato(candidato.IdCandidato);
            result.then(function (msg) {
                alert('Candidato deletado');
                GetTodosCandidatos();
            }, function () {
                alert('Erro ao tentar excluir o candidato');
            });
        }
    }

    //atualiza a pagina
    $scope.cancelar = function () {
        window.location.reload();
    }
});