hasB4B.controller('layoutController', function ($scope, $http, $location, $window) {

    $scope.CurrentCustomer = function () {
        $http(
            {
                method: 'POST',
                url: '/Home/CurrentCustomerData',
                data: {}
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

    $scope.newCustomer = {
        Username: '',
        Password: '',
        EMail: '',
        Phone: '',
        City: '',
        Town: '',
        PasswordAgain: ''
    };

    $scope.signUp = function () {
        $('#signUp').modal('show');
        $scope.newCustomer.Username = '';
        $scope.newCustomer.Password = '';
        $scope.newCustomer.Mail = '';
        $scope.newCustomer.Phone = '';
        $scope.newCustomer.City = '';
        $scope.newCustomer.Town = '';
        $scope.newCustomer.PasswordAgain = '';
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
                var dataResult = response.data[0];
                if (dataResult.Type != 1) {
                    toastr.success(dataResult.Content);
                    window.location.href = '/Home/Index';
                }
                else {
                    toastr.error(dataResult.Content);
                }
            });
    }

    $scope.customerAdd = function () {

        if ($scope.newCustomer.PasswordAgain != $scope.newCustomer.Password) {
            toastr.error(dataResult.Content);
            $('#signUp').modal('hide');
            return;
        }

        $scope.customer.Username = $scope.newCustomer.Username;
        $scope.customer.Password = $scope.newCustomer.Password;
        $scope.customer.EMail = $scope.newCustomer.EMail;
        $scope.customer.Phone = $scope.newCustomer.Phone;
        $scope.customer.City = $scope.newCustomer.City;
        $scope.customer.Town = $scope.newCustomer.Town;

        $http(
            {
                method: 'POST',
                url: '/Login/SignUp',
                data: {
                    customer: $scope.customer,
                    passwordAgain: $('#CustomerPasswordAgain').val()
                }
            }).then(function (response) {
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
