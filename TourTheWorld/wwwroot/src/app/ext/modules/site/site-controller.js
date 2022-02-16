(function () {
    'use strict';

    angular.module('bad.site.module')
        .controller('siteController', [function () {
            var site = this;
            site.message = 'Message from Site';
        }]);
})();
