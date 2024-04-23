$(function () {
    "use strict";

    console.info("Page loaded");

    // child elements are potentially reloaded, so keep ref to parent
    const $formContainer = $("#formContainer");
    const $submitButton = $("input[type='submit']");

    initialise();

    function initialise() {
        setSubmitEnabled(false);

        $formContainer
            .on("input", "input", handleInput)
            .on('submit', 'form', handleFormSubmit)
            .on('change', '#FirstName, #LastName, #Email', () => $(this).valid())
            .on('change', '#IsHalfDay, #StartDate, #EndDate', handleDateChange);

        loadLeaveRequests();
    }

    function handleInput() {
        const isValid = $formContainer.find('form').validate().form();
        setSubmitEnabled(isValid);
    }

    function handleDateChange() {
        const $fields = $('#StartDate, #EndDate, #IsHalfDay');
        $fields.removeClass('input-validation-error');
        $fields.next('.field-validation-error').empty();
        $('#StartDate, #EndDate').valid();
    }

    function setSubmitEnabled(isValid) {
        if (isValid) {
            $submitButton.prop("disabled", false);
        } else {
            $submitButton.prop("disabled", true);
        }
    }

    function handleFormSubmit(event) {
        console.log("handleFormSubmit", event)
        event.preventDefault();

        $('#exceptionMessage').html('')

        const formPromise = $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize()
        });

        formPromise.done(function (result) {
            window.location.href = "/Leave/LeaveRequests"
        });

        formPromise.fail(function (jqXHR) {
            // Handle 400 error
            if (jqXHR.status === 400) {
                $formContainer.html(jqXHR.responseText);
                $.validator.unobtrusive.parse($formContainer);
            }

            else {
                // display error <a href="#"></a>
                $('#exceptionMessage')
                    .show()
                    .html(jqXHR.responseText)
            }

        });

        formPromise.then(loadLeaveRequests);
    }

    function loadLeaveRequests() {
        var leaveRequestsPromise = $.ajax({
            url: "/Leave/LeaveRequestsTable",
            type: "GET"
        });

        leaveRequestsPromise.done(function (result) {
            $('#leaveRequestsTable').html(result);
        });
    }
});