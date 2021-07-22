$(document).ready(function () {
    FormValidation.Validator.securePassword = {
        validate: function (validator, $field, options) {
            var value = $field.val();
            if (value === '') {
                return true;
            }

            // Check the password strength
            if (value.length < 6) {
                return {
                    valid: false,
                    message: 'The password must be more than 6 characters long'
                };
            }

            //// The password doesn't contain any uppercase character
            //if (value === value.toLowerCase()) {
            //    return {
            //        valid: false,
            //        message: 'The password must contain at least one upper case character'
            //    }
            //}

            // The password doesn't contain any uppercase character
            if (value === value.toUpperCase()) {
                return {
                    valid: false,
                    message: 'The password must contain at least one lower case character'
                }
            }

            // The password doesn't contain any digit
            if (value.search(/[0-9]/) < 0) {
                return {
                    valid: false,
                    message: 'The password must contain at least one digit'
                }
            }

            return true;
        }
    };

    $('#profile-form').formValidation({
        framework: 'bootstrap',
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            MobileNumber: {
                validators: {
                    notEmpty: {
                        message: 'The phone number is required'
                    },
                    regexp: {
                        message: 'The phone number can only contain the digits',
                        regexp: /^[0-9\s\-()+\.]+$/
                    }
                }
            },
            MobileNumber2: {
                validators: {
                    regexp: {
                        message: 'The phone number can only contain the digits',
                        regexp: /^[0-9\s\-()+\.]+$/
                    }
                }
            }
        }
    });

    $('#login_form').formValidation({
        framework: 'bootstrap',
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            OldPassword: {
                validators: {
                    notEmpty: {
                        message: 'The Old Password is required'
                    }
                }
            },
            NewPassword: {
                validators: {
                    securePassword: {
                        message: 'The password is not valid'
                    },
                    identical: {
                        field: 'ConfirmPassword',
                        message: 'The password and its confirm are not the same'
                    },
                    notEmpty: {
                        message: 'The New Password is required'
                    }
                }
            },
            confirmPassword: {
                validators: {
                    identical: {
                        field: 'NewPassword',
                        message: 'The password and its confirm are not the same'
                    },
                    notEmpty: {
                        message: 'Confirm Password is required'
                    }
                }
            }
        }
    });

    $('#complete-reg').formValidation({
        framework: 'bootstrap',
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            QuestionId: {
                row: '.col-md-6 col-sm-6',
                validators: {
                    notEmpty: {
                        message: 'You must select a question'
                    }
                }
            },
            QuestionAnswer: {
                validators: {
                    notEmpty: {
                        message: 'The Question answer is required'
                    }
                }
            },
            OldPassword: {
                validators: {
                    notEmpty: {
                        message: 'The Old Password is required'
                    }
                }
            },
            NewPassword: {
                validators: {
                    securePassword: {
                        message: 'The password is not valid'
                    },
                    identical: {
                        field: 'ConfirmPassword',
                        message: 'The password and its confirm are not the same'
                    },
                    notEmpty: {
                        message: 'The New Password is required'
                    }
                }
            },
            confirmPassword: {
                validators: {
                    identical: {
                        field: 'NewPassword',
                        message: 'The password and its confirm are not the same'
                    },
                    notEmpty: {
                        message: 'Confirm Password is required'
                    }
                }
            }
        }
    });

    $('#upload-publication').formValidation({
        framework: 'bootstrap',
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            UploadType: {
                row: '.col-md-4 col-sm-4',
                validators: {
                    notEmpty: {
                        message: 'The Upload Type is required',
                    }
                }
            },
            DocName: {
                row: '.col-md-4 col-sm-4',
                validators: {
                    notEmpty: {
                        message: 'The Document name is required'
                    }
                }
            },
            Doc: {
                validators: {
                    notEmpty: {
                        message: 'Please choose a file to upload'
                    },
                    file: {
                        extension: 'pdf',
                        type: 'application/pdf',
                        maxSize: 2097152, // 2048 * 1024
                        message: 'The selected file is not valid. This input only allows pdf files'
                    }
                }
            }
        }
    });

    $('#change-of-name').formValidation({
        framework: 'bootstrap',
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            NewName: {
                row: '.col-md-6 col-sm-6',
                validators: {
                    notEmpty: {
                        message: 'The new name is required'
                    },
                    regexp: {
                        message: 'New Name can only contain letters',
                        regexp: /[A-Za-z]/
                    }
                }
            },
            Doc1: {
                validators: {
                    notEmpty: {
                        message: 'Please choose a file to upload'
                    },
                    file: {
                        extension: 'jpeg,jpg,png',
                        type: 'image/jpeg,image/png',
                        maxSize: 2097152, // 2048 * 1024
                        message: 'The selected file is not valid. This input only allows Jpg and png files'
                    }
                }
            },
            Doc2: {
                validators: {
                    notEmpty: {
                        message: 'Please choose a file to upload'
                    },
                    file: {
                        extension: 'jpeg,jpg,png',
                        type: 'image/jpeg,image/png',
                        maxSize: 2097152, // 2048 * 1024
                        message: 'The selected file is not valid. This input only allows Jpg and png files'
                    }
                }
            }
        }
    });

    $('#support').formValidation({
        framework: 'bootstrap',
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            Category: {
                row: '.col-md-3 col-sm-3',
                validators: {
                    notEmpty: {
                        message: 'Support Category is required'
                    }
                }
            },
            Summary: {
                row: '.col-md-3 col-sm-3',
                validators: {
                    notEmpty: {
                        message: 'Support Category is required'
                    }
                }
            },
            Explanation: {
                row: '.col-md-3 col-sm-3',
                validators: {
                    notEmpty: {
                        message: 'Support Category is required'
                    }
                }
            }
        }
    });

    $('#change-of-Address').formValidation({
        framework: 'bootstrap',
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            NewAddress: {
                row: '.col-md-6 col-sm-6',
                validators: {
                    notEmpty: {
                        message: 'The new Address is required'
                    }
                }
            },
            UtilityBill: {
                validators: {
                    notEmpty: {
                        message: 'Please choose a file to upload'
                    },
                    file: {
                        extension: 'jpeg,jpg,png',
                        type: 'image/jpeg,image/png',
                        maxSize: 2097152, // 2048 * 1024
                        message: 'The selected file is not valid. This input only allows Jpg and png files'
                    }
                }
            }
        }
    });

    $('#edit-manager').formValidation({
        framework: 'bootstrap',
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            AccountManagers: {
                row: '.col-md-4 col-sm-4',
                validators: {
                    notEmpty: {
                        message: 'The account Managers Name is required'
                    }
                }
            },
            Phonenumber: {
                validators: {
                    notEmpty: {
                        message: 'The phone number is required'
                    },
                    regexp: {
                        message: 'The phone number can only contain the digits',
                        regexp: /^[0-9\s\-()+\.]+$/
                    }
                }
            },
            Region: {
                validators: {
                    notEmpty: {
                        message: 'The Region is required'
                    }
                }
            }
        }
    });
});