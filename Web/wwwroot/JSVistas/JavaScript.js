

    cargartabla();

    function cargartabla() {
        // Verificar si ya existe una instancia de DataTables y destruirla si es necesario
        if ($.fn.DataTable && $.fn.DataTable.isDataTable('#tablaPersonas')) {
            $('#tablaPersonas').DataTable().destroy();
        }

        $.ajax({
            url: '/Home/ObtenerListpersonayfrase',
            type: 'GET',
            success: function (response) {
                if (response.error) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: response.error
                    });
                    return;
                }

                $('#tablaPersonas').DataTable({
                    data: response.data,
                    columns: [
                        { data: 'nombre' },
                        { data: 'apellido' },
                        { data: 'edad' },
                        { data: 'frase' }
                    ],
                    order: [[0, 'asc']],
                    responsive: true,
                    dom: 'B',
                    searching: false,
                    buttons: [
                        {
                            text: "Nuevo",
                            className: "btn btn-primary",
                            action: function () {
                                $('#divTabla').hide();
                                $('#formulario').show();
                            }
                        },
                        { extend: 'excel' },
                        { extend: 'pdf' },
                        { extend: 'print' }
                    ],
                });
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    icon: 'error',
                    title: 'Error en la solicitud AJAX',
                    text: error
                });
            }
        });
    }



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
                if (response.success) {
                    swal.fire({
                        icon: 'success',
                        title: 'éxito',
                        text: 'La persona y la frase se agregaron ',
                        showconfirmbutton: true, // muestra el botón "ok"
                    }).then(function () {
                        $('#formulario').hide();
                        $('#tablaPersonas').datatable().ajax.reload();
                        $('#divTabla').show();
                        /* limpiar el formulario*/
                        //    $('#agregarcolaboradorycontrato')[0].reset();
                    });
                } else {
                    swal.fire({
                        icon: 'error',
                        title: 'error',
                        text: response.error || 'hubo un error al agregar el colaborador y contrato'
                    });
                }
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
