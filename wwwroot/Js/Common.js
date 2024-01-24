


window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operación Correcta", { timeOut: 10000 });
    }
    if (type === "error") {
        toastr.error(message, "Operación Fallida", { timeOut: 10000 });
    }
   
    

}

window.initializeCarousel = function () {
    $('.carousel').carousel({
        interval: 3000,
        wrap: true
    });
}




var editor = new Quill('.editor');  // First matching element will be used
var container = document.getElementById('editor');
var editor = new Quill(container);
var container = $('.editor').get(0);
var editor = new Quill(container);


var options = {
    debug: 'info',
    modules: {
        toolbar: '#toolbar'
    },
    placeholder: 'Compose an epic...',
    readOnly: true,
    theme: 'snow'
};
var editor = new Quill('#editor', options);





window.showModal = function (modalId) {
    var modalElement = document.getElementById(modalId);
    var modal = new bootstrap.Modal(modalElement);
    modal.show();
};


 /*Define this configuration in a javascript file*/
window.myComponent = {
    configureQuillJs: () => {
        var link = Quill.import("formats/link");

        link.sanitize = url => {
            let newUrl = window.decodeURIComponent(url);
            newUrl = newUrl.trim().replace(/\s/g, "");

            if (/^(:\/\/)/.test(newUrl)) {
                return `http${newUrl}`;
            }

            if (!/^(f|ht)tps?:\/\//i.test(newUrl)) {
                return `http://${newUrl}`;
            }

            return newUrl;
        }
    }
}



window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Success Notification',
            message,
            'success'
        );
    }
    if (type === "error") {
        Swal.fire(
            'Error Notification',
            message,
            'error'
        );
    }
}

function MostrarModalConfirmacionBorrado() {
    $('#modalConfirmacionBorrado').modal('show');
}

function OcultarModalConfirmacionBorrado() {
    $('#modalConfirmacionBorrado').modal('hide');
}

// En tu archivo common.js





