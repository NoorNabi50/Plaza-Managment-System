function ErrorAlert(Message) {
    Swal.fire({
        title: Message,
        html: '<i class="icon-cross3  error icon-2x"></i> Record Not Found',
       
        showConfirmButton: false,
        position: 'center',
        timer: 2600,
        timerProgressBar: true,
        width: '300px',
        background: 'rgba(255,255,255)'
    });
}

function SuccessAlert(Message) {
    Swal.fire({
        title: '',
        html: '<i class="icon-checkmark4 success icon-2x"></i> Successful',
       
        showConfirmButton: false,
        position: 'center',
        timer: 3500,
        timerProgressBar: true,
        width: '300px',
        background: 'rgba(255,255,255)'
    });
}

function DeleteAlert() {

    Swal.fire({
        title: 'Are you sure?',
        text: ' You won"t be able to revert this!',
        timer: 3500,
        timerProgressBar: true,
        showCancelButton: true,
        allowOutsideClick: false,
        confirmButtonText: '<i class="icon-bin icon-1x"></i> Delete',
        cancelButtonText: '<i class="icon-cross3 icon-1x"></i> Cancel',
        confirmButtonColor: 'Red',
        cancelButtonColor: 'Green',
    });
}


function SavedAlert(message) {
    Swal.fire({
        

        title: message,

        icon: 'success',
        timer: 2000
    })


}