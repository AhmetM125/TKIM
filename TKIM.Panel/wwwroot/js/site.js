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
window.setImageGallery = async function (inputId, displayGalleryId) {
    //inputId: file input id, displayGallery: image gallery id
    return new Promise((resolve, reject) => {
        const fileInput = document.getElementById(inputId);
        const displayGallery = document.getElementsByClassName('carousel-inner')[0];
        console.log(displayGallery);

        // Clear previous gallery content
        displayGallery.innerHTML = "";

        if (!fileInput.files || fileInput.files.length === 0) {
            displayGallery.innerText = "No files selected.";
            resolve(); // Resolve the promise even if no files are selected
            return;
        }

        const files = fileInput.files;

        for (const file of files) {
            const reader = new FileReader();

            // Create an image element for each file
            const img = document.createElement('img');
            const div = document.createElement('div');
            div.className = "carousel-item d-block w-100";
            div.style= "height: 1000px;max-height:1000px;";
            img.className = "width-90 d-block mx-auto h-100";
            img.alt = "Product Image";
            div.appendChild(img);
            reader.onload = (event) => {
                img.src = event.target.result;

                // Append the image to the gallery
                displayGallery.appendChild(div);
            };

            reader.onerror = (error) => {
                console.error(`Error reading file: ${error}`);
                displayGallery.innerText = `Error reading file: ${error}`;
                reject(error); // Reject the promise on error
            };

            // Read the file as a Data URL (base64)
            reader.readAsDataURL(file);
        }

        resolve(true); // Resolve the promise once processing is done
    });
}