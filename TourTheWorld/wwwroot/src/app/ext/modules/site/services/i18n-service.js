(function () {
    'use strict';

    // If an entry can be used in other apps other than Dribbly (basketball), such as Store, it should go under site.

    angular.module('bad.site.module')
        .service('badI18nService', ['$timeout', 'constants', function ($timeout, constants) {
            var _entries = {};
            var _modules = ['site', 'app', 'auth'];
            var _entriesTmp = {
                site: {
                    AboutUs: 'About Us',
                    AccountDetails: 'Account Details',
                    AccountSettings: 'Account Settings',
                    Add: 'Add',
                    AddPhotos: 'Add Photos',
                    Bookings: 'Bookings',
                    Cancel: 'Cancel',
                    Change: 'Change',
                    Close: 'Close',
                    ConfirmPassword: 'Confirm Password',
                    ConfirmNewPassword: 'Confirm New Password',
                    Contact: 'Contact',
                    ContactVerificationNotice: 'A code will be sent to {contactNumber}. You will have to enter this code to complete the verification.',
                    Continue: 'Continue',
                    DeactivateAccount: 'Deactivate Account',
                    DeactivateAccountPrompt: 'After deactivation, you will be logged out and your account will not be viewable by anyone until the next time that you log in. Do you want to proceed?',
                    Delete: 'Delete',
                    DeleteAccount: 'Delete Account',
                    DeleteAccountPrompt: 'Deleting your account cannot be undone. Are you sure you want to do it?',
                    Details: 'Details',
                    Done: 'Done',
                    Edit: 'Edit',
                    Email: 'Email',
                    Error_Auth_SessionExpired: 'Your session has expired. Please log in again to continue.',
                    Error_Common_InvalidEmail: 'Please enter a valid email address',
                    Error_Common_InvalidMobileNo_TenDigit: 'Invalid Format. Please enter 10-digit mobile number',
                    Error_Common_InvalidLink: 'The link you used is either invalid or expired. Please try requesting for another link.',
                    Error_Common_InvalidPassword: 'Password must be 6-14 characters long and must contain at least one lower case letter, at least one upper case letter, at least one digit and no spaces.',
                    Error_Common_Minlength: 'Should be at least ({length}) characters long',
                    Error_Common_MustMatchPassword: 'Must match the password',
                    Error_Common_PleaseFixErrors: 'Please fix errors',
                    Error_Common_UnexpectedError: 'An unexpected error occurred. Please try again.',
                    Error_Default_Title: 'Ooops...',
                    Error_Default_Message: 'An unexpected error occurred. This has been reported and we\'re looking into it.',
                    Error_Map_CityNameNotFound: 'Could not retrieve city name.' +
                        ' Please try a different location.',
                    Error_Map_CountryNameNotFound: 'Could not retrieve country name.' +
                        ' Please try a different location.',
                    Error_Map_FailedToRetrieveLocation: 'Failed to retrieve location details. Please try a different location.',
                    Error_Map_PhOnly: 'We\'re very sorry but we currently only support locations' +
                        ' within the Philippines. We\'re currently working to expand our' +
                        ' coverage. We\'ll let you know once were done. Thank you for understanding.',
                    Error_PhoneVerification_CouldNotSend: 'We couldn\'t send the verification code. Please make sure that the number is correct and then try again.',
                    Error_PhoneVerification_IncorrectCode: 'The code that you entered was incorrect. Please try again.',
                    Error_PhoneVerification_NumberNeedsVerification: 'Contact no. needs to be verified',
                    Follow: 'Follow',
                    FollowerCountDisplay: '{count} Follower(s)',
                    FollowUs: 'Follow Us',
                    From: 'From',
                    GoBack: 'Go Back',
                    Home: 'Home',
                    Km: 'km',
                    LetsChat: 'Let\'s Chat',
                    Location: 'Location',
                    LoggedInAs: 'logged in as <strong class="text-capitalize">{userName}</strong>',
                    LogOut: 'Log Out',
                    LogOutConfirmationMsg1: 'Action is not yet over...',
                    LogOutConfirmationMsg2: 'Are you sure you want to log out?',
                    MobileNo: 'Mobile No.',
                    MobileNoPlaceholder: '10-digit no. (e.g. \'912 345 6789\')',
                    Name: 'Name',
                    NewPassword: 'New Password',
                    No: 'No',
                    NotSet: 'Not Set',
                    Ok: 'Ok',
                    Optional: 'Optional',
                    Or: 'Or',
                    OverlayErrorMsg: 'Oh no! The shot missed :(',
                    OverlayBusyMsg: 'Hold on tight... A shot is on the way!',
                    Password: 'Password',
                    Posts: 'Posts',
                    Price: 'Price',
                    ReactivateAccount: 'Re-activate Account',
                    Rating: 'Rating',
                    Remove: 'Remove',
                    Replace: 'Replace',
                    Required: 'Required',
                    Review: 'Review',
                    Reviews: 'Reviews',
                    Schedule: 'Schedule',
                    Search: 'Search',
                    SendCode: 'Send Code',
                    SiteName: constants.site.name,
                    SlashHour: '/hr',
                    Submit: 'Submit',
                    Title: 'Title',
                    To: 'To',
                    Unfollow: 'Unfollow',
                    Update: 'Update',
                    Username: 'Username',
                    UnsavedChangesWarningMessage: 'You may lose you unsaved Changes. Are you sure?',
                    VerificationCodePrompt: 'Please enter the code that was sent to {contactNumber} and then click \'Submit\'',
                    VerificationSuccessful: 'Verification Successful!',
                    Verified: 'Verified',
                    Verify: 'Verify',
                    Videos: 'Videos',
                    WelcomeToDribblyExclamation: 'Welcome to dribbly!',
                    Yes: 'Yes'
                },
                auth: {
                    AlreadyHaveAnAccount: 'Already have an account?',
                    ChangeEmailAddress: 'Change email address',
                    CurrentPassword: 'Current Password',
                    DontHaveAnAccount: 'Don\'t have an account?',
                    ForgotPassword: 'Forgot Password',
                    GoBackToLogin: 'Go back to Login',
                    LogIn: 'Log In',
                    LogInWithFacebook: 'Log in with Facebook',
                    LogInWithGoogle: 'Log in with Google',
                    PasswordChangedSuccessfully: 'Your password has been changed successfully.',
                    PasswordResetSuccessfulHeader: 'Password reset successful!',
                    PasswordResetSuccessfulDetails: 'You have successfully reset your password. You may now <a href="#/login">Log In</a>', //TODO: append # dynamically
                    PleaseLogInToProceed: 'Please log in to proceed.',
                    ResendLink: 'Resend link',
                    ResendingLink: 'Resending link',
                    ResetLinkSentHeader: 'Reset link sent!',
                    ResetLinkSentDetails: 'A reset link has been sent to <strong>{email}</strong>. Please follow the instructions in the email to reset your password.',
                    ResetPassword: 'Reset Password',
                    SignUp: 'Sign Up'
                },
                app: {
                    AddAnEpicTour: 'Add an Epic Tour',
                    AddTourMediaPrompt: 'Add photos and/or videos of the tour to show joiners what to expect.',
                    Error_Tour_FailedToRetrievePhotos: 'Failed to retrieve tour photos',
                    SubmitAndAddPhotos: 'Submit and Add Photos',
                    ViewFullDetails: 'View Full Details'
                }
            };

            //massage entries
            _modules.forEach(function (module) {
                var moduleEntriesTmp = _entriesTmp[module];
                var moduleEntries = {};
                Object.keys(moduleEntriesTmp).forEach(function (key) {
                    var pieces = key.split('.');
                    var value = moduleEntriesTmp[key]
                    if (pieces.length === 1 || pieces.length === 2) {
                        if (pieces.length === 1) {
                            moduleEntries[key] = value;
                        }
                        else { // if enum
                            var enumName = pieces[0];
                            var theEnum = moduleEntries[enumName] || {};
                            var numericKey = key.match(/(?<=_)\d+$/)[0];
                            var textKey = pieces[1].substr(0, pieces[1].length - (numericKey.length + 1));
                            theEnum[numericKey] = value;
                            theEnum[textKey] = value;
                            moduleEntries[enumName] = theEnum;
                            enumName = enumName.toLowerFirst(); // constants use camel case for enum names
                            constants.enums[enumName] = constants.enums[enumName] || {};
                            constants.enums[enumName][textKey] = Number(numericKey);
                        }
                    }
                    else {
                        throw new Error('Invalid i18n key: ' + key);
                    }
                });
                _entries[module] = moduleEntries;
            });

            var thrownErrors = [];

            function applySubstitutions(text, subs) {
                var result = text;

                if (subs) {
                    angular.forEach(subs, function (value, key) {
                        var subValue;
                        if (value === null || value === undefined) {
                            throwErrorIfNeeded('Value for ' + key + ' is not provided.');
                            subValue = '';
                        }
                        else {
                            subValue = value;
                        }

                        result = result.replace(new RegExp('{' + key + '}', 'g'), subValue);
                    });
                }
                result = result.replace(/\n/g, '<br>');

                return result;
            }

            function throwErrorIfNeeded(msg) {
                //1. We don't want to interrupt the return of the value... 
                //   If the service is being called by filters or directives.
                //   That could break bindings, etc.
                //2. We do want to tap into or error handling infrastructure.
                //3. So we need to log, async.
                //4. But we must do so within angular (vs. window.setTimeout()),
                //   so that angular error handling can capture it.
                //5. A single filter or directive binding call can happen many times,
                //   during multiple angular digest cycles.  We don't want it to 
                //   be logged a zillion times.  Once per page is enough.
                //   So, we limit it here.
                //6. $timeout will cause another digest cycle (which re-evaluates the
                //   the filter, which can cause an endless loop if we were not to do #5.
                //   invokeApply = false below should prevent this?  TODO: research.
                //   But in the end it doesn't matter... we don't want to log multiples anyway.

                if (!thrownErrors.includes(msg)) {
                    thrownErrors.push(msg);
                    $timeout(function () {
                        throw new Error(msg);
                    }, 1000, false);
                }
            }

            function _getValue(token) {

                var pieces = token.split('.');
                if (pieces.length >= 2) {
                    var library = _entries[pieces[0]];
                    if (library) {
                        var value = library[pieces[1]];
                        //if enum...
                        if (value && pieces.length === 3) {
                            value = value[pieces[2]];
                        }

                        if (value) {
                            return value;
                        }
                    }
                }

                return undefined;
            }

            function getLocalizedString(token, subs, options) {

                if (token) {
                    if (angular.isString(token)) {

                        var value = _getValue(token);
                        if (value) {
                            return applySubstitutions(value, subs);
                        }

                        if (options && options.suppressErrors) {
                            return token.split('.').atsLast(); //library.key --> key
                        }

                        var msg = '%%KEY_' + token + '_NOT_FOUND%%';
                        //don't break function (log to the side)

                        throwErrorIfNeeded(msg);

                        return msg;
                    }
                    else if (angular.isArray(token)) {
                        return getLocalizedString(token[0], token[1], options);
                    }
                    else if (angular.isObject(token)) {
                        return getLocalizedString(token.token, token.subs, options);
                    }
                    else if (angular.isFunction(token)) {
                        //handle selectors (i.e. dynamic tokens)
                        return getLocalizedString(token(subs), subs, options);
                    }
                }

                if (options && options.suppressErrors) {
                    return getLocalizedString('site.Unknown'); //This will be displayed to users
                }

                /* eslint-disable no-redeclare */
                var msg = '%%KEY_NOT_FOUND%%';
                //don't break function (log to the side)

                throwErrorIfNeeded(msg);

                return msg;
            }

            function convertEnumToChoices(enumeration, config) {
                var choicesConfig = config || {};
                var choices = [];
                var enumObj = _getValue(enumeration);

                angular.forEach(enumObj, function (value, key) {
                    if (choicesConfig.useEnumAsValue) {
                        if (!Dribbly.isNumber(key)) {
                            choices.push({
                                value: key,
                                text: choicesConfig.useEnumAsText ? key : value
                            });
                        }
                    }
                    else {
                        if (Dribbly.isNumber(key)) {
                            choices.push({
                                value: Number(key),
                                text: choicesConfig.useEnumAsText ? key : value
                            });
                        }
                    }
                });

                return choices;
            }

            this.convertEnumToChoices = convertEnumToChoices;
            this.getValue = _getValue;
            this.getString = getLocalizedString;

            return this;
        }]);
})();