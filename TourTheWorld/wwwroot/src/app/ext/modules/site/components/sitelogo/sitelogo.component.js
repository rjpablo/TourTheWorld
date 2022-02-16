(function () {
    'use strict';

    angular.module('bad.site.module')
        .component('drbblySitelogo', {
            bindings: {},
            controllerAs: 'dsl',
            templateUrl: 'drbbly-default',
            controller: controllerFn
        });

    controllerFn.$inject = [];
    function controllerFn() {
        var dsl = this;
    }
})();
