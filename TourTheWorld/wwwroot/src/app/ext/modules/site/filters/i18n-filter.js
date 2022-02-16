(function () {
    'use strict';

        .filter('i18n', ['i18nService',
    angular.module('bad.site.module')
            function (i18nService) {
                var i18nFilter = function (input, subs, options) {
                    return i18nService.getString(input, subs, options);
                };

                return i18nFilter;
            }
        ]);
})();