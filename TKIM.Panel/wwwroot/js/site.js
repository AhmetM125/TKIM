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

window.getFileBytes = async function (inputId) {
    //inputId: file input id
    debugger;
    return new Promise((resolve, reject) => {
        const fileInput = document.getElementById(inputId);
        console.log(fileInput);
        if (fileInput.files.length === 0) {
            console.log("No file selected.")
            reject("No file selected.");
            return;
        }

        const file = fileInput.files[0];
        const reader = new FileReader();

        reader.onload = function (e) {
            const fileBytes = new Uint8Array(e.target.result);
            resolve(fileBytes);
        };

        reader.onerror = function (error) {
            reject(error);
        };

        reader.readAsArrayBuffer(file);
    });
};
window.setImageGallery = async function (inputId, displayGallery) {
    //inputId: file input id, displayGallery: image gallery id
    return new Promise((resolve, reject) => {
        const fileInput = document.getElementById(inputId);
        var content = document.getElementById(displayGallery);
        const reader = new FileReader();
        content.innerHTML = "";

        var files = fileInput.files;

        if (fileInput.files.length === 0) {
            displayDiv.innerText = "No file selected";
            return;
        }

        for (var i = 0; i < files.length; i++) {
            var img = document.createElement('img');
            img.src = URL.createObjectURL(files[i]);
            img.style ="width:100px;height:100px;margin-left:30px"
            
            content.appendChild(img);
        }


        reader.onerror = function (error) {
            console.log("entered onerror")

            content.innerText = `Error reading file: ${error}`;
        };



        if (fileInput.files.length === 0) {
            console.log("No file selected.")
            return;
        }

    });
}