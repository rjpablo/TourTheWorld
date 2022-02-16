(function () {
    'use strict';

    angular.module('bad.site.module')
        .component('drbblyModal', {
            bindings: {
                model: '<',
                context: '<'
            },
            controllerAs: 'mod',
            templateUrl: 'drbbly-default',
            controller: controllerFn
        });

    controllerFn.$inject = [];
    function controllerFn() {
        var mod = this;

        mod.submit = function () {
            mod.context.submit('submitted');
        };

        mod.close = function () {
            mod.context.dismiss('dismissed');
        };
    }
})();
