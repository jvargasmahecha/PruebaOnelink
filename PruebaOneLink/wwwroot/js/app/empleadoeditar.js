$(document).ready(function () {
    var empleadoEditar = $("#empleadoEditar")
    if (empleadoEditar.length <= 0)
        return;
    //INICIO
    cargarAreas();
    cargarTipoDocumentos();
    cargarDatos();

    //EVENTOS JQUERY
    $("#Area").change(function () {
        var id = $("#Area").val();
        limpiarSubAreas();
        consultarSubAreasByAreaId(id);
    });
    $("#btnEditar").click(function () {
        var EMId = $("#EMId").val();
        var EMTipoDocumentoId = $("#EMTipoDocumentoId").val();
        var EMNombre = $("#EMNombre").val();
        var EMApellido = $("#EMApellido").val();
        var EMSubAreaId = $("#EMSubAreaId").val();

        if (EMTipoDocumentoId == "") {
            alert('Debe seleccionar el tipo de documento');
            return;
        }

        if (EMNombre == "") {
            alert('Debe ingresar el nombre');
            return;
        }

        if (EMApellido == "") {
            alert('Debe ingresar el apellido');
            return;
        }

        if (EMSubAreaId == "") {
            alert('Debe seleccionar la subarea');
            return;
        }

        var empleado = {
            EMId: EMId,
            EMTipoDocumentoId: EMTipoDocumentoId,
            EMNombre: EMNombre,
            EMApellido: EMApellido,
            EMSubAreaId: EMSubAreaId
        }
        debugger
        guardarEmpleado(empleado);
    });

    //FUNCIONES
    //traerme area desde la base de datos 
    function cargarAreas() {
        $.ajax({
            method: "GET",
            url: "http://localhost:4170/Area/Get"
        }).done(function (data) {
            if (data.length > 0) {
                var id = data[0].arId;
                consultarSubAreasByAreaId(id);
            }
            agregarOpcionesArea(data);
        }).fail(function () {
            alert("Algo salió mal");
        });
    }

    //traerme tipoDocumento desde la base de datos, llama la funcion agregarOpciones
    function cargarTipoDocumentos() {
        $.ajax({
            method: "GET",
            url: "http://localhost:4170/TipoDocumento/Get"
        }).done(function (data) {
            agregarOpciones(data);
        }).fail(function () {
            alert("Algo salió mal");
        });
    }

    //cargar datos del empleado desde la base de datos
    function cargarDatos() {
        var pathname = window.location.pathname.split("/");
        var id = pathname[pathname.length - 1];
        $.ajax({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            url: "http://localhost:4170/Empleado/GetById/" + id
        }).done(function (data) {
            if (data.length <= 0) {
                alert('El ususario con id ' + id + ' no extste');
                window.location.replace("http://localhost:4170/Empleado/");
            }
            else {
                asignarDatos(data[0])
            }
        }).fail(function () {
            alert("Algo salió mal");
        });
    }


    //limpiar subareas con remove se realiza para borrar las subareas existentes y poner las nuevas 
    function limpiarSubAreas() {
        $('#EMSubAreaId')
            .find('option')
            .remove();
    }

    //pintar todos los datos del empleado en los identificadores  #....
    function asignarDatos(empleado) {
        $("#EMTipoDocumentoId").val(empleado.emTipoDocumentoId);
        $("#EMDocumento").val(empleado.emDocumento);
        $("#EMId").val(empleado.emId);
        $("#EMNombre").val(empleado.emNombre);
        $("#EMApellido").val(empleado.emApellido);
        $("#Area").val(empleado.arId);

        //consulta las subareas con el id del area que devuelve el proedimiento almacenado
        $.ajax({
            method: "GET",
            url: "http://localhost:4170/SubArea/GetByAreaId/" + empleado.arId
        }).done(function (data) {
            //se agnan los datos  emSubAreaId a #EMSubAreaId
            limpiarSubAreas();
            agregarOpcionesSubArea(data);
            $("#EMSubAreaId").val(empleado.emSubAreaId);
        }).fail(function () {
            alert("Algo salió mal");
        });        
    }

    //pintar tipo de documento en el select #EMTipoDocumentoId
    function agregarOpciones(registros) {
        var EMTipoDocumentoId = $("#EMTipoDocumentoId");
        $.each(registros, function (key, value) {
            EMTipoDocumentoId.append(`<option value="` + value.tdId + `">` + value.tdNombre + `</option>`);
        });
    }

    //pintar area en el select #Area
    function agregarOpcionesArea(registros) {
        var Area = $("#Area");
        $.each(registros, function (key, value) {
            Area.append(`<option value="` + value.arId + `">` + value.arNombre + `</option>`);
        });
    }

    //consulta subarea por areaid cuando termina la consulta llama la funcion agregarOpcionesSubArea(data);
    function consultarSubAreasByAreaId(areaId) {
        $.ajax({
            method: "GET",
            url: "http://localhost:4170/SubArea/GetByAreaId/" + areaId
        }).done(function (data) {
            agregarOpcionesSubArea(data);
        }).fail(function () {
            alert("Algo salió mal");
        });
    }

    //pinta subarea en el select #EMSubAreaId 
    function agregarOpcionesSubArea(registros) {
        var EMSubAreaId = $("#EMSubAreaId");
        $.each(registros, function (key, value) {
            EMSubAreaId.append(`<option value="` + value.saId + `">` + value.saNombre + `</option>`);
        });
    }   

    
    
    //registrar empleado en la base de datos 
    function guardarEmpleado(empleado) {
        $.ajax({
            method: "POST",
            contentType: "application/json; charset=utf-8",
            url: "http://localhost:4170/Empleado/Update",
            data: JSON.stringify(empleado)
        }).done(function (data) {
            alert('Actualizacion correcta');
            window.location.replace("http://localhost:4170/Empleado/");
        }).fail(function () {
            alert("Algo salió mal");
        });
    }

});