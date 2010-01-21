$(function() {
    $(".delete-link").live("click", function(event) {
        event.preventDefault();
        var url = $(this).attr("href");
        if (!window.confirm("Are you sure?")) { return; }
        $.ajax({
            type: "DELETE",
            url: url,
            success: function() { window.location.reload(); }
        });
    });
});