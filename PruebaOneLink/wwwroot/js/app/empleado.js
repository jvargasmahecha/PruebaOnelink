$(document).ready(function () {    
    var empleadoIndex = $("#empleadoIndex");
    if (empleadoIndex.length<=0)
        return;
    var tblEmpleado = $("#tblEmpleado");
    //INICIO
    cargarEmpleados();

    //EVENTOS JQUERY
    $('#btnCancelar').click(function () {
        $("#txtBusqueda").val("");
        cargarEmpleados();
    });
    $("#btnBuscar").click(function () {
        var busqueda = $("#txtBusqueda").val();
        if (busqueda == "") {
            cargarEmpleados();
        }
        buscarEmpleados(busqueda);
    });


    //FUNCIONES

    //Cargar empleados desde la base de datos
    function cargarEmpleados()
    {        
        $.ajax({
            method: "GET",
            url: "http://localhost:4170/Empleado/Get"
        }).done(function (data) {            
            $('#tblEmpleado tr').remove();
            crearFilas(data); 
        }).fail(function () {
            alert("Algo salió mal");
        });
    }

    //pintar las fulas e inyecta los datos a cada td 
    function crearFilas(registros)
    {
        $.each(registros, function (key, value) {
            var fila = `<tr>
                            <td>`+ value.emId + `</td >
                            <td>`+ value.emNombre + `</td >
                            <td>`+ value.emApellido + `</td >
                            <td>`+ value.emDocumento + `</td >
                            <td>`+ value.tdNombre + `</td >
                            <td>`+ value.arNombre + `</td >
                            <td>`+ value.saNombre + `</td >                                    
                            <td><a class="btn btn-primary width-100" href="/Empleado/Edit/`+ value.emId + `" role="button">Editar</a></td > 
                        </tr >`;
            tblEmpleado.append(fila)
            console.log(value.emNombre);
        });
    }
   
    //consulta de empleados por nombre o id a la base de datos 
    function buscarEmpleados(busqueda)
    {
        var data = {Busqueda:busqueda};
        $.ajax({
            method: "POST",
            contentType: "application/json; charset=utf-8",
            url: "http://localhost:4170/Empleado/GetByDocumentoOrNombre",
            data: JSON.stringify(data)
        }).done(function (data) {
            $('#tblEmpleado tr').remove();
            crearFilas(data);
        }).fail(function () {
            alert("Algo salió mal");
        });
    }
   
    
});
