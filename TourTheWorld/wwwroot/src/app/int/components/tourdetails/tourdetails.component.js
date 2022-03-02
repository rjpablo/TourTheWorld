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

    controllerFn.$inject = ['badToursService'];
    function controllerFn(badToursService) {
        var btd = this;

        btd.$onInit = function () {
            badToursService.getPhotos(btd.tour.id)
                .then(photos => {
                    btd.media = photos || [];
                })
                .catch(error => {
                    console.log('Failed to retrieve photos');
                    console.log(error);
                });
        };

        btd.requestToJoin = function () {
            alert('Request to Join - Not yet implemented');
        };
    }
})();
