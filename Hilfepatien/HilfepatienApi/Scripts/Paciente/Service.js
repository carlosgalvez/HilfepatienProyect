// <reference path=""../angular.js""> 
//<reference path=""Module.js"">
 
 
app.service('crudService', function ($http) {
 
     
    //Create new record
    this.post = function (Paciente) {
        var request = $http({
            method: "post",
            url: "/POST api/paciente",
            data:  Paciente
        });
        return request;
    }
    //Get Single Records
    this.get = function (Id) {
        return $http.get("/api/paciente/" + Id);
    }
 
    //Get All Employees
    this.getEmployees = function () {
        return $http.get("/api/paciente");
    }
 
 
    //Update the Record
    this.put = function (Id, Paciente) {
        var request = $http({
            method: "put",
            url: "/api/paciente/" + Id,
            data: Paciente
        });
        return request;
    }
    //Delete the Record
    this.delete = function (Id) {
        var request = $http({
        method: "delete",
        url: "/api/paciente/" + Id
        });
        return request;
    }
});
 