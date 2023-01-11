hasB4B.controller('layoutController', function ($scope, $http, $location, $window) {

    $scope.FinanceList = [];

    $scope.getFinanceList = function () {
        $http(
            {
                method: 'POST',
                url: '/Finance/GetFinanceList',
                data: {}
            }).then(function (response) {
                if (response.data != null) {
                    $scope.FinanceList = response.data;
                }
            });
    }

    $(document).ready(function () {
        $scope.getFinanceList();
    });

});