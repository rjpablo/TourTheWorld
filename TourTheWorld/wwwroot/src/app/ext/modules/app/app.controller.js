(function () {
    'use strict';

    angular.module('bad.app.module')
        .controller('badAppController', [function () {
            var app = this;

            this.$onInit = function () {
                app.model = BAD ? BAD.model : {}; // the View's model
            };

        }]);
})();
