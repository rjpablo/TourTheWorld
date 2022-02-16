(function () {
    'use strict';

    angular.module('bad.site.module')
        .directive('drbblyConfirmpassword', [function () {
            return {
                require: 'ngModel',
                scope: {
                    mustMatch: '<mustMatch'
                },
                restrict: 'A',
                link: function (scope, elm, attrs, ngModelCtrl) {
                    scope.$watch('mustMatch', function () {
                        ngModelCtrl.$validate();
                    });

                    ngModelCtrl.$validators.match = function (modelValue) {
                        return !scope.mustMatch || scope.mustMatch === modelValue;
                    };
                }
            };
        }
        ]);
})();
