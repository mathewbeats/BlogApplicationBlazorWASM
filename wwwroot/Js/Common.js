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
// Referencia global al editor para poder acceder desde otras funciones
window.quillEditor = null;

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

    // Si ya existe una instancia de Quill, primero desvincula el evento 'text-change'
    if (window.quillEditor) {
        window.quillEditor.off('text-change');
    }

    // Inicializa Quill y guarda la referencia
    window.quillEditor = new Quill('#editor', options);
    // Establece el contenido usando la API de Quill
    window.quillEditor.setText(content);
};



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
