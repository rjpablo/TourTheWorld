(function () {
    'use strict';

    angular.module('bad.main.module')
        .component('badTourdetails', {
            bindings: {
                tour: '<'
            },
            controllerAs: 'btd',
            templateUrl: 'bad-template',
            controller: controllerFn
        });

    controllerFn.$inject = ['badToursService', 'badCommonService'];
    function controllerFn(badToursService, badCommonService) {
        var btd = this;

        btd.$onInit = function () {
            badToursService.getPhotos(btd.tour.id)
                .then(photos => {
                    btd.media = photos || [];
                })
                .catch(error => {
                    badCommonService.handleError(error, 'app.Error_Tour_FailedToRetrievePhotos');
                });
        };

        btd.requestToJoin = function () {
            alert('Request to Join - Not yet implemented');
        };
    }
})();
