$(function () {
    $(document).bind("contextmenu", function (e) {
        return false;
    });

});


function RevaluoModal() {
    $('#RevaluoModal').modal('show');
    return false;
}