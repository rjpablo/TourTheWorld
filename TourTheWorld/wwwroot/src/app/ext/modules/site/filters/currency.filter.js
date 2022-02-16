(function () {
    'use strict';

    angular.module('bad.site.module')
        .filter('badCurrency', ['$filter',
            function ($filter) {
                var filter = function (amount, symbol, fractionSize) {
                    return $filter('currency')(amount, symbol || '₱', fractionSize);
                };

                return filter;
            }
        ]);
})();