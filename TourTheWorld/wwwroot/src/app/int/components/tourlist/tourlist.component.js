(function () {
    'use strict';

    angular.module('bad.main.module')
        .component('badTourlist', {
            bindings: {
                tours: '<'
            },
            controllerAs: 'btl',
            templateUrl: 'bad-template',
            controller: controllerFn
        });

    controllerFn.$inject = [];
    function controllerFn() {
        var btl = this;

        btl.$onInit = function () {
            console.log('badTourlist $onInit.')
        };
    }
})();
