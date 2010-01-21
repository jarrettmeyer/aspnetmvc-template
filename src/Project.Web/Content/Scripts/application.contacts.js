$(function() {
    $(".update-contact").live("click", function(event) {
        event.preventDefault();
        var form = $(this).parents("form");
        var url = form.attr("action");
        var formData = form.serialize();
        $.ajax({
            type: "put",
            url: url,
            data: formData,
            success: function() { window.location = "/Contacts"; }
        });
    });
});