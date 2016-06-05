(function () {
    angular.module('moneyChangeApp', [])


    .controller('index', ['$scope', '$injector', function ($scope, $injector) {
        var $http = $injector.get('$http');
        $scope.moneyChangeSearches = [{ CurrencyValue: 0, Quantity: 0 }];
        $scope.$on('$viewContentLoaded', function () {
            
            $http.post("/Home/GetAllSearches")
                 .success(function (responseData) {
                     $scope.error = "";
                     $scope.moneyChange = "";
                     $scope.moneyChangeSearches.push(responseData);
                 })
                 .error(function (responseData) {
                     $scope.error = "Solo se aceptan numeros y dos decimales como maximo. Favor de intentar nuevamente.";
                     $scope.moneyChange = "";
                 });

        });
        var init = function () {
            $http.post("/Home/GetAllSearches")
                 .success(function (responseData) {
                     $scope.error = "";
                     $scope.moneyChange = "";
                     $scope.moneyChangeSearches.push(responseData);
                 })
                 .error(function (responseData) {
                     $scope.error = "Solo se aceptan numeros y dos decimales como maximo. Favor de intentar nuevamente.";
                     $scope.moneyChange = "";
                 });
        };
        // and fire it after definition
        init();
        $scope.submit = function () {
            if ($scope.number) {
               
                
                
                $http.post("/Home/ConvertChange", JSON.stringify({ number: $scope.number }) )
                  .success(function (responseData) {
                      $scope.error = "";
                      $scope.moneyChange = responseData;
                      $scope.moneyChangeSearches.push(responseData);
                    })
                  .error(function (responseData) {
                      $scope.error = "Solo se aceptan numeros y dos decimales como maximo. Favor de intentar nuevamente.";
                      $scope.moneyChange = "";
                    });


            }
        };
    }]);
}).call(this);