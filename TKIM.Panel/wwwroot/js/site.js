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
    return new Promise((resolve, reject) => {
        const fileInput = document.getElementById(inputId);
        if (!fileInput || fileInput.files.length === 0) {
            /*reject("No file selected.");*/
            resolve([]);
            return;
        }

        const files = fileInput.files;
        const fileReaders = [];

        for (const file of files) {
            const reader = new FileReader();
            const filePromise = new Promise((res, rej) => {
                reader.onload = (e) => {
                    const arrayBuffer = e.target.result;
                    // Convert ArrayBuffer to Base64 string
                    const base64String = btoa(
                        new Uint8Array(arrayBuffer).reduce((data, byte) => data + String.fromCharCode(byte), '')
                    );
                    res({
                        base64: base64String,
                        type: file.type, // MIME type
                        size: file.size, // File size in bytes
                        name: file.name  // File name (optional, useful for display)
                    });
                };

                reader.onerror = (error) => {
                    rej(error);
                };

                reader.readAsArrayBuffer(file); // Read as ArrayBuffer
            });

            fileReaders.push(filePromise);
        }

        // Wait for all file reads to complete and return as an array of base64 strings
        Promise.all(fileReaders).then(resolve).catch(reject);
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