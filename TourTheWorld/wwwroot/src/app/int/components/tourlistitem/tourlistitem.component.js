(function () {
    'use strict';

    angular.module('bad.main.module')
        .component('badTourlistitem', {
            bindings: {
                tour: '<'
            },
            controllerAs: 'tli',
            templateUrl: 'bad-template',
            controller: controllerFn
        });

    controllerFn.$inject = [];
    function controllerFn() {
        var tli = this;

        tli.$onInit = function () {
            
        };
    }
})();
