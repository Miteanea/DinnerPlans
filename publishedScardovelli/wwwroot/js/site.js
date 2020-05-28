// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function HandleBooking(postUrl) {

    var model = {
        Session: null,
        UserName: ""
    };

    if ($('input[name="Session"]:checked').val()) {
        model.Session = $('input[name="Session"]:checked').val();
    }

    model.UserName = $('#userName').val();

    if (model.UserName && model.Session) {

        $.ajax({
            url: postUrl,
            data: model,
            success: function () {
                window.location.href = indexUrl;
            },
            error: function () {
                alert('error');
            }
        });
    }

}