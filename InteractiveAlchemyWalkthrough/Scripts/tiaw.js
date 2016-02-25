$(document).ready(function () {
    $(".element").click(function () {
        $(".element").removeClass("selected").removeClass("ancestor");
        var $this = $(this);
        $this.addClass("selected");
        var ids = $this.data("ancestors");
        if (ids.length > 0){
            $('#' + ids.join(',#')).addClass("ancestor");
        }
    });
});