(function () {
    'use strict';

    angular.module('bad.site.module')
        .component('badDate', {
            bindings: {
                date: '<',
                format: '<',
                asFromNow: '<'
            },
            controllerAs: 'dte',
            templateUrl: 'bad-template',
            controller: controllerFn
        });

    controllerFn.$inject = ['badDatetimeService'];
    function controllerFn(badDatetimeService) {
        var dte = this;

        dte.$onInit = function () {
            dte.format = dte.format || 'MMM d, y h:mm a';
            if (dte.asFromNow) {
                dte.dateText = moment(badDatetimeService.toUtcString(dte.date)).fromNow();
            }
        };
    }
})();
