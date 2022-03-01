(function () {
    'use strict';

    angular.module('bad.site.module')
        .service('badWizardService', [
            function () {

                function buildWizardObject() {
                    var wizard = {
                        step: 1,
                        next: () => {
                            wizard.step++;
                        },
                        previous: () => {
                            if (wizard.step === 1) {
                                throw new Error("Already on the first step.")
                            } else {
                                wizard.step--;
                            }
                        },
                        canGoBack: () => wizard.step > 0,
                        goToStep: (toStep) => wizard.step = toStep
                    }

                    return wizard;
                }

                var service = {
                    buildWizardObject: buildWizardObject
                };

                return service;
            }]);
})();