$("a[data-toggle]").on("click", function (e) {
    var selector = $(this).data("toggle");
    if ($(selector).css('display') != 'block') {
        //$('form').hide();
        $('form').animate({ height: "hide", opacity: "hide" }, "slow");
    }
    $(selector).animate({ height: "toggle", opacity: "toggle" }, "slow");
});
