(function () {
    'use strict';

    angular.module('bad.site.module')
        .service('badHttpService', ['$http', 'badSettingsService', '$q',
            function ($http, badSettingsService, $q) {

                function _get(url, config) {
                    var deferred = $q.defer();
                    $http.get(badSettingsService.serviceBase + url, config)
                        .then(function (response) {
                            deferred.resolve(response.data);
                        })
                        .catch(function (response) {
                            deferred.reject(response.data);
                        });

                    return deferred.promise;
                }

                function _post(url, data, config) {
                    var deferred = $q.defer();
                    $http.post(badSettingsService.serviceBase + url, data, config)
                        .then(function (response) {
                            deferred.resolve(response.data);
                        })
                        .catch(function (response) {
                            deferred.reject(response.data);
                        });

                    return deferred.promise;
                }

                function ajax(config) {

                    var deferred = $q.defer();
                    config.url = badSettingsService.serviceBase + config.url;
                    config.success = result => deferred.resolve(result);
                    config.error = error => deferred.reject(error);

                    $.ajax(config);

                    return deferred.promise;
                }

                var service = {
                    ajax: ajax,
                    get: _get,
                    post: _post
                };

                return service;
            }]);
})();