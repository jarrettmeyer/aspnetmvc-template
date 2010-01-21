$(function() {
    $(".update-note").live("click", function(event) {
        event.preventDefault();
        var form = $(this).parents("form");
        var url = form.attr("action");
        var contactId = $("input[name=ContactId]").val();
        var formData = form.serialize();
        $.ajax({
            type: "put",
            url: url,
            data: formData,
            success: function() { window.location = "/Contacts/" + contactId + "/Notes" ; }
        });
    });
});