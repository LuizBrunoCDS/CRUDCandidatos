var app = angular.module("App", ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'Views/home.html'
        })
        .when('/cadastrar', {
            templateUrl: 'Views/cadastrar.html',
            controller: 'InserirCandidato'
        })
        .when('/candidatos', {
            templateUrl: 'Views/candidatos.html',
            controller: 'ListarCandidatos'
        })
        .otherwise({ redirectTo: '/' });
}]);