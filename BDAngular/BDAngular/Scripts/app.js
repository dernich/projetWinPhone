angular.module('VisiteApp', ['ngRoute'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
        .when('/', {
            templateUrl: '/partials/Entreprises/VisiteEncodage.html',
            controller: 'EntreprisesCtrl'
        })
        /*.when('/Visite', {
                templateUrl: '/partials/Entreprises/VisiteEncodage.html',
                controller: 'EntreprisesCtrl'
        })*/
        .otherwise({ redirectTo: '/' });
    }])
    .controller('EntreprisesCtrl', function ($scope, $http) {
        $http.get("/api/entreprises").success(function (data, status, headers, config) {
            $scope.entreprises = data;
        }).error(function (data, status, headers, config) {
            alert("something went wrong!!!");
        });
        $http.get("/api/lieux").success(function (data, status, headers, config) {
            $scope.lieux = data;
        }).error(function (data, status, headers, config) {
            alert("something went wrong!!!");
        });
        $http.get("/api/travailleurs").success(function (data, status, headers, config) {
            //$scope.travailleursEntrep = [];
            //$scope.travEntrepSel = [];
            $scope.travailleurs = data;
            /*$http.get("/api/emplois").success(function (data, status, headers, config) {
                for(var i=0; i<data.length;i++) {
                    if (data.numeroEntr == $scope.entrepriseSelected) {
                        $scope.travEntrepSel.push(data.idTrav);
                    }
                }
                $scope.emplois = data;
            }).error(function (data, status, headers, config) {
                console.log("something went wrong!!!");
            });
            for (var i = 0; i < $scope.travailleurs.length; i++) {
                for (var j = 0; j < $scope.travEntrepSel.length; j++) {
                    if ($scope.travailleurs[i].idTrav == $scope.travEntrepSel[j]) {
                        $scope.travailleursEntrep.push($scope.travailleurs[i]);
                    }
                }
            }*/
        }).error(function (data, status, headers, config) {
            alert("something went wrong!!!");
        });
        $http.get("/api/typeExamen").success(function (data, status, headers, config) {
            $scope.typeExamens = data;
        }).error(function (data, status, headers, config) {
            alert("something went wrong!!!");
        });
        $http.get("/api/emplois").success(function (data, status, headers, config) {
            $scope.emplois = data;
        }).error(function (data, status, headers, config) {
            alert("something went wrong!!!");
        });
        $http.get("/api/medecins").success(function (data, status, headers, config) {
            $scope.medecins = data;
        }).error(function (data, status, headers, config) {
            alert("something went wrong!!!");
        });

        $scope.lastVisite = null;
        $scope.visite = {
            codeEmploi: null,
            idLieu: null,
            dateVisite: null
        };

        $scope.emploi = {
            codeEmploi:null,
            idTrav: null,
            numeroEntr: null
        };

        $scope.examen = {
            codeTypeExam: null,
            typeExamenLib: null,
            prix:null,
            duree: null,
            resultat: null,
            idMed: null,
            idVM: null
        };

        $scope.rows = [];

        $scope.addRow = function () {
            $http.get("/api/emplois/" + $scope.visite.codeEmploi).success(function (data, status, headers, config) {
                $scope.soumisYN = data.soumisYN;
                $http.get("/api/typeExamen/" + $scope.examen.codeTypeExam).success(function (data, status, headers, config) {
                    $scope.examen.typeExamenLib = data.typeExamen1;
                    $http.get("/api/lieux/" + $scope.visite.idLieu).success(function (data, status, headers, config) {
                        $scope.supplementLieux = data.supplement;
                    }).error(function (data, status, headers, config) {
                        alert("something went wrong!!!");
                    })
                    //alert($scope.supplementLieux) //PROBLEME DE SCOPE : variable n'a pas la valeur recuperer plus haut
                    if ($scope.soumisYN == 1) {
                        $scope.examen.prix = data.prixSoumis;
                    }
                    else {
                        $scope.examen.prix = data.prixNonSoumis;
                    }
                    //alert($scope.examen.prix);
                    $scope.rows.push($scope.examen);
                    $scope.examen = { codeTypeExam: null, typeExamenLib: null, duree: null, resultat: null, idMed: null, idVM: null };
                }).error(function (data, status, headers, config) {
                    alert("something went wrong!!!");
                });
            }).error(function (data, status, headers, config) {
                alert("something went wrong!!!");
            });
        };

        $scope.removeRow = function (name) {
            var index = -1;
            var comArr = eval($scope.rows);
            for (var i = 0; i < comArr.length; i++) {
                if (comArr[i] === name) {
                    index = i;
                    break;
                }
            }
            if (index === -1) {
                alert("Something gone wrong");
            }
            $scope.rows.splice(index, 1);
        };

        $scope.Save = function () {
            var visiteJSON = angular.toJson($scope.visite);

            $http.post('api/VisiteMedicales', visiteJSON)
                .success(function (data, status, headers, config) {
                    alert("Visite ajoutée");
                    //console.log(data);
                })
                .error(function (data, status, header, config) {
                    alert("Something went wrong!!!");
                    //console.log(data);
            });
            setTimeout(function() { //attendre que la visite creer soit bien ajoutée a la BD
                $http.get("/api/VisiteMedicales").success(function (data, status, headers, config) {
                    for (var i = 0; i < data.length; i++) {
                        $scope.examen.idVM = data[i].idVM;
                    }
                
                    for (var i = 0; i < $scope.rows.length; i++) {
                        delete $scope.rows[i].typeExamenLib;
                        $scope.rows[i].idVM = $scope.examen.idVM;
                        $scope.rows[i].codeTypeExam = parseInt($scope.rows[i].codeTypeExam);
                        $scope.rows[i].idMed = parseInt($scope.rows[i].idMed);
                        var examenJSON = angular.toJson($scope.rows[i]);
                        $http.post('api/ExamenRealises', examenJSON)
                        .success(function (data, status, headers, config) {
                            alert("Examen ajouté");
                            //console.log(data);
                            $scope.rows.splice(i, 1);
                        })
                        .error(function (data, status, header, config) {
                            alert("Something went wrong!!!");
                            //console.log(data);
                        });
                        examenJSON = null;
                    }
                    $scope.rows = [];
                }).error(function (data, status, headers, config) {
                    alert("Something went wrong!!!");
                });
            }, 3000);
        };
    });