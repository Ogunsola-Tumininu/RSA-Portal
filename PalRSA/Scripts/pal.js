/*
	By Osvaldas Valutis, www.osvaldas.info
	Available for use under the MIT License
*/

'use strict';

; (function ($, window, document, undefined) {
    $('.inputfile').each(function () {
        var $input = $(this),
			$label = $input.next('label'),
			labelVal = $label.html();

        $input.on('change', function (e) {
            var fileName = '';

            if (this.files && this.files.length > 1)
                fileName = (this.getAttribute('data-multiple-caption') || '').replace('{count}', this.files.length);
            else if (e.target.value)
                fileName = e.target.value.split('\\').pop();

            if (fileName)
                $label.find('span').html(fileName);
            else
                $label.html(labelVal);
        });

        // Firefox bug fix
        $input
		.on('focus', function () { $input.addClass('has-focus'); })
		.on('blur', function () { $input.removeClass('has-focus'); });
    });
})(jQuery, window, document);

function getExt(filename) {
    var x = filename.split("\\");
    var filenameLength = x.length;
    var ext = x[filenameLength - 1].split(".");
    var length = ext.length;
    return ext[length - 1];
}

var getresult = function (data) {
    alert(data.result);
};

function alertWarning(context, message) {
    $("#app-warning").find(".stat").empty();
    $("#app-warning").find(".stat").append(message);
    context.val('');
    $("#app-warning").focus();
    $("#app-warning").find(".exceed").fadeIn(1000, function () {
        $("#app-warning").find(".exceed").fadeOut(5000);
    });
}

function alertSuccess(message) {
    $("#app-success").find(".stat").empty();
    $("#app-success").find(".stat").append(message);
    $("#app-success").find(".exceed").fadeIn(1000, function () {
        $("#app-success").find(".exceed").fadeOut(5000);
    });
}

function validateForm() {
    var status = true;
    $('.products_disp').each(function () {
        if (!$(this).hasClass("valid")) {
            alertWarning($(this), " Some files have not been uploaded. Check your entries for the one without the pass mark");
            return status = false;
        }
    });
    return status;
}

$(document).on("click", ".send .submit", function () {
    var el = $(this);
    el.hide();
    el.closest(".send").find(".loading-gif").show();
    if (validateForm() === true) {
        $.ajax({
            url: "/Customer/FinalizeApplication",
            type: "POST",
            data: { id: $("#appid").val() },
            success: function(response) {
                el.attr("disabled", true);
                el.closest(".send").find(".loading-gif").hide();
                el.show();
                alertSuccess(" Application has been submitted successfully");
            }
        });
    } else {
        el.closest(".send").find(".loading-gif").hide();
        el.show();
    }
});

function Validate(fileid, filename, val) {
    var x = getExt(filename);
    var valid = $(val);

    try {
        var fileSize;
        fileSize = valid[0].files[0].size;
        fileSize = fileSize / 1048576; //size in mb
        $("#errorStatus").find("#vidStat").empty();

        if (fileSize > 2) {
            alertWarning(valid, " File is too large: Max 2mb");
        } else if ($("#appid").val() === "" && valid.data("first") !== true) {
            alertWarning(valid, " You have to submit the first document first");
        }
        else if (x === "png" || x === "jpg" || x === "pdf") {
            var data = new FormData();
            var files = valid.get(0).files;
            if (files.length > 0) {
                data.append("Doc", files[0]);
            }

            data.append("first", valid.data("first"));
            data.append("appid", $("#appid").val());
            data.append("benefitId", $("#benefitid").val());
            data.append("filename", valid.attr("name"));
            data.append("docid", valid.data("docinfoid"));

            valid.closest(".form-group").find(".loading-gif").show();
            $.ajax({
                url: "/Customer/UploadImage",
                type: "POST",
                processData: false,
                contentType: false,
                data: data,
                success: function (response) {
                    valid.attr('data-docinfoid', response.docInfoId);
                    $("#appid").val(response.appId);
                    valid.closest(".form-group").addClass("valid");
                    valid.closest(".form-group").find(".loading-gif").hide();
                    valid.closest(".form-group").find(".pass").show();
                    valid.attr("data-first", "undefined");
                    alertSuccess(" File successfully uploaded");
                },
                error: function (er) {
                    console.log(er);
                }

            });
        } else {
            alertWarning(valid, " Incorrect format: png or jpg");
        }

    } catch (e) {
        alert("Error is :" + e);
    }
}