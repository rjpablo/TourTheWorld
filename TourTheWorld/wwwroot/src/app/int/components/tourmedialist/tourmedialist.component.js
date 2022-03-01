(function () {
    'use strict';

    angular.module('bad.main.module')
        .component('badTourmedialist', {
            bindings: {
                tour: '<',
                mediaList: '<'
            },
            controllerAs: 'tml',
            templateUrl: 'bad-template',
            controller: controllerFn
        });

    controllerFn.$inject = ['badToursService', 'badWizardService'];
    function controllerFn(badToursService, badWizardService) {
        var tml = this;

        tml.$onInit = function () {
            tml.mediaList = tml.mediaList || [];
            tml.canAdd = true;
        };

        tml.onFilesSelected = function (files) {
            if (files && files.length) {
                badToursService.addTourMedia(files, tml.tour.id)
                    .then(function (result) {
                        tml.mediaList.unshift(...result);
                        return tml.setPrimaryMedia(result[0].id);
                    })
                    .catch(function (error) {
                        console.log(error);
                    })
                    .finally(() => tml.isBusy = false);
            }
        }

        tml.setPrimaryMedia = mediaId => {
            return badToursService.setPrimaryMedia(tml.tour.id, mediaId);
        }
    }
})();
