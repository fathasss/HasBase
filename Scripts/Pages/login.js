angular.module('hasB4bLogin', []).controller('loginController', function ($scope, $http, $location, $window) {

    $scope.remember = false;
    $scope.customer = {
        Username: '',
        Password: '',
        EMail: '',
        Phone: ''
    };
    $scope.oldCustomer = {
        Username: '',
        EMail: '',
        Phone: ''
    };
    $scope.newCustomer = {
        Username: '',
        EMail: '',
        Phone: '',
        Password: '',
        PasswordAgain: '',
        City: '',
        Town: ''
    };

    $scope.login = function () {
        $http(
            {
                method: 'POST',
                url: '/Login/Index',
                data: { model: $scope.customer }
            }).then(function (response) {
                console.log(response.data[0]);
                var dataResult = response.data[0];
                if (dataResult.Type != 0) {
                    toastr.success(dataResult.Content);
                    window.location.href = '/Home/Index';
                }
                else {
                    toastr.error(dataResult.Content);
                }
            });

    }

    $scope.forgotPassword = function () {
        $('#forgotPassword').modal('show');
    }

    $scope.forgotPassSave = function () {
        $scope.customer.Username = $scope.oldCustomer.Username;
        $scope.customer.EMail = $scope.oldCustomer.EMail;
        $scope.customer.Phone = $scope.oldCustomer.Phone;

        $http(
            {
                method: 'POST',
                url: '/Login/ForgotPassword',
                data: { customer: $scope.customer }
            }).then(function (response) {
                var dataResult = response.data;
                if (dataResult != null) {
                    $('#forgotPassword').modal('hide');
                    toastr.success(response.data);
                }
                else {
                    $('#forgotPassword').modal('hide');
                    toastr.error("ERROR");
                }
            });
    }

    $scope.signUp = function () {
        $('#signUp').modal('show');
        $scope.newCustomer.Username = '';
        $scope.newCustomer.Password = '';
        $scope.newCustomer.PasswordAgain = '';
        $scope.newCustomer.EMail = '';
        $scope.newCustomer.Phone = '';
        $scope.newCustomer.City = '';
        $scope.newCustomer.Town = '';
    }

    $scope.customerAdd = function () {

        if ($scope.newCustomer.Password != $scope.newCustomer.PasswordAgain) {
            toastr.error('Girilen şifreler uyuşmamaktadır.');
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
                data: { customer: $scope.customer }
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
    $scope.getLocation = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {

                $scope.latitudeDevice = position.coords.latitude;
                $scope.longitudeDevice = position.coords.longitude;

                $http(
                    {
                        method: 'POST',
                        url: '/Login/GetLocation',
                        data: {
                            latitude: $scope.latitudeDevice,
                            longitude: $scope.longitudeDevice
                        }
                    }).then(function (response) {
                        console.log(response.data);
                    });
            });
            console.log(response.data);
        }
    }

    $scope.keyevent = function (event) {
        if (event.keyCode == 13) {
            $scope.login();
        }
    }

    $(document).ready(function () {
        $scope.getLocation();
    });
}