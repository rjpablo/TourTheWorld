(function () {
    'use strict';

    angular.module('bad.site.module')
        .service('badFilesService', serviceFunc);
    serviceFunc.$inject = ['Upload', 'badSettingsService', '$rootScope', '$compile', '$interpolate', 'badHttpService'];
    function serviceFunc(Upload, badSettingsService, $rootScope, $compile, $interpolate, badHttpService) {
        var _browseButton;

        function upload(files, apiMethod, otherInfo) {
            var formData = new FormData();

            for (var i = 0; i != files.length; i++) {
                formData.append("files", files[i]);
            }

            return badHttpService.ajax({
                url: apiMethod,
                type: 'POST',
                dataType: 'json',
                data: formData,
                contentType: false,
                processData: false
            });

            //return badHttpService.post(apiMethod, formData, { headers: { "Content-Type": 'multipart/form-data' } });

            //formData.otherInfo = JSON.stringify(otherInfo) || '';

            //return Upload.upload({
            //    url: badSettingsService.serviceBase + (apiMethod || badSettingsService.defualtFileUploadApiEndPoint),
            //    data: formData
            //});
        }

        function browseVideo(callback, event) {
            var options = {
                pattern: '\'video/*\'',
                accept: '\'video/*\'',
                maxSize: badSettingsService.maxVideoUploadMb + 'MB',
                multiple: false,
                onSelect: function (files, e) {
                    callback(files);
                    // Dispose auto generated button and input element
                    // NOTE: The auto-generated elements are not disposed if the user cancels the file browser dialog
                    // TODO: Find a way to dispose the elements when the dialog is cancelled
                    if (e && e.currentTarget) {
                        e.currentTarget.remove();
                    }
                    _browseButton.remove();
                }
            };
            browseFile(options, event);
        }

        function browseFile(options, event) {
            _browseButton = buildInput(options, event);
            _browseButton.click();
        }

        function buildInput(options) {
            var scope = $rootScope.$new();
            scope = Object.assign(scope, options);
            var template = $interpolate(`<button ngf-select="onSelect($files, $event)"
                                    ngf-pattern="{{pattern}}"
                                    ngf-multiple="{{multiple}}"
                                    ngf-accept="{{accept}}"
                                    ngf-max-size="{{maxSize}}"
                                    ng-model="{{model}}"
                                    class="d-none"></button>`)(options);
            var elem = $compile(template)(scope);
            document.body.append(elem[0]);
            return elem;
        }

        var _service = {
            browseVideo: browseVideo,
            upload: upload
        };

        return _service;
    }

})();