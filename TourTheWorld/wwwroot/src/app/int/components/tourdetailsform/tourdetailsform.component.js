(function () {
    'use strict';

    angular.module('bad.main.module')
        .component('badTourdetailsform', {
            bindings: {
                tour: '<',
                isEdit: '<'
            },
            controllerAs: 'tdf',
            templateUrl: 'bad-template',
            controller: controllerFn
        });

    controllerFn.$inject = ['badToursService', 'badWizardService'];
    function controllerFn(badToursService, badWizardService) {
        var tdf = this;

        tdf.$onInit = function () {
            tdf.media = [];
            tdf.isBusy = false;
            //tdf.wizard = badWizardService.buildWizardObject();
            //tdf.wizard.next();
            if (!tdf.isEdit) {
                tdf.tour = { price: 0 };
            }
        };

        //tdf.onFilesSelected = function (files) {
        //    if (files && files.length) {
        //        badToursService.addTourMedia(files, tdf.tour.id)
        //            .then(function (result) {
        //                tdf.media.unshift(...result);
        //                return tdf.setPrimaryMedia(result[0].id);
        //            })
        //            .catch(function (error) {
        //                console.log(error);
        //            })
        //            .finally(() => tdf.isBusy = false);
        //    }
        //}

        //tdf.setPrimaryMedia = mediaId => {
        //    return badToursService.setPrimaryMedia(tdf.tour.id, mediaId);
        //}

        tdf.submitTour = function () {
            badToursService.addTour(tdf.tour)
                .then((tour) => {
                    tdf.tour = tour;
                    tdf.frmTourDetails.$setSubmitted();
                    location.href = `/Tours/Photos/${tour.id}`;
                })
                .catch((err) => { console.log(err) })
                .finally(() => tdf.isBusy = false);
        }
    }
})();
