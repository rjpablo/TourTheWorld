(function () {
    'use strict';

        .component('drbblyDate', {
    angular.module('bad.site.module')
            bindings: {
                date: '<',
                format: '<',
                asFromNow: '<'
            },
            controllerAs: 'dte',
            templateUrl: 'drbbly-default',
            controller: controllerFn
        });

    controllerFn.$inject = ['settingsService', 'drbblyDatetimeService'];
    function controllerFn(settingsService, drbblyDatetimeService) {
        var dte = this;

        dte.$onInit = function () {
            dte.format = dte.format || settingsService.defaultDateFormat;
            if (dte.asFromNow) {
                dte.dateText = moment(drbblyDatetimeService.toUtcString(dte.date)).fromNow();
            }
        };
    }
})();
