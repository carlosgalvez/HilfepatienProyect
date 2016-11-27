/// <reference path=""../angular.js"">
 
 
/// <reference path=""Module.js"">
  
//The controller is having 'crudService' dependency.
//This controller makes call to methods from the service 
app.controller('crudController', function ($scope, crudService) {
    
    $scope.IsNewRecord = 1; //The flag for the new record
 
    loadRecords(); 
 
    //Function to load all Employee records
    function loadRecords() {
        var promiseGet = crudService.getPaciente(); //The MEthod Call from service
 
        promiseGet.then(function (pl) { $scope.Paciente = pl.data },
              function (errorPl) {
                  $log.error('failure loading Paciente', errorPl);
              });
    }
     
    //The Save scope method use to define the Employee object.
    //In this method if IsNewRecord is not zero then Update Employee else 
    //Create the Employee information to the server
    $scope.save = function () {
        var Paciente = {
            Id: $scope.Id,
            Nombre: $scope.Nombre,
            Apellido: $scope.Apellido,
            Sexo: $scope.Sexo,
            Edad: $scope.Edad,
            Direccion: $scope.Direccion,
            Telefono: $scope.Telefono

        };
        //If the flag is 1 the it si new record
        if ($scope.IsNewRecord === 1) {
            var promisePost = crudService.post(Paciente);
            promisePost.then(function (pl) {
                $scope.Id = pl.data.Id;
                loadRecords();
            }, function (err) {
                console.log("Err" + err);
            });
        } else { //Else Edit the record
            var promisePut = crudService.put($scope.Id,Paciente);
            promisePut.then(function (pl) {
                $scope.Message = "Updated Successfuly";
                loadRecords();
            }, function (err) {
                console.log("Err" + err);
            });
        }
 
         
             
    };
 
    //Method to Delete
    $scope.delete = function () {
        var promiseDelete = crudService.delete($scope.Id);
        promiseDelete.then(function (pl) {
            $scope.Message = "Deleted Successfuly";
            $scope.Id=0;
            $scope.Nombre="";
            $scope.Apellido="";
            $scope.Sexo="";
            $scope.Edad=0;
            $scope.Direccion = "";
            $scope.Telefono = 0;
            loadRecords();
        }, function (err) {
            console.log("Err" + err);
        });
    }
 
    //Method to Get Single Employee based on EmpNo
    $scope.get = function (Emp) {
        var promiseGetSingle = crudService.get(Emp.Id);
 
        promiseGetSingle.then(function (pl) {
            var res = pl.data;
            $scope.Id = res.Id;
            $scope.Nombre = res.Nombre;
            $scope.Apellido = res.Apellido;
            $scope.Sexo = res.Apellido;
            $scope.Edad = res.Edad;
            $scope.Direccion = res.Direccion;
            $scope.Telefono = res.Telefono;
 
            $scope.IsNewRecord = 0;
        },
                  function (errorPl) {
                      console.log('failure loading Paciente', errorPl);
                  });
    }
    //Clear the Scopr models
    $scope.clear = function () {
        $scope.IsNewRecord = 1;
        $scope.Id = 0;
        $scope.Nombre = "";
        $scope.Apellido = "";
        $scope.Sexo = "";
        $scope.Edad = 0;
        $scope.Direccion = "";
        $scope.Telefono = 0;
    }
});
         