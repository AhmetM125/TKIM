//Modal Open/Close

window.openModal = (id) => {
    $("#" + id).modal();
    $("#" + id).modal('show');
}

window.closeModal = (id) => {
    if ($(".modal.show").length <= 1) {
        $("body").removeClass("modal-open-main");

    }
    else {
        $("body").addClass("modal-open-main");

    }

    $("#" + id).modal('hide');
    const div = $('.modal-backdrop.fade.show');
    $("body").removeClass("modal-opend");

}
//End Modal Open/Close

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})