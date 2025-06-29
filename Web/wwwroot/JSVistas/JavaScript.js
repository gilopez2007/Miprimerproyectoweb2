
//document.getElementById("unico").onclick = function () {

    

//    console.log(NaN === NaN); // Output: false
//    console.log(+0 === -0); // Output: true


//    Swal.fire({
//        title: "Calculadora",
//        text: "Tu resultado es: " + suma + " El resultado de la resta es: " + resta + " El resultado de la multi es: " + multi + " El resultado de la divi es: " + divi,
//        imageUrl: "https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExdTNndmtncmFhdDN3dnV2OG1lenZudmsxNHE4MmNjYzA1dzF3a2I3eSZlcD12MV9naWZzX3NlYXJjaCZjdD1n/sgQnvuFJZVKUg/200.webp",
//        imageWidth: 400,
//        imageHeight: 200,
//        imageAlt: "Custom image"
//    });

//}

$('#btnguardarpersonas').on('click', function () {
    var nombre = $('#nombres').val();
    var apellido = $('#apellidos').val();
    var edad = $('#edad').val();
    var frase = $('#frase').val();
    console.log("El nombre de la persona es: ", nombre); 

    var personas = {
        Nombre: nombre,
        Apellido: apellido,
        Edad: edad,
        Frase: frase
    };

    $.ajax({
        url: '/Home/Agregarpersonayfrase',
        type: 'POST',
        data: personas,
        success: function (response) {
            //if (response.success) {
            //    Swal.fire({
            //        icon: 'success',
            //        title: 'Éxito',
            //        text: 'El Colaborador y contrato se agregaron exitosamente',
            //        showConfirmButton: true, // Muestra el botón "OK"
            //    }).then(function () {
            //        $('#DivAgregarColaborador').hide();
            //        $('#TablaDeColavboradores').DataTable().ajax.reload();
            //        $('#DivTablaColaboradores').show();
            //        // Limpiar el formulario
            //        $('#AgregarColaboradorYcontrato')[0].reset();
            //    });
            //} else {
            //    Swal.fire({
            //        icon: 'error',
            //        title: 'Error',
            //        text: response.error || 'Hubo un error al agregar el Colaborador y contrato'
            //    });
            //}
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Hubo un error al enviar el formulario'
            });
        }
    }); 
    
});