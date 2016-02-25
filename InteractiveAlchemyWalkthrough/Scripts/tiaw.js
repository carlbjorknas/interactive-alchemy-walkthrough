$(document).ready(function () {
    $(".element").click(function () {
        $(".element")
            .removeClass("selected")
            .removeClass("ancestor")
            .removeClass("descendent");

        var $this = $(this);
        $this.addClass("selected");

        var ancestorIds = $this.data("ancestors");
        if (ancestorIds.length > 0) {
            $('#' + ancestorIds.join(',#')).addClass("ancestor");
        }

        var descendentIds = $this.data("descendents");
        if (descendentIds.length > 0) {
            $('#' + descendentIds.join(',#')).addClass("descendent");
        }
    });
});