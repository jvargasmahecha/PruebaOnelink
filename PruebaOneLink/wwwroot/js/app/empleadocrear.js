$(document).ready(function () {
    var empleadoCrear = $("#empleadoCrear")
    if (empleadoCrear.length <= 0)
        return;

    cargarAreas();
    cargarTipoDocumentos();

    function agregarOpciones(registros) {
        var EMTipoDocumentoId = $("#EMTipoDocumentoId");
        $.each(registros, function (key, value) {
            EMTipoDocumentoId.append(`<option value="` + value.tdId + `">` + value.tdNombre + `</option>`);
        });
    }

    function agregarOpcionesArea(registros) {
        var Area = $("#Area");
        $.each(registros, function (key, value) {
            Area.append(`<option value="` + value.arId + `">` + value.arNombre + `</option>`);
        });
    }

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
    function agregarOpcionesSubArea(registros) {
        var EMSubAreaId = $("#EMSubAreaId");
        $.each(registros, function (key, value) {
            EMSubAreaId.append(`<option value="` + value.saId + `">` + value.saNombre + `</option>`);
        });
    }
    $("#Area").change(function () {
        var id = $("#Area").val();
        $('#EMSubAreaId')
            .find('option')
            .remove();
        consultarSubAreasByAreaId(id);
    });

    function cargarTipoDocumentos()
    {
        $.ajax({
            method: "GET",
            url: "http://localhost:4170/TipoDocumento/Get"
        }).done(function (data) {
            agregarOpciones(data);
        }).fail(function () {
            alert("Algo salió mal");
        });
    }

    function cargarAreas()
    {
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
    $("#btnCrear").click(function () {
        var EMTipoDocumentoId = $("#EMTipoDocumentoId").val();
        var EMDocumento = $("#EMDocumento").val();
        var EMNombre = $("#EMNombre").val();
        var EMApellido = $("#EMApellido").val();
        var EMSubAreaId = $("#EMSubAreaId").val();
       
        if (EMTipoDocumentoId == "") {
            alert('Debe seleccionar el tipo de documento');
            return;
        }

        if (EMDocumento == "") {
            alert('Debe ingresar el docuento');
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
            EMTipoDocumentoId: EMTipoDocumentoId,
            EMDocumento: EMDocumento,
            EMNombre: EMNombre,
            EMApellido: EMApellido,
            EMSubAreaId: EMSubAreaId
        }

        $.ajax({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            url: "http://localhost:4170/Empleado/GetByDocument/" + EMDocumento
        }).done(function (data) {
            if (data.length > 0) {
                alert("El documento ya existe");
            } else {
                guardarEmpleado(empleado);
            }
        }).fail(function () {
            alert("Algo salió mal");
        });        
    });

    function guardarEmpleado(empleado) {
        $.ajax({
            method: "POST",
            contentType: "application/json; charset=utf-8",
            url: "http://localhost:4170/Empleado/Create",
            data: JSON.stringify(empleado)
        }).done(function (data) {
            alert('Insercion correcta');
            window.location.replace("http://localhost:4170/Empleado/");
        }).fail(function () {
            alert("Algo salió mal");
        }); 
    }


});