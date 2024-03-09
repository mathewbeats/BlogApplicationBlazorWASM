// Funciones para mostrar notificaciones con Toastr
window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operación Correcta", { timeOut: 10000 });
    } else if (type === "error") {
        toastr.error(message, "Operación Fallida", { timeOut: 10000 });
    }
};

// Función para inicializar el carrusel de Bootstrap
window.initializeCarousel = function () {
    $('.carousel').carousel({
        interval: 3000,
        wrap: true
    });
};

// Configuración e inicialización de Quill (Editor de texto enriquecido)
// Función para inicializar Quill con contenido editable
window.initializeQuill = (content) => {
    var options = {
        debug: 'info',
        modules: {
            toolbar: '#toolbar'
        },
        placeholder: 'Compose an epic...',
        readOnly: false, // Cambiar a false para permitir la edición del texto
        theme: 'snow'
    };
    var editor = new Quill('#editor', options);
    // Establecer el contenido del editor con el texto a editar
    editor.root.innerHTML = content;
};

// Método de configuración personalizada de QuillJS
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
};

// Función para desvincular el evento de cambio de texto en Quill
window.unBindToQuillTextChangeEvent = () => {
    // Primero, obtén una referencia al editor Quill
    var quill = document.querySelector('#editor');

    // Verifica si el editor Quill existe y si el evento 'text-change' está vinculado
    if (quill && quill._events && quill._events['text-change']) {
        // Desvincula el evento 'text-change' utilizando el método 'off' de Quill
        quill.off('text-change');
    }
};


//window.initializeQuill = () => {
//    var options = {
//        debug: 'info',
//        modules: {
//            toolbar: '#toolbar'
//        },
//        placeholder: 'Compose an epic...',
//        readOnly: true,
//        theme: 'snow'
//    };
//    var editor = new Quill('#editor', options);
//};

//// Método de configuración personalizada de QuillJS
//window.myComponent = {
//    configureQuillJs: () => {
//        var link = Quill.import("formats/link");
//        link.sanitize = url => {
//            let newUrl = window.decodeURIComponent(url);
//            newUrl = newUrl.trim().replace(/\s/g, "");

//            if (/^(:\/\/)/.test(newUrl)) {
//                return `http${newUrl}`;
//            }
//            if (!/^(f|ht)tps?:\/\//i.test(newUrl)) {
//                return `http://${newUrl}`;
//            }
//            return newUrl;
//        }
//    }
//};

// Funciones para mostrar y ocultar modales con SweetAlert
window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire('Success Notification', message, 'success');
    } else if (type === "error") {
        Swal.fire('Error Notification', message, 'error');
    }
};

// Funciones para manejar la visibilidad de modales de Bootstrap
function MostrarModalConfirmacionBorrado() {
    $('#modalConfirmacionBorrado').modal('show');
}

function OcultarModalConfirmacionBorrado() {
    $('#modalConfirmacionBorrado').modal('hide');
}

// Asegúrate de llamar a initializeQuill en el lugar adecuado para iniciar Quill correctamente.
// Por ejemplo, puedes llamarlo desde el método OnAfterRenderAsync de tu componente Blazor,
// o después de que el DOM esté completamente cargado.
