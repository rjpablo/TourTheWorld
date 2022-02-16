(function () {
    'use strict';

    angular.module('bad.site.module')
        .filter('badI18n', ['badI18nService',
            function (i18nService) {
                var i18nFilter = function (input, subs, options) {
                    return i18nService.getString(input, subs, options);
                };

                return i18nFilter;
            }
        ]);
})();