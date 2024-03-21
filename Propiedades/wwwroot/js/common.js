window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operación Correcta",
            {
                timeOut: 3000,
                positionClass: 'toast-top-center'
            });
    }
    if (type === "error") {
        toastr.error(message, "Operación Fallida",
            {
                timeOut: 3000,
                positionClass: 'toast-top-center'
            });
    }    
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Success Notification', message,'success'
        );
    }
    if (type === "error") {
        Swal.fire(
            'Error Notification', message, 'error'
        );
    }
}