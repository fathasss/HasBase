hasB4B.controller('layoutController', function ($scope, $http, $location, $window) {

    $scope.CurrentCustomer = function () {
        $http(
            {
                method: 'POST',
                url: '/Home/CurrentCustomerData',
                data: { }
            }).then(function (response) {
                if (response.data.Username != "Anonymous") {
                    $scope.CurrentCustomer = response.data;
                }
            });
    }

    $scope.customer = {
        Username: '',
        Password: '',
        EMail: '',
        Phone: '',
        City: '',
        Town: ''
    }

    $scope.signUp = function () {
        $('#signUp').modal('show');
        $('#CustomerName').val() = '';
        $('#CustomerPassword').val() = '';
        $('#CustomerMail').val() = '';
        $('#CustomerPhone').val() = '';
        $('#CustomerCity').val() = '';
        $('#CustomerTown').val() = '';
    }

    $scope.login = function () {
        window.location = '/Login/Index';
    }

    $scope.logout = function () {
        $http(
            {
                method: 'POST',
                url: '/Login/Logout',
                data: {}
            }).then(function (response) {
                console.log(response.data[0]);
                var dataResult = response.data[0];
                if (dataResult.Type != 0) {
                    toastr.success(dataResult.Content);
                    window.location.href = '/Login/Index';
                }
                else {
                    toastr.error(dataResult.Content);
                }
            });
    }

    $scope.customerAdd = function () {
        $scope.customer.Username = $('#CustomerName').val();
        $scope.customer.Password = $('#CustomerPassword').val();
        $scope.customer.EMail = $('#CustomerMail').val();
        $scope.customer.Phone = $('#CustomerPhone').val();
        $scope.customer.City = $('#CustomerCity').val();
        $scope.customer.Town = $('#CustomerTown').val();

        $http(
            {
                method: 'POST',
                url: '/Login/SignUp',
                data: {
                    customer: $scope.customer,
                    passwordAgain: $('#CustomerPasswordAgain').val()
                }
            }).then(function (response) {
                //console.log(response.data[0]);
                var dataResult = response.data[0];
                if (dataResult.Type != 0) {
                    $('#signUp').modal('hide');
                    toastr.success(dataResult.Content);
                }
                else {
                    $('#signUp').modal('hide');
                    toastr.error(dataResult.Content);
                }
            });
    }

    $scope.search = function () {
        var searchData = $('#searchItem').val();

        $http(
            {
                method: 'POST',
                url: '/Home/GeneralSearch',
                data: { searh: searchData }
            }).then(function (response) {
                console.log(response.data[0]);
                var dataResult = response.data[0];
                if (dataResult.Type != 0) {
                    toastr.success(dataResult.Content);
                }
                else {
                    toastr.error(dataResult.Content);
                }
            });
    }

    $scope.customerDetail = function () {
        $('#customerDetail').modal('show');
    }

    $(document).ready(function () {
        $scope.CurrentCustomer();
    });
});
