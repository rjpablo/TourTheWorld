(function () {
    'use strict';

    angular.module('bad.site.module')
        .service('badToastService', ['$timeout', 'toaster', 'badI18nService',
            function ($timeout, toaster, badI18nService) {

                var timeout = 2000;

                var _settings = {
                    'position-class': 'toast-top-center',
                    'limit': 3,
                    'time-out': timeout,
                    'showCloseButton': true,
                    'tapToDismiss': true
                };

                var _error = function (message, title) {
                    $timeout(function () {
                        toaster.pop({ type: 'error', title: title || badI18nService.getString('site.Error_Default_Title'), body: message || badI18nService.getString('site.Error_Default_Title'), showCloseButton: true, 'timeout': timeout });
                    });
                };

                var _success = function (message, title) {
                    $timeout(function () {
                        toaster.pop({ type: 'success', title: title || 'Success!', body: message, showCloseButton: true, 'timeout': timeout });
                    });
                };

                var _info = function (message, title) {
                    $timeout(function () {
                        toaster.pop({ type: 'info', title: title || 'Information!', body: message, showCloseButton: true, 'timeout': timeout });
                    });
                };

                var service = {
                    settings: _settings,
                    error: _error,
                    success: _success,
                    info: _info
                };

                return service;
            }]);
})();