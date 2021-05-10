$(document).ready(function () {

    var empleadoIndex = $("#empleadoIndex");
    if (empleadoIndex.length<=0)
        return;
    var tblEmpleado = $("#tblEmpleado");

    function cargarEmpleados()
    {
        $.ajax({
            method: "GET",
            url: "http://localhost:4170/Empleado/Get"
        }).done(function (data) {
            crearFilas(data); 
        }).fail(function () {
            alert("Algo salió mal");
        });
    }

    function crearFilas(registros)
    {
        $.each(registros, function (key, value) {
            tblEmpleado.append(`<tr>
                                    <td>`+ value.emId +`</td >
                                    <td>`+ value.emNombre +`</td >
                                    <td>`+ value.emApellido +`</td >
                                    <td>`+ value.emDocumento +`</td >
                                    <td>`+ value.tdNombre +`</td >
                                    <td>`+ value.arNombre +`</td >
                                    <td>`+ value.saNombre +`</td >                                    
                                    <td><a class="btn btn-primary width-100" href="/Empleado/Edit/`+ value.emId +`" role="button">Editar</a></td > 
                                </tr >`)
            console.log(value.emNombre);
        });
    }
    cargarEmpleados();
    console.log("ready!");
});