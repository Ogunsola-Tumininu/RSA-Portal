$(document).ready(function () {

    function getBenefitSubClass(id, id1) {
       // alert("running")
        $.ajax({
            url: "/Customer/GetBenefitSubClass",
            type: "POST",
            data: { "id": id , "id1": id1},
            success: function (response) {
                var option2 = $("<option></option>");
                option2.text("--Select Application Type--");
                $("#subClass").append(option2);
                for (var x = 0; x < response.length; x++) {
                    var option = $("<option></option>");
                    option.val(response[x].BenefitSubClassId);
                    option.text(response[x].BenefitSubClassValue);
                    $("#subClass").append(option);
                }

                $("#subClass").closest(".col-sm-6").fadeIn("slow");
            }
        });
    };

    getBenefitSubClass(2, 3)

    function getForm(id) {
        $.ajax({
            url: "/Customer/ReturnForm",
            data: { "id": id },
            cache: false,
            success: function (html) {
                $(".formContainer").append(html);
                $("#preform-loading").hide();
            }
        });
    }

    function checkStatus(id) {
        return $.ajax({
            url: "/Customer/CheckStatus",
            type: "POST",
            data: { "id": id }
        });
    }

    function alertWarning(message) {
        $("#warning").find(".message").empty();
        $("#warning").find(".message").append(message);
        $("#warning").fadeIn(1000, function () {
            $("#warning").fadeOut(10000);
        });
    }

    $(".benefitClass").change(function () {
        var id = $(this).val();
        $("#subClass").empty();
        getBenefitSubClass(id);
    });



    $("#subClass").change(function () {
        var id = $(this).val();
        $(".formContainer").empty();
        checkStatus(id).success(function (data) {
            $(".formContainer").empty();
            $("#preform-loading").show();
            getForm(id);
            //if (data) {
            //    alertWarning("You already have an open application of this type. Go to the benefits section to continue your application.");
            //} else {
            //    $(".formContainer").empty();
            //    $("#preform-loading").show();
            //    getForm(id);
            //}
        });
    });

    $(document).on('click', ".change-password", function () {
        $('#myModal').modal('show');
    });

    function alertMessages(element, message) {
        element.find(".status").empty();
        element.find(".status").append(message);
        element.focus();
        element.fadeIn(1000, function () {
            element.fadeOut(10000);
        });
    }

    $(".submit-button").on('click', function () {

        var element = $(this);
        var token = $('input[name="__RequestVerificationToken"]').val();
        var headers = {};
        headers['__RequestVerificationToken'] = token;

        var viewModel = {
            OldPassword: $("#old-password").val(),
            NewPassword: $("#new-password").val(),
            ConfirmPassword: $("#confirm-password").val()
        }

        var warning = $(this).closest(".modal-content").find(".register-warning");
        var success = $(this).closest(".modal-content").find(".register-success");

        element.hide();
        element.closest(".modal-footer").find(".loading-gif").show();

        $.ajax({
            url: "/Account/ChangePassword",
            type: "POST",
            headers: headers,
            data: JSON.stringify(viewModel),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                switch (data) {
                    case "check":
                        alertMessages(warning, " Kindly check your entries.");
                        break;
                    case "failed":
                        alertMessages(warning, " Ooops! something went wrong");
                        break;
                    case "success":
                        alertMessages(success, " Password changed successfully!");
                }
                element.closest(".modal-footer").find(".loading-gif").hide();
                element.show();
            }
        });
    });
});



$(document).on('click', '.panel-heading span.clickable', function (e) {
    var $this = $(this);
    if (!$this.hasClass('panel-collapsed')) {
        $this.parents('.panel').find('.panel-body').slideUp();
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');
    } else {
        $this.parents('.panel').find('.panel-body').slideDown();
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');
    }
})