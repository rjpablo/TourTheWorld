(function () {
    'use strict';

    angular
        .module('bad.site.module')
        .component('badGallery', {
            bindings: {
                onDelete: '<',
                onSelect: '<',
                canAdd: '<',
                media: '<',
                options: '<'
            },
            controllerAs: 'glr',
            templateUrl: 'drbbly-default',
            controller: controllerFunc
        });

    controllerFunc.$inject = ['badCommonService'];
    function controllerFunc(badCommonService) {
        var glr = this;

        glr.$onInit = function () {
            glr.media = glr.media || [];
            glr._options = glr.options || {};
        };

        glr.deletePhoto = function (photo, done) {
            if (glr.onDelete) {
                glr.onDelete(photo)
                    .then(function () {
                        done();
                    })
                    .catch(function (error) {
                        badCommonService.handleError(error);
                    });
            }
        };

        glr.addPhotos = function (files) {
            if (files && files.length && glr.onSelect) {
                glr.onSelect(files);
            }
        };

        glr.hasFiles = () => glr.media && glr.media.length > 0;
    }
})();
