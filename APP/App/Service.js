app.service("CRUDEasyService", function ($http) {
	// obtem todos os horarios
	this.getHorarios = function () {
		var response = $http({
			method: 'get',
			url: 'http://localhost:23904/Horarios/Get'
		});
		return response;
	};

	// obtem todos os periodos
	this.getPeriodos = function () {
		var response = $http({
			method: 'get',
			url: 'http://localhost:23904/Periodos/Get'
		});
		return response;
	};

	// obtem todos os conhecimentos
	this.getConhecimentos = function () {
		var response = $http({
			method: 'get',
			url: 'http://localhost:23904/Conhecimentos/Get'
		});
		return response;
	};

	// obtem todos os candidatos
	this.getCandidatos = function () {
		var response = $http({
			method: 'get',
			url: 'http://localhost:23904/Candidato/Get'
		});
		return response;
	};

	// obtem candidato por id
	this.getCandidato = function (candId) {
		var response = $http({
			method: 'get',
			url: 'http://localhost:23904/Candidato/Get/' + candId
		});
		return response;
	}

	// Atualiza candidato
	this.AtualizarCandidato = function (candidato) {
		var response = $http({
			url: 'http://localhost:23904/Candidato/Update',
			method: 'put',
			data: JSON.stringify(candidato),
			dataType: 'json'
		});
		return response;
	}

	// Adiciona candidato
	this.AdicionarCandidato = function (candidato) {
		var response = $http({
			url: 'http://localhost:23904/Candidato/Insert',
			method: 'post',
			data: JSON.stringify(candidato),
			dataType: 'json'
		});
		return response;
	}

	//Deleta candidato
	this.DeletarCandidato = function (candId) {
		var response = $http({
			method: 'delete',
			url: 'http://localhost:23904/Candidato/Delete/' + candId
		});
		return response;
	}
});