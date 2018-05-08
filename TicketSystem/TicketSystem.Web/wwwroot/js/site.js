function changeCheckedValue(id) {
    if ($("#" + id).is(':checked')) {
        $("#" + id).attr('value', 'true');
    } else {
        $("#" + id).attr('value', 'false');
    }
}

function toggleHelpBars(id) {
    $('.to-be-toggled').each(function () {
        if ($(this).attr('id') === id) {
            $(this).slideToggle(300);
        } else {
            $(this).hide(300);
        }
    });
};

$(document).click(function () {
    var $el = $(".to-be-toggled");
    if ($el.is(":visible")) {
        $el.hide(300);
    }
});


