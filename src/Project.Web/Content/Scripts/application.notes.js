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
    $(".delete-note").live("click", function(event) {
        event.preventDefault();
        var url = $(this).attr("href");
        var formData = $(this).parents("form").serialize();
        if (!window.confirm("You are about to delete a note. This is permanent and cannot be undone. Are you sure?")) { return; }
        $.ajax({
            type: "DELETE",
            url: url,
            data: formData,
            success: function() { window.location.reload(true); }
        });
    });
});