﻿(function () {
    'use strict';

    angular.module('siteModule')
        .component('drbblyNavigator', {
            bindings: {},
            controllerAs: 'nav',
            templateUrl: 'drbbly-default',
            controller: controllerFn
        });

    controllerFn.$inject = ['authService', '$state', 'drbblyTeamshelperService', 'settingsService', 'modalService',
        'drbblyCourtshelperService', 'drbblyGameshelperService'];
    function controllerFn(authService, $state, drbblyTeamshelperService, settingsService, modalService,
        drbblyCourtshelperService, drbblyGameshelperService) {
        var nav = this;

        nav.$onInit = function () {
            nav.$state = $state;
            nav.usingSideNavigator = settingsService.useSideNavigator;
        };

        nav.searchClicked = function () {
            alert('Not yet implemented');
        };

        nav.logOut = function () {
            modalService.confirm('site.LogOutConfirmationMsg1', 'site.LogOutConfirmationMsg2', null, 'YesCancel')
                .then(function (response) {
                    if (response) {
                        authService.logOut();
                        $state.go('auth.login', { reload: true });
                    }
                });
        };

        nav.addTeam = function () {
            drbblyTeamshelperService.openAddTeamModal({})
                .then(function (team) {
                    if (team) {
                        $state.go('main.team.home', { id: team.id });
                    }
                });
        };

        nav.addCourt = function () {
            drbblyCourtshelperService.registerCourt()
                .then(function (court) {
                    if (court) {
                        $state.go('main.court.details', { id: court.id });
                    }
                });
        };

        nav.addGame = function () {
            drbblyGameshelperService.openAddEditGameModal({})
                .then(function (game) {
                    if (game) {
                        $state.go('main.game.details', { id: game.id });
                    }
                })
                .catch(function () { /* do nothing */ })
        };

        nav.isAuthenticated = function () {
            return authService.authentication.isAuthenticated;
        };

        //TEST FUNCTIONALITY ONLY
        nav.test = function () {
            authService.test();
        };
    }
})();
