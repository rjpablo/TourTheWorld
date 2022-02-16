(function () {
    'use strict';

    //fix for custom ng-sanitize incompatibility with AngularJS 1.7
    angular.lowercase = angular.$$lowercase;

    angular.badRawModuleNames = [];

    var originalModuleFunc = angular.module;
    angular.module = function () {

        var module = originalModuleFunc.apply(this, arguments);

        //if registering the module for the first time... (vs. retrieving)
        if (arguments.length === 2) {

            var moduleName = arguments[0];
            var dependencies = arguments[1];

            if (moduleName === 'bad.site.module' ||
                //check if this module depends on one of our modules
                dependencies.drbblyIntersect(angular.badRawModuleNames).drbblyAny()) {
                //this is our module for sure
                //(no one else is writing dependencies on our modules except us)
            }
            else {
                //NOT our module
                return module;
            }

            angular.badRawModuleNames.push(moduleName); //Dribbly only

            overrideComponentFunc(module);
        }

        return module;
    };

    function overrideComponentFunc(module) {
        var originalComponentFn = module.component;
        module.component = function (componentName, options) {
            console.log('Initializing component ' + componentName);
            var moduleName = module.name.replace('.module', '');
            //if registering a component... (vs. retrieving)
            if (arguments.length === 2) {
                //override templateUrl
                if (options.templateUrl === 'bad-template' || options.templateUrl === 'drbbly-default') {
                    var trimmedComponentName = componentName.replace('bad', '').toLowerCase();
                    if (moduleName === 'bad.main') {
                        options.templateUrl = '/src/app/int/components/' + trimmedComponentName + '/'
                            + trimmedComponentName + '.component.html';
                    }
                    else if (moduleName === 'bad.app') {
                        options.templateUrl = '/src/app/ext/modules/app/components/' + trimmedComponentName + '/'
                            + trimmedComponentName + '.component.html';
                    }
                    else if (moduleName === 'bad.site') {
                        options.templateUrl = '/src/app/ext/modules/site/components/' + trimmedComponentName + '/'
                            + trimmedComponentName + '.component.html';
                    }
                    else if (moduleName === 'bad.auth') {
                        options.templateUrl = '/src/modules/auth/components/' + trimmedComponentName + '/'
                            + trimmedComponentName + '.component.html';
                    }
                }
            }
            originalComponentFn.apply(module, arguments);
        };
    }

})();