(function () {
    'use strict';

    angular.module('bad.main.module')
        .service('badToursService', ['badHttpService', 'badFilesService',
            function (badHttpService, badFilesService) {
                var baseApiRoute = 'api/Tours/';

                var _service = {
                    addTourMedia: (files, tourId) => {
                        return badFilesService.upload(files, baseApiRoute + `AddTourPhotos/${tourId}`);
                    },
                    addTour: input => badHttpService.post(baseApiRoute + 'addTour/', input),
                    /**
                     * Sets the tour's primary media
                     */
                    setPrimaryMedia: (tourId, mediaId) => badHttpService
                        .get(`${baseApiRoute}setPrimaryMedia/${tourId}/${mediaId}`)
                }

                return _service;

            }]);
})();