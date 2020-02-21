$(document).ready(function () {
    // Desarrollo
    var rutaAplicacion = "http://localhost:52994"
    // Produccion
    //var rutaAplicacion = "http://pelma3w8pap10v/cmdb"

    $(".fecha").datepicker({ dateFormat: 'dd/mm/yy' });

    function isValidEmailAddress(emailAddress) {
        var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
        return pattern.test(emailAddress);
    };

    //$("#txtFechaProdProy").datepicker({ dateFormat: 'dd/mm/yy' });
    $("#btnEnviar").click(function () {
        if ($.trim($("#txtUsuario").val()) == "") {
            alert("Ingrese un usuario");
            return;
        }
        if ($.trim($("#txtClave").val()) == "") {
            alert("Ingrese una clave");
            return;
        }
        $("#frmAcceso").submit();
    });

    // Proyecto
    $("#btnCrearProyecto").click(function () {
        if ($.trim($("#txtCodigoProyecto").val()) == "") {
            alert("Ingrese un código de proyecto");
            return;
        }
        if ($.trim($("#txtNombreProyecto").val()) == "") {
            alert("Ingrese un nombre de proyecto");
            return;
        }
        if ($("#chkfechaprodproy").is(":checked") && $.trim($("#txtFechaProdProy").val()) == "") {
            alert("Especifica una fecha de pase a produccion");
            return;
        }
        if ($("#cboResponsable").val() == "0") {
            alert("Especifique una gerencia");
            $("#cboResponsable").focus();
            return;
        }
        if ($("#cboTipoProyecto").val() == "0") {
            alert("Especifique un tipo de proyecto");
            $("#cboTipoProyecto").focus();
            return;
        }

        if ($("#chkMejora").is(":checked")) {
            if ($.trim($("#txtImpacto").val()) == "") {
                alert("Especifique el impacto de la mejora");
                $("#txtImpacto").focus();
                return;
            }
        }
        if ($.trim($("#txtCodigoPresupuestal").val()) == "") {
            alert("Especifique un codigo presupuestal");
            $("#txtCodigoPresupuestal").focus();
            return;
        }
        var existeFechaAmbiente = true;
        $(".obligatorio").each(function () {
            if (!this.checked) {
                var nombreAmbiente = $(this).attr("data-ambiente");
                alert("El proyecto " + $.trim($("#txtNombreProyecto").val()) + " debe tener especificado una fecha de pase para el ambiente " + nombreAmbiente + ".");
                existeFechaAmbiente = false;
                return;
            }
        });
        if (!existeFechaAmbiente) {
            return;
        }
        $("#frmNuevoProyecto").submit();
    });
    $("#btnConsultarProyecto").click(function () {
        $("#frmCatalogoProyecto").submit();
    });
    $("#btnActualizarProyecto").click(function () {
        if ($.trim($("#txtCodigoProyecto").val()) == "") {
            alert("Ingrese un código de proyecto");
            return;
        }
        if ($.trim($("#txtNombreProyecto").val()) == "") {
            alert("Ingrese un nombre de proyecto");
            return;
        }
        if ($("#chkfechaprodproy").is(":checked") && $.trim($("#txtFechaProdProy").val()) == "") {
            alert("Especifica una fecha de pase a produccion");
            return;
        }
        if ($("#cboResponsable").val() == "0") {
            alert("Especifique una gerencia");
            $("#cboResponsable").focus
            return;
        }
        if ($("#cboTipoProyecto").val() == "0") {
            alert("Especifique un tipo de proyecto");
            $("#cboTipoProyecto").focus();
            return;
        }
        if ($("#chkMejora").is(":checked")) {
            if ($.trim($("#txtImpacto").val()) == "") {
                alert("Especifique el impacto de la mejora");
                $("#txtImpacto").focus();
                return;
            }
        }
        if ($.trim($("#txtCodigoPresupuestal").val()) == "") {
            alert("Especifique un codigo presupuestal");
            $("#txtCodigoPresupuestal").focus();
            return;
        }
        var existeFechaAmbiente = true;
        $(".obligatorio").each(function () {
            if (!this.checked) {
                var nombreAmbiente = $(this).attr("data-ambiente");
                alert("El proyecto " + $.trim($("#txtNombreProyecto").val()) + " debe tener especificado una fecha de pase para el ambiente " + nombreAmbiente + ".");
                existeFechaAmbiente = false;
                return;
            }
        });
        if (!existeFechaAmbiente) {
            return;
        }
        var continuar = true;
        $(".correo").each(function () {
            if (!isValidEmailAddress($(this).val())) {
                alert("El correo " + $(this).val() + " no es un correo v\u00E1lido, por favor corregir.");
                continuar = false;
            }
        });
        if (continuar) {
            $("#frmDatosProyecto").submit();
        }
    });
    $("#chkfechaprodproy").click(function () {
        if ($(this).is(":checked")) {
            $("#txtFechaProdProy").prop("disabled", false);
            $("#txtFechaProdProy").datepicker("enable");
            $("#txtFechaProdProy").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#txtFechaProdProy").focus();
        } else {
            $("#txtFechaProdProy").val("");
            $("#txtFechaProdProy").prop("disabled", true);
            $("#txtFechaProdProy").datepicker("disable");
        }
    });
    $("#tabs").tabs();
    $("#btnAgregarAplicacion").click(function () {
        var filas = $("#tblAplicaciones tbody tr").length;
        filas = filas + 1;
        $("#tblAplicaciones > tbody:last").append('<tr><td><input type="hidden" name="hdId' + filas + '" id="hdId' + filas + '" value="" /><input type="hidden" class="eliminadoapp" name="eliminadoapp' + filas + '" id="eliminadoapp' + filas + '" value="0" /><input type="checkbox" class="app" name="' + filas + '" id="' + filas + '" /></td><td><input type="text" class="form-control" name="nombreapp' + filas + '"/></td><td><input type="text" class="form-control" name="svnapp' + filas + '"/></td><td><input type="text" class="form-control" name="ideapp' + filas + '"/></td><td><input type="text" class="form-control" name="versionapp' + filas + '"/></td><td><select class="form-control" name="estadoapp' + filas + '"><option value="D">Desarrollo</option><option value="T">Test</option><option value="P">Produccion</option></select></td></tr>');
    });
    $("#btnQuitarAplicacion").click(function () {
        $("input:checkbox.app").each(function () {
            if (this.checked == true) {
                var registro = $(this).attr("name");
                // Determinar el id del hidden que contiene el valor de eliminado
                $("#eliminadoapp" + registro).attr("value", "1");
                $(this).closest("tr").css("display", "none");
            }
        });
    });
    $("#btnAgregarDesarrollador").click(function () {
        var filas = $("#tblDesarrolladores tbody tr").length;
        filas = filas + 1;
        $("#tblDesarrolladores > tbody:last").append('<tr><td><input type="hidden" class="iddes" name="iddes' + filas + '" id="iddes' + filas + '" value="" /><input type="hidden" class="nuevo" name="nuevo' + filas + '" id="nuevo' + filas + '" value="1" /><input type="hidden" class="eliminadodes" name="eliminadodes' + filas + '" id="eliminadodes' + filas + '" value="0" /><input type="checkbox" class="des" name="' + filas + '" id="' + filas + '" /></td><td><input type="text" class="usuariodes form-control" name="usuariodes' + filas + '"/></td><td><input type="hidden" class="nombredes" name="nombredes' + filas + '" /><span class="nombredes"/></td><td><input type="hidden" class="correodes" name="correodes' + filas + '" /><span class="correodes" /></td></tr>');
        autocompletarDesarrollador();
    });
    $("#btnQuitarDesarrollador").click(function () {
        $("input:checkbox.des").each(function () {
            if (this.checked == true) {
                var registro = $(this).attr("name");
                // Determinar el id del hidden que contiene el valor de eliminado
                $("#eliminadodes" + registro).attr("value", "1");
                $(this).closest("tr").css("display", "none");
            }
        });
    });
    $("#chkMejora").on("click", function () {
        if (this.checked) {
            $(".impacto").css("display", "block");
        } else {
            $(".impacto").css("display", "none");
        }
    });
    $(".chkAmbiente").on("click", function () {
        var id = $(this).attr("id");
        var ambienteId = id.substring(11);
        var fecha = ObtenerFecha();
        if (this.checked) {
            $("#txtFecha" + ambienteId).removeAttr("disabled");
            $("#txtFecha" + ambienteId).val(fecha);
            $("#txtFecha" + ambienteId).focus();
        }
        else {
            $("#txtFecha" + ambienteId).attr("disabled", "disabled");
            $("#txtFecha" + ambienteId).val("");
        }
    });
    $("#btnAgregarProyectoCorreo").click(function () {
        var filas = $("#tblNotificacion tbody tr").length;
        filas = filas + 1;
        $("#tblNotificacion > tbody:last").append('<tr><td><input type="hidden" name="hdCorreo' + filas + '" id="hdCorreo' + filas + '" value="" /><input type="hidden" class="eliminadoCorreo" name="eliminadoCorreo' + filas + '" id="eliminadoCorreo' + filas + '" value="0" /><input class="checkCorreo" type="checkbox" name="proyectocorreo' + filas + '" id="proyectocorreo' + filas + '" /></td><td><input type="email" class="form-control correo" name="proyectocorreonombre' + filas + '"/></td></tr>');
        $(".mensaje").html("");
    });
    $("#btnQuitarProyectoCorreo").click(function () {
        var prefijo = "proyectocorreo";
        $("input:checkbox.checkCorreo").each(function () {
            if (this.checked == true) {
                var registro = $(this).attr("name");
                var indice = registro.substring(prefijo.length);
                // Determinar el id del hidden que contiene el valor de eliminado
                $("#eliminadoCorreo" + indice).attr("value", "1");
                $(this).closest("tr").css("display", "none");
            }
        });
    });

    // Desarrollador
    $("#btnCrearDesarrollador").click(function () {
        if ($.trim($("#txtNombreDesarrollador").val()) == "") {
            alert("Ingrese un nombre para el desarrollador");
            return;
        }
        if ($.trim($("#txtUsuarioDesarrollador").val()) == "") {
            alert("Ingrese un usuario de Subversion para el Desarrollador");
            return;
        }
        if ($.trim($("#txtClaveDesarrollador").val()) == "") {
            alert("Ingrese una clave de Subversion para el Desarrollador");
            return;
        }
        if ($.trim($("#txtCorreoDesarrollador").val()) == "") {
            alert("Ingrese un correo para el Desarrollador");
            return;
        }
        $("#frmNuevoDesarrollador").submit();
    });
    $("#btnConsultarDesarrollador").click(function () {
        $("#frmCatalogoDesarrollador").submit();
    });
    $("#btnActualizarDesarrollador").click(function () {
        $("#frmDatosDesarrollador").submit();
    });

    function autocompletarDesarrollador() {
        $(".usuariodes").autocomplete({
            minLength: 2,
            source: function (request, response) {
                $.ajax({
                    url: rutaAplicacion + "/Desarrollador/Listar/" + request.term,
                    cache: false,
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item, index) {
                            return {
                                label: item.Usuario,
                                value: item.Usuario,
                                objeto: item
                            }
                        }));
                        //console.log(data);
                    }
                });
            },
            select: function (event, ui) {
                $(this).closest("tr").find(".iddes").attr("value", ui.item.objeto.Id);
                $(this).closest("tr").find("span.nombredes").html(ui.item.objeto.Nombre);
                $(this).closest("tr").find("span.correodes").html(ui.item.objeto.Correo);
                $(this).closest("tr").find("input.nombredes").attr("value", ui.item.objeto.Nombre);
                $(this).closest("tr").find("input.correodes").attr("value", ui.item.objeto.Correo);
            }
        });
    }

    // Aplicacion
    $("#btnConsultarAplicacion").click(function () {
        $("#frmCatalogoAplicacion").submit();
    });

    // Ambientes
    $("#btnCrearAmbiente").click(function () {
        if ($.trim($("#txtNombreAmbiente").val()) == "") {
            alert("Ingrese un nombre de ambiente");
            return;
        }
        if ($.trim($("#txtOrden").val()) == "") {
            alert("Ingrese un valor numerico en el campo Orden");
            return;
        }
        if (!isNumber($("#txtOrden").val())) {
            alert("Ingrese un valor numerico en el campo Orden");
            return;
        }
        if ($("#chkApruebaCalidad").is(":checked") && $("#cboObservaCalidad").val() == "0") {
            alert("Seleccione un tipo de observacion");
            $("#cboObservaCalidad").focus();
            return;
        }
        $("#frmNuevoAmbiente").submit();
    });
    $("#btnConsultarAmbiente").click(function () {
        $("#frmCatalogoAmbiente").submit();
    });
    $("#btnActualizarAmbiente").click(function () {
        if ($.trim($("#txtNombreAmbiente").val()) == "") {
            alert("Ingrese un nombre de ambiente");
            return;
        }
        if ($.trim($("#txtOrden").val()) == "") {
            alert("Ingrese un valor numerico en el campo Orden");
            return;
        }
        if (!isNumber($("#txtOrden").val())) {
            alert("Ingrese un valor numerico en el campo Orden");
            return;
        }
        var seguir = true;
        $(".correoAmbiente").each(function () {
            var correo = $(this).val();
            if (!isValidEmailAddress(correo)) {
                alert("El correo " + correo + " no tiene un formato valido.");
                $(this).focus();
                seguir = false;
                return;
            }
        });
        if ($("#chkApruebaCalidad").is(":checked") && $("#cboObservaCalidad").val() == "0") {
            alert("Seleccione un tipo de observacion");
            $("#cboObservaCalidad").focus();
            return;
        }
        if (seguir) {
            $("#frmDatosAmbiente").submit();
        }
    });
    $("#btnAgregarAmbienteCorreo").on("click", function () {
        var registros = $("#tablaCorreos tbody tr").length;
        registros = registros + 1;
        $("#tablaCorreos tbody").append("<tr><td><input type='checkbox' class='quitarCorreo' id='chkNuevoCorreo" + registros + "' name='chkNuevoCorreo" + registros + "'/></td><td><input class='correoAmbiente form-control' type='text' name='txtNuevoCorreo" + registros + "' id='txtNuevoCorreo" + registros + "'/></td></tr>");
        //alert("Se pretende agregar correo");
    });
    $("#btnQuitarAmbienteCorreo").on("click", function () {
        $(".quitarCorreo").each(function () {
            if ($(this).prop('checked') == true) {
                $(this).parent().parent().remove();
            }
        });
    });
    $("#chkApruebaCalidad").on("click", function () {
        if (!$(this).is(":checked")) {
            $("#cboObservaCalidad").val("0");
            $("#cboObservaCalidad").attr("disabled", "disabled");
        } else {
            $("#cboObservaCalidad").removeAttr("disabled");
        }
    });

    // Servidores
    $("#btnCrearServidor").click(function () {
        if ($.trim($("#txtIpServidor").val()) == "") {
            alert("Ingrese una IP del servidor");
            return;
        }
        if ($.trim($("#txtNombreServidor").val()) == "") {
            alert("Ingrese un nombre del servidor");
            return;
        }
        $("#frmNuevoServidor").submit();
    });
    $("#btnConsultarServidor").click(function () {
        $("#frmCatalogoServidor").submit();
    });
    $("#btnActualizarServidor").click(function () {
        $("#frmDatosServidor").submit();
    });

    // Instancias
    $("#btnCrearInstancia").click(function () {
        if ($.trim($("#txtNombreInstancia").val()) == "") {
            alert("Ingrese un nombre de instancia");
            return;
        }
        if ($.trim($("#cboServidor").val()) == "" || $.trim($("#cboServidor").val()) == "0") {
            alert("Seleccione un servidor");
            return;
        }
        if ($.trim($("#cboAmbiente").val()) == "" || $.trim($("#cboAmbiente").val()) == "0") {
            alert("Seleccione un ambiente");
            return;
        }
        if ($("#cboInstanciaAnt").val() != "0" && $.trim($("#txtRepoSubversion").val()) != "") {
            alert("Especifique o una instancia anterior o un repositorio de Subversion, pero no ambos");
            return;
        }
        if ($("#cboInstanciaAnt").val() == "0" && $.trim($("#txtRepoSubversion").val()) == "") {
            alert("Especifique o una instancia anterior o un repositorio de Subversion");
            return;
        }
        $("#frmNuevoInstancia").submit();
    });
    $("#btnConsultarInstancia").click(function () {
        $("#frmCatalogoInstancia").submit();
    });
    $("#btnActualizarInstancia").click(function () {
        if ($.trim($("#txtNombreInstancia").val()) == "") {
            alert("Ingrese un nombre de instancia");
            return;
        }
        if ($.trim($("#cboServidor").val()) == "" || $.trim($("#cboServidor").val()) == "0") {
            alert("Seleccione un servidor");
            return;
        }
        if ($.trim($("#cboAmbiente").val()) == "" || $.trim($("#cboAmbiente").val()) == "0") {
            alert("Seleccione un ambiente");
            return;
        }
        if ($("#cboInstanciaAnt").val() != "0" && $.trim($("#txtRepoSubversion").val()) != "") {
            alert("Especifique o una instancia anterior o un repositorio de Subversion, pero no ambos");
            return;
        }
        if ($("#cboInstanciaAnt").val() == "0" && $.trim($("#txtRepoSubversion").val()) == "") {
            alert("Especifique o una instancia anterior o un repositorio de Subversion");
            return;
        }
        $("#frmDatosInstancia").submit();
    });
    $("#btnEliminarInstancia").click(function () {
        var rsta = confirm("¿Esta seguro de eliminar la instancia?");
        if (rsta) {
            var url = rutaAplicacion + "/Instancia/Eliminar/" + $("#txtId").val();
            window.location.replace(url);
        }
    });
    $("#btnAgregarEsquema").click(function () {
        var filas = $("#tblEsquemas tbody tr").length;
        filas = filas + 1;
        $("#tblEsquemas > tbody:last").append('<tr><td><input type="hidden" name="idesquema' + filas + '" id="idesquema' + filas + '" value="" /><input type="hidden" class="eliminadoesquema" name="eliminadoesquema' + filas + '" id="eliminadoesquema' + filas + '" value="0" /><input type="checkbox" class="esquema" name="' + filas + '" id="' + filas + '" /></td><td><input class="form-control" type="text" name="nombreesquema' + filas + '"/></td></tr>');
    });
    $("#btnQuitarEsquema").click(function () {
        $("input:checkbox.esquema").each(function () {
            if (this.checked == true) {
                var registro = $(this).attr("name");
                // Determinar el id del hidden que contiene el valor de eliminado
                $("#eliminadoesquema" + registro).attr("value", "1");
                $(this).closest("tr").css("display", "none");
            }
        });
    });
    $("#btnAgregarServidorUsuario").click(function () {
        var filas = $("#tblServidorUsuario tbody tr").length;
        filas = filas + 1;
        $("#tblServidorUsuario > tbody:last").append('<tr><td><input type="hidden" name="hdServidorUsuario' + filas + '" id="hdServidorUsuario' + filas + '" value="" /><input type="hidden" class="eliminadoServidorUsuario" name="eliminadoServidorUsuario' + filas + '" id="eliminadoServidorUsuario' + filas + '" value="0" /><input class="checkServidorUsuario" type="checkbox" name="servidorUsuario' + filas + '" id="servidorUsuario' + filas + '" /></td><td><input type="text" class="form-control usuario" name="servidorUsuarioNombre' + filas + '"/></td><td><input type="text" class="form-control usuario" name="servidorUsuarioClave' + filas + '"/></td></tr>');
        $(".mensaje").html("");
    });
    $("#btnQuitarServidorUsuario").click(function () {
        var prefijo = "servidorUsuario";
        $("input:checkbox.checkServidorUsuario").each(function () {
            if (this.checked == true) {
                var registro = $(this).attr("name");
                var indice = registro.substring(prefijo.length);
                // Determinar el id del hidden que contiene el valor de eliminado
                $("#eliminadoServidorUsuario" + indice).attr("value", "1");
                $(this).closest("tr").css("display", "none");
            }
        });
    });
    // Rol
    $("#btnCrearRol").click(function () {
        if ($.trim($("#txtNombreRol").val()) == "") {
            alert("Ingrese un nombre para el rol");
            return;
        }
        $("#frmNuevoRol").submit();
    });
    $("#btnConsultarRol").click(function () {
        $("#frmCatalogoRol").submit();
    });
    $("#btnActualizarRol").click(function () {
        $("#frmDatosRol").submit();
    });

    // Usuario
    $("#btnCrearUsuario").click(function () {
        if ($.trim($("#txtUsuarioUsuario").val()) == "") {
            alert("Ingrese un nombre para el usuario");
            return;
        }
        if ($.trim($("#txtClaveUsuario").val()) == "") {
            alert("Ingrese una clave para el usuario");
            return;
        }
        if ($.trim($("#txtCorreoUsuario").val()) == "") {
            alert("Ingrese un correo para el usuario");
            return;
        }
        if (!isValidEmailAddress($.trim($("#txtCorreoUsuario").val()))) {
            alert("Ingrese un formato de correo válido para el usuario");
            return;
        }
        if (!$("#chkAdministradorUsuario").is(":checked") &&
            !$("#chkOperadorUsuario").is(":checked") &&
            !$("#chkLectorUsuario").is(":checked") &&
            !$("#chkRMUsuario").is(":checked") &&
            !$("#chkCMUsuario").is(":checked") &&
            !$("#chkEjecutorUsuario").is(":checked") &&
            !$("#chkTestUsuario").is(":checked")) {
            alert("Seleccione al menos un rol de Usuario");
            return;
        }
        var cantidadMarcadas = $(':checkbox:checked.rol').size();
        if (cantidadMarcadas > 1) {
            alert("El usuario solo puede tener un rol.");
            return;
        }
        $("#frmNuevoUsuario").submit();
    });
    $("#btnConsultarUsuario").click(function () {
        $("#frmCatalogoUsuario").submit();
    });
    $("#btnActualizarUsuario").click(function () {
        if ($.trim($("#txtUsuarioUsuario").val()) == "") {
            alert("Ingrese un nombre para el usuario");
            return;
        }
        if ($.trim($("#txtCorreoUsuario").val()) == "") {
            alert("Ingrese un correo para el usuario");
            return;
        }
        if (!isValidEmailAddress($.trim($("#txtCorreoUsuario").val()))) {
            alert("Ingrese un formato de correo válido para el usuario");
            return;
        }
        if (!$("#chkAdministradorUsuario").is(":checked") &&
            !$("#chkOperadorUsuario").is(":checked") &&
            !$("#chkLectorUsuario").is(":checked") &&
            !$("#chkRMUsuario").is(":checked") &&
            !$("#chkCMUsuario").is(":checked") &&
            !$("#chkEjecutorUsuario").is(":checked") &&
            !$("#chkTestUsuario").is(":checked")
            ) {
            alert("Seleccione al menos un rol de Usuario");
            return;
        }
        var cantidadMarcadas = $(':checkbox:checked').size();
        if (cantidadMarcadas > 1) {
            alert("El usuario solo puede tener un rol.");
            return;
        }
        $("#frmDatosUsuario").submit();
    });
    $("#btnAgregarRol").click(function () {
        $.ajax({
            url: rutaAplicacion + "/Rol/Listar/?id=",
            cache: false,
            dataType: "json",
            success: function (data) {
                var filas = $("#tblRoles tbody tr").length;
                filas = filas + 1;
                var cadena = '<tr><td><input type="hidden" name="idrol' + filas + '" id="idrol' + filas + '" value="" /><input type="hidden" class="eliminadorol" name="eliminadorol' + filas + '" id="eliminadorol' + filas + '" value="0" /><input type="hidden" class="nuevo" name="nuevo' + filas + '" id="nuevo' + filas + '" value="0" /><input type="checkbox" class="rol" name="' + filas + '" id="' + filas + '" /></td><td><select class="form-control" name="rolusuario' + filas + '">';
                $(data).each(function (i) {
                    //$(data).map(function(objeto, indice) {
                    cadena = cadena + "<option value='" + data[i].Id + "'>" + data[i].Nombre + "</option>";
                });
                cadena = cadena + '</select></td></tr>';
                $("#tblRoles > tbody:last").append(cadena);
            }
        });
    });
    $("#btnQuitarRol").click(function () {
        $("input:checkbox.rol").each(function () {
            if (this.checked == true) {
                var registro = $(this).attr("name");
                // Determinar el id del hidden que contiene el valor de eliminado
                $("#eliminadorol" + registro).attr("value", "1");
                $(this).closest("tr").css("display", "none");
            }
        });
    });
    $("#btnCambiarClave").click(function () {
        if ($.trim($("#txtClave").val()) == "") {
            alert("Especifique una clave");
            $("#txtClave").focus();
            return;
        }
        $("#frmCambiarClave").submit();
    });
    $("#btnRecuperarClave").click(function () {
        if ($.trim($("#txtUsuario").val()) == "") {
            alert("Especifique un usuario");
            $("#txtUsuario").focus();
            return;
        }
        $("#frmRecuperarClave").submit();
    });
    $("#btnResetearClave").click(function () {
        if ($.trim($("#txtClave").val()) == "") {
            alert("Especifique una clave");
            $("#txtClave").focus();
            return;
        }
        $("#frmResetearClave").submit();
    });
    $("#btnActualizarMisDatos").on("click", function (e) {
        e.preventDefault();
        if ($.trim($("#Usuario_Correo").val()) == "") {
            alert("Especifique un correo");
            $("#txtCorreoUsuario").focus();
            return;
        }
        if (!isValidEmailAddress($("#Usuario_Correo").val())) {
            alert("El correo no es valido");
            $("#txtCorreoUsuario").focus();
            return;
        }
        $("#frmDatosUsuario").submit();
    });
    /*
    $(".usuario").each(function () {
        $(this).qtip({
            content: {
                text: $(this).next('.tooltiptext')
            }
        });
    });
    */
    // Solicitud
    $("#btnCrearSolicitud").click(function () {
        if ($.trim($("#cboAmbiente").val()) == "") {
            alert("Seleccione un ambiente donde desplegar.");
            $("#cboAmbiente").focus();
            return;
        }
        if ($.trim($("#txtCodigoProyecto").val()) == "") {
            alert("Especifique un código de proyecto.");
            $("#txtCodigoProyecto").focus();
            return;
        }
        if ($.trim($("#txtAnalistaDesarrollo").val()) == "") {
            alert("Especifique un analista de desarrollo.");
            $("#txtAnalistaDesarrollo").focus();
            return;
        }
        if (!isValidEmailAddress($.trim($("#txtAnalistaDesarrollo").val()))) {
            alert("Ingrese un formato de correo válido para el analista de desarrollo.");
            $("#txtAnalistaDesarrollo").focus();
            return;
        }
        if ($.trim($("#txtAnalistaTestProd").val()) == "") {
            alert("Especifique un analista de test/prod.");
            $("#txtAnalistaTestProd").focus();
            return;
        }
        if (!isValidEmailAddress($.trim($("#txtAnalistaTestProd").val()))) {
            alert("Ingrese un formato de correo válido para el analista de test/prod.");
            $("#txtAnalistaTestProd").focus();
            return;
        }
        if ($.trim($("#txtInteresados").val()) != "") {
            // Han especificado informacion en este campo
            var interesados = $.trim($("#txtInteresados").val());
            var listaemails = interesados.split(';');
            var cantemails = listaemails.length;
            var validos = true;
            for (var i = 0; i < cantemails; i++) {
                var email = $.trim(listaemails[i]);
                if (!isValidEmailAddress(email)) {
                    alert("El correo " + email + " no es un correo valido.");
                    validos = false;
                    return;
                }
            }
        }
        if ($("#txtFechaEjecucion").val() != "" && ($("#cboHora").val() == "" || $("#cboMinuto").val() == "")) {
            alert("Si especifica una fecha de ejecucion, debe tambien especificar una hora de ejecucion.");
            return;
        }
        var fechaEjecucion = $("#txtFechaEjecucion").val();
        var anio = fechaEjecucion.substring(6);
        var mes = Number(fechaEjecucion.substring(3, 5)) - 1;
        var dia = fechaEjecucion.substring(0, 2)
        var hora = $("#cboHora").val();
        var minuto = $("#cboMinuto").val();
        var fecha = new Date(anio, mes, dia, hora, minuto);
        var fechaActual = new Date();
        // Si la solicitud no es de regularización, la fecha y hora de ejecución debe ser mayor a la fecha actual.
        if ($("#chkRegularizacion").is(":checked") == false) {
            if (fechaActual.getTime() > fecha.getTime()) {
                alert("La fecha de ejecucion es una fecha pasada. Solo se admiten fechas pasadas cuando la solicitud es de regularizacion.");
                return;
            }
        } else {
            // Las solicitudes de regularización deben ser fechas pasadas.
            if (fechaActual.getTime() < fecha.getTime()) {
                alert("Las solicitudes de regularizacion deben tener fechas de regularizacion pasadas.");
                return;
            }
        }
        if ($("#chkEmergente").is(":checked")) {
            if ($.trim($("#txtRazonEmergente").val()) == "") {
                alert("Especifique una razón del pase emergente");
                $("#txtRazonEmergente").focus();
                return;
            }
        }
        if ($(".fechareversion").css("display") == "block") {
            if (!$("#chkFechaReversion").is(":checked") && !$("#chkReversion").is(":checked")) {
                alert("Seleccione o una fecha de reversion o marque la solicitud como de tipo reversion.");
                return;
            }
        }
        if ($(".fechareversion").css("display") == "block" && $("#chkFechaReversion").is(":checked") &&
            $("#txtFechaReversion").val() == "") {
            alert("Especifique una fecha de reversion");
            return;
        }
        if ($.trim($("#txtArchivo1").val()) == "" && $.trim($("#txtArchivo2").val()) == "" && $.trim($("#txtArchivo3").val()) == ""
        && $.trim($("#txtArchivo4").val()) == "" && $.trim($("#txtArchivo5").val()) == "" && $.trim($("#txtArchivo6").val()) == ""
        && $.trim($("#txtArchivo7").val()) == "" && $.trim($("#txtArchivo8").val()) == "" && $.trim($("#txtArchivo9").val()) == ""
        && $.trim($("#txtArchivo10").val()) == "") {
            alert("Especifique al menos un archivo");
            return;
        }
        var continuar = true;
        $(".formulario").each(function () {
            var nombreArchivoConRuta = $.trim($(this).val());
            if (nombreArchivoConRuta != "") {
                var nombreArchivo = nombreArchivoConRuta.substring(nombreArchivoConRuta.lastIndexOf("\\") + 1);
                var mensajeError = "El archivo " + nombreArchivo + " no es un formulario de Excel. Solo se pueden adjuntar archivos de Excel en la pestana Formularios.";
                var punto = nombreArchivo.lastIndexOf(".");
                if (punto >= 0) {
                    var extension = nombreArchivo.substring(punto + 1);
                    if (extension.length >= 3) {
                        if (extension.substring(0, 3) != "xls") {
                            // No es un formulario de Excel
                            alert(mensajeError);
                            continuar = false;
                            return;
                        }
                    }
                    else {
                        // La extensión no tiene como mínimo 3 caracteres
                        alert(mensajeError);
                        continuar = false;
                        return;
                    }
                }
                else {
                    // No tiene extensión
                    alert(mensajeError);
                    continuar = false;
                    return;
                }
            }
        });

        $(".archivo").each(function () {
            var nombreArchivo = $.trim($(this).val());
            var indice = nombreArchivo.lastIndexOf("\\");
            nombreArchivo = nombreArchivo.substring(indice + 1);
            if (nombreArchivo.length > 100) {
                alert("El nombre del archivo " + nombreArchivo + " tiene mas de 100 caracteres");
                continuar = false;
                return;
            }
        });
        if (!continuar) {
            return;
        }
        /*
        var ambienteId = $("#cboAmbiente").val();
        $(".proyectoambiente").each(function () {
            var idCombinado = $(this).attr("id");
            var id = idCombinado.substring(9);
            var fechaPase = $(this).val();
            if (ambienteId == id) {
                // El ambiente tiene fecha de pase
                if ($("#txtFechaEjecucion").val() == "") {
                    alert("Por favor especifique una fecha de ejecucion.");
                    continuar = false;
                    return;
                } else {
                    // Comparar la fecha de pase del proyecto con el de la solicitud
                    // Si la fecha de pase de la solicitud es menor a la del proyecto, mostrar mensaje
                    var fechaEjecucion = $("#txtFechaEjecucion").val();
                    var dia = fechaEjecucion.substring(0, 2);
                    var mes = fechaEjecucion.substring(3, 5);
                    var anio = fechaEjecucion.substring(6);
                    var fechaCompleto = "-" + anio + mes + dia;
                    fechaCompleto = fechaCompleto.substring(1);
                    if (fechaCompleto < fechaPase) {
                        alert("La fecha del pase de la solicitud ("+fechaEjecucion+") es menor a la fecha de pase programada en el proyecto ("+fechaPase.substring(6)+"/"+fechaPase.substring(4,6)+"/"+fechaPase.substring(0,4)+")");
                        continuar = false;
                        return;
                    }
                }
            }
        });
        if (!continuar) {
            return;
        }
        */
        $('#btnCrearSolicitud').prop('disabled', true);
        $("#frmCrearSolicitud").submit();
    });
    $(".subearchivo").change(function () {
        var ruta = $(this).val();
        var indice = ruta.lastIndexOf("\\");
        var nombrearchivo = ruta.substring(indice + 1);
        var nombreobjeto = $(this).attr("name");
        var indicador = nombreobjeto.substring("nombrearch".length);
        $("#nombrearch" + indicador).val(nombrearchivo);
        $("#nombrearch" + indicador).attr("data-archivo", "1");
        if ($("#p" + indicador) != null)
            $("#p" + indicador).html("");
    });
    $(".subeaprobacion").change(function () {
        var nombreobjeto = $(this).attr("name");
        console.log(nombreobjeto);
        var indicador = nombreobjeto.substring("txtAprobacion".length);
        
        var valor = $("#nombreaprob" + indicador).val();
        console.log(valor);
        if (valor.indexOf("-eliminado") >= 0) {
            valor = valor.substring(0, valor.indexOf("-eliminado"));
            $("#nombreaprob" + indicador).val(valor);
        }
        if ($("#o" + indicador) != null)
            $("#o" + indicador).html("");
    });
    $("#btnRMSolicitadoxSol").click(function () {
        if ($.trim($("#txtInteresados").val()) != "") {
            // Han especificado informacion en este campo
            var interesados = $.trim($("#txtInteresados").val());
            var listaemails = interesados.split(';');
            var cantemails = listaemails.length;
            var validos = true;
            for (var i = 0; i < cantemails; i++) {
                var email = $.trim(listaemails[i]);
                if (!isValidEmailAddress(email)) {
                    alert("El correo " + email + " no es un correo valido.");
                    validos = false;
                    return;
                }
            }
        }
        if ($.trim($("#cboAccion").val()) != "" && $("#cboObservacion").css("display") == "inline-block" && $("#cboObservacion").val() == "0") {
            alert("Seleccionar un tipo de Observacion");
            $("#cboObservacion").focus();
            return;
        }
        if ($.trim($("#cboAccion").val()) != "" && $.trim($("#txtComentario").val()) == "") {
            alert("Especifique un comentario");
            $("#txtComentario").focus();
            return;
        }
        var continuar = true;
        $(".archivo").each(function () {
            var nombreArchivo = $.trim($(this).val());
            var indice = nombreArchivo.lastIndexOf("\\");
            nombreArchivo = nombreArchivo.substring(indice + 1);
            if (nombreArchivo.length > 100) {
                alert("El nombre del archivo " + nombreArchivo + " tiene mas de 100 caracteres");
                continuar = false;
                return;
            }
        });
        if (!continuar) {
            return;
        }
        $('#btnRMSolicitadoxSol').prop('disabled', true);
        $("#frmActualizarSolicitud").submit();
    });
    $("#btnSolSolicitadoxSol").click(function () {
        if ($.trim($("#txtInteresados").val()) != "") {
            // Han especificado informacion en este campo
            var interesados = $.trim($("#txtInteresados").val());
            var listaemails = interesados.split(';');
            var cantemails = listaemails.length;
            var validos = true;
            for (var i = 0; i < cantemails; i++) {
                var email = $.trim(listaemails[i]);
                if (!isValidEmailAddress(email)) {
                    alert("El correo " + email + " no es un correo valido.");
                    validos = false;
                    return;
                }
            }
        }
        if ($("#cboAccion").val() == "") {
            alert("Especifique una accion");
            return;
        }
        if ($.trim($("#cboAccion").val()) != "" && $("#cboObservacion").css("display") == "inline-block" && $("#cboObservacion").val() == "0") {
            alert("Seleccionar un tipo de Observacion");
            $("#cboObservacion").focus();
            return;
        }
        if ($.trim($("#cboAccion").val()) != "" && $.trim($("#txtComentario").val()) == "") {
            alert("Especifique un comentario");
            $("#txtComentario").focus();
            return;
        }
        var continuar = true;
        $(".archivo").each(function () {
            var nombreArchivo = $.trim($(this).val());
            var indice = nombreArchivo.lastIndexOf("\\");
            nombreArchivo = nombreArchivo.substring(indice + 1);
            if (nombreArchivo.length > 100) {
                alert("El nombre del archivo " + nombreArchivo + " tiene mas de 100 caracteres");
                continuar = false;
                return;
            }
        });
        if (!continuar) {
            return;
        }
        $('#btnSolSolicitadoxSol').prop('disabled', true);
        $("#frmActualizarSolicitud").submit();
    });
    $("#btnSolObservadoxRM").click(function () {
        if ($.trim($("#cboAmbiente").val()) == "") {
            alert("Seleccione un ambiente donde desplegar.");
            $("#cboAmbiente").focus();
            return;
        }
        if ($.trim($("#txtCodigoProyecto").val()) == "") {
            alert("Especifique el código de proyecto.");
            $("#txtCodigoProyecto").focus();
            return;
        }
        if ($.trim($("#txtAnalistaDesarrollo").val()) == "") {
            alert("Especifique un analista de desarrollo.");
            $("#txtAnalistaDesarrollo").focus();
            return;
        }
        if (!isValidEmailAddress($.trim($("#txtAnalistaDesarrollo").val()))) {
            alert("Ingrese un formato de correo válido para el analista de desarrollo.");
            $("#txtAnalistaDesarrollo").focus();
            return;
        }
        if ($.trim($("#txtAnalistaTestProd").val()) == "") {
            alert("Especifique un analista de test/prod.");
            $("#txtAnalistaTestProd").focus();
            return;
        }
        if (!isValidEmailAddress($.trim($("#txtAnalistaTestProd").val()))) {
            alert("Ingrese un formato de correo válido para el analista de test/prod.");
            $("#txtAnalistaTestProd").focus();
            return;
        }
        if ($.trim($("#txtInteresados").val()) != "") {
            // Han especificado informacion en este campo
            var interesados = $.trim($("#txtInteresados").val());
            var listaemails = interesados.split(';');
            var cantemails = listaemails.length;
            var validos = true;
            for (var i = 0; i < cantemails; i++) {
                var email = $.trim(listaemails[i]);
                if (!isValidEmailAddress(email)) {
                    alert("El correo " + email + " no es un correo valido.");
                    validos = false;
                    return;
                }
            }
        }
        if ($("#txtFechaEjecucion").val() == "" && $("#cboHora").val() == "" && $("#cboMinuto").val() == "") {
        } else if ($("#txtFechaEjecucion").val() != "" && $("#cboHora").val() != "" && $("#cboMinuto").val() != "") {
        }
        else {
            alert("La fecha y hora de ejecucion debe tener todos los campos llenos.");
            return;
        }
        var fechaEjecucion = $("#txtFechaEjecucion").val();
        var anio = fechaEjecucion.substring(6);
        var mes = Number(fechaEjecucion.substring(3, 5)) - 1;
        var dia = fechaEjecucion.substring(0, 2)
        var hora = $("#cboHora").val();
        var minuto = $("#cboMinuto").val();
        var fecha = new Date(anio, mes, dia, hora, minuto);
        var fechaActual = new Date();
        // Si la solicitud no es de regularización, la fecha y hora de ejecución debe ser mayor a la fecha actual.
        //if ($("#chkRegularizacion").is(":checked") == false) {
        //    if (fechaActual.getTime() > fecha.getTime()) {
        //        alert("La fecha de ejecucion es una fecha pasada. Solo se admiten fechas pasadas cuando la solicitud es de regularizacion.");
        //        return;
        //    }
        //} else {
        //    // Las solicitudes de regularización deben ser fechas pasadas.
        //    if (fechaActual.getTime() < fecha.getTime()) {
        //        alert("Las solicitudes de regularizacion deben tener fechas de regularizacion pasadas.");
        //        return;
        //    }
        //}
        if ($("#chkEmergente").is(":checked")) {
            if ($.trim($("#txtRazonEmergente").val()) == "") {
                alert("Especifique una razón del pase emergente");
                $("#txtRazonEmergente").focus();
                return;
            }
        }
        if ($(".fechareversion").css("display") == "block") {
            if (!$("#chkFechaReversion").is(":checked") && !$("#chkReversion").is(":checked")) {
                alert("Seleccione o una fecha de reversion o marque la solicitud como de tipo reversion.");
                return;
            }
        }
        if ($(".fechareversion").css("display") == "block" && $("#chkFechaReversion").is(":checked") &&
            $("#txtFechaReversion").val() == "") {
            alert("Especifique una fecha de reversion");
            return;
        }
        if ($.trim($("#nombrearch1").val()) == "" && $.trim($("#nombrearch2").val()) == "" && $.trim($("#nombrearch3").val()) == ""
        && $.trim($("#nombrearch4").val()) == "" && $.trim($("#nombrearch5").val()) == "" && $.trim($("#nombrearch6").val()) == ""
        && $.trim($("#nombrearch7").val()) == "" && $.trim($("#nombrearch8").val()) == "" && $.trim($("#nombrearch9").val()) == ""
        && $.trim($("#nombrearch10").val()) == "") {
            alert("Especifique al menos un archivo");
            return;
        }
        if ($("#cboAccion").val() == "") {
            alert("Especifique una accion");
            return;
        }
        var ambienteId = $("#cboAmbiente").val();

        var continuar = true;
        $(".formulario").each(function () {
            var nombreArchivoConRuta = $.trim($(this).val());
            if (nombreArchivoConRuta != "") {
                var nombreArchivo = nombreArchivoConRuta.substring(nombreArchivoConRuta.lastIndexOf("\\") + 1);
                var mensajeError = "El archivo " + nombreArchivo + " no es un formulario de Excel. Solo se pueden adjuntar archivos de Excel en la pestana Formularios.";
                var punto = nombreArchivo.lastIndexOf(".");
                if (punto >= 0) {
                    var extension = nombreArchivo.substring(punto + 1);
                    if (extension.length >= 3) {
                        if (extension.substring(0, 3) != "xls") {
                            // No es un formulario de Excel
                            alert(mensajeError);
                            continuar = false;
                            return;
                        }
                    }
                    else {
                        // La extensión no tiene como mínimo 3 caracteres
                        alert(mensajeError);
                        continuar = false;
                        return;
                    }
                }
                else {
                    // No tiene extensión
                    alert(mensajeError);
                    continuar = false;
                    return;
                }
            }
        });

        $(".archivo").each(function () {
            var nombreArchivo = $.trim($(this).val());
            var indice = nombreArchivo.lastIndexOf("\\");
            nombreArchivo = nombreArchivo.substring(indice + 1);
            if (nombreArchivo.length > 100) {
                alert("El nombre del archivo " + nombreArchivo + " tiene mas de 100 caracteres");
                continuar = false;
                return;
            }
        });
        if (!continuar) {
            return;
        }
        /*
        $(".proyectoambiente").each(function () {
            var idCombinado = $(this).attr("id");
            var id = idCombinado.substring(9);
            var fechaPase = $(this).val();
            if (ambienteId == id) {
                // El ambiente tiene fecha de pase
                if ($("#txtFechaEjecucion").val() == "") {
                    alert("Por favor especifique una fecha de pase.");
                    continuar = false;
                    return;
                } else {
                    // Comparar la fecha de pase del proyecto con el de la solicitud
                    // Si la fecha de pase de la solicitud es menor a la del proyecto, mostrar mensaje
                    var fechaEjecucion = $("#txtFechaEjecucion").val();
                    var dia = fechaEjecucion.substring(0, 2);
                    var mes = fechaEjecucion.substring(3, 5);
                    var anio = fechaEjecucion.substring(6);
                    var fechaCompleto = "-" + anio + mes + dia;
                    fechaCompleto = fechaCompleto.substring(1);
                    if (fechaCompleto < fechaPase) {
                        alert("La fecha del pase de la solicitud (" + fechaEjecucion + ") es menor a la fecha de pase programada en el proyecto (" + fechaPase.substring(6) + "/" + fechaPase.substring(4, 6) + "/" + fechaPase.substring(0, 4) + ")");
                        continuar = false;
                        return;
                    }
                }
            }
        });
        if (!continuar) {
            return;
        }
        */
        if ($.trim($("#cboAccion").val()) != "" && $("#cboObservacion").css("display") == "inline-block" && $("#cboObservacion").val() == "0") {
            alert("Seleccionar un tipo de Observacion");
            $("#cboObservacion").focus();
            return;
        }
        if ($.trim($("#cboAccion").val()) != "" && $.trim($("#txtComentario").val()) == "") {
            alert("Especifique un comentario");
            $("#txtComentario").focus();
            return;
        }
        $('#btnSolObservadoxRM').prop('disabled', true);
        $("#frmActualizarSolicitud").submit();
    });
    $("#chkEmergente").click(function () {
        if ($(this).is(":checked")) {
            $(".razonemergente").css("display", "block");
        }
        else {
            $(".razonemergente").css("display", "none");
        }
    });
    $(".eliminararchivo").click(function () {
        var nombreObjeto = $(this).attr("id");
        var numero = nombreObjeto.substring(1);
        $(this).parent().html("");
        $("#nombrearch" + numero).val("");
        $("#nombrearch" + numero).attr("data-archivo", "1");
    });
    $(".eliminaraprobacion").click(function () {
        var nombreObjeto = $(this).attr("id");
        var numero = nombreObjeto.substring(1);
        $(this).parent().html("");
        var valorActual = $("#nombreaprob" + numero).val();
        $("#nombreaprob" + numero).val(valorActual+"-eliminado");
    });
    $("#btnConsultarSolicitud").click(function () {
        if ($("#chkFechas").is(":checked") && ($.trim($("#txtFechaDesde").val()) == "" || $.trim($("#txtFechaHasta").val()) == "")) {
            alert("Especifique un rango de fechas");
            return;
        }
        if ($("#chkFechaEjecucion").is(":checked") && ($.trim($("#txtFechaEjecucionDesde").val()) == "" || $.trim($("#txtFechaEjecucionHasta").val()) == "")) {
            alert("Especifique un rango de fechas");
            return;
        }
        if ($.trim($("#txtCodigoSolicitud").val()) == "" && $("#cboAmbiente").val() == "0" &&
            $.trim($("#txtCodigoProyecto").val()) == "" && $.trim($("#txtAnalistaDesarrollo").val()) == "" &&
            $.trim($("#txtAnalistaTestProd").val()) == "" && $("#chkEmergente").is(":checked") == false && $("#chkFechas").is(":checked") == false && $("#chkFechaEjecucion").is(":checked") == false
            && $.trim($("#txtRfc").val()) == "" && $.trim($("#txtSolicitante").val()) == "" && !$("#chkAdicional").is(":checked") && !$("#chkPrincipal").is(":checked")) {
            alert("Especifique al menos un criterio de busqueda");
            return;
        }
        $("#frmCatalogoSolicitud").submit();
    });
    $("#cboVentana").change(function () {
        var textoSeleccionado = $("#cboVentana option:selected").text();
        var ventana = "";
        if (textoSeleccionado != "Emergente") {
            ventana = "NORMAL a horas: " + textoSeleccionado;
        }
        else {
            ventana = "EMERGENTE";
        }
        $("#txtAsunto").val("Pases a ejecutar en la ventana "+ventana );
        $("#txtMensajeEnvio").val("Estimados.\n\nSe env\u00EDa la relaci\u00F3n de pases a ejecutarse en la ventana: "+ventana);
    });
    $("#btnEnviarEjecutor").click(function () {

        var existemarcado = false;
        $("input:checkbox.solaprobada").each(function () {
            if (this.checked == true) {
                existemarcado = true;
            }
        });
        if (!existemarcado) {
            alert("Seleccione al menos una solicitud para enviar.");
            return;
        }
        if ($.trim($("#cboVentana").val()) == "" || $.trim($("#cboVentana").val()) == "0") {
            alert("Seleccione una ventana de pase");
            return;
        }
        var ambientes = new Array();
        $(".solaprobada").each(function () {
            var ambiente = $(this).attr("data-ambiente");
            if (this.checked) {
                var encontrado = false;
                for (var i = 0; i < ambientes.length; i++) {
                    if (ambientes[i] == ambiente) {
                        encontrado = true;
                    }
                }
                if (!encontrado) {
                    var tamanio = ambientes.length;
                    ambientes[tamanio] = ambiente;
                }
            }
        });
        if (ambientes.length > 1) {
            alert("No se puede seleccionar ambientes distintos para enviar al ejecutor");
            return;
        }
        $('#btnEnviarEjecutor').prop('disabled', true);
        $("#frmEnviarEjecutor").submit();
    });
    $("#chkTodos").click(function () {
        var marcado = this.checked;
        if (marcado) {
            $("input:checkbox.solaprobada").prop("checked", true);
        }
        else {
            $("input:checkbox.solaprobada").prop("checked", false);
        }
    });
    $("#txtCodigoProyecto").focusin(function () {
        autocompletarProyecto();
    });
    $("#txtCodigoProyecto").focusout(function () {
        $.ajax({
            url: rutaAplicacion + "/Proyecto/Listar/" + $(this).val(),
            dataType: "json",
            cache: false,
            success: function (data) {
                if (data.length >= 1) {
                    var mejora = data[0].Mejora;
                    if (data[0].Ambientes.length > 0) {
                        var html = "";
                        for (var i = 0; i < data[0].Ambientes.length; i++) {
                            var dia = data[0].Ambientes[i].CadenaFechaPase.substring(0, 2);
                            var mes = data[0].Ambientes[i].CadenaFechaPase.substring(3, 5);
                            var anio = data[0].Ambientes[i].CadenaFechaPase.substring(6);
                            html = html + "<input type='hidden' class='proyectoambiente' id='ambiente-" + data[0].Ambientes[i].Ambiente.Id + "' value='" + anio + mes + dia + "'/>";
                        }
                        $("#divAmbientes").html(html);
                    }
                    $("#lblDescripcionProyecto").html(data[0].Nombre);
                    if ($("#chkFechaReversion") != null) {
                        if (mejora) {
                            $(".fechareversion").css("display", "block");
                        }
                        else {
                            $("#txtFechaReversion").val("");
                            $("#txtFechaReversion").prop("disabled", true);
                            $("#chkFechaReversion").removeAttr("checked");
                            $("#chkFechaReversion").parent().parent().css("display", "none");
                        }
                    }
                    var hdIdProyecto = document.getElementById("hdIdProyecto");
                    if (hdIdProyecto != null) {
                        hdIdProyecto.value = data[0].Id;
                        var proyectoId = data[0].Id;
                        var ambienteId = $("#cboAmbiente").val();
                        var resultadoCertificado = $("#resultadoCertificado");
                        obtenerInfoCertificado(proyectoId, ambienteId, resultadoCertificado);
                    }
                } else {
                    $("#lblDescripcionProyecto").html("");
                }
            }
        });
    });
    function autocompletarProyecto() {
        $(".codigoproyecto").autocomplete({
            minLength: 5,
            source: function (request, response) {
                $.ajax({
                    url: rutaAplicacion + "/Proyecto/Listar/" + request.term,
                    cache: false,
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item, index) {
                            return {
                                label: item.Codigo + ' ' + item.Nombre,
                                value: item.Codigo,
                                objeto: item
                            }
                        }));
                        //console.log(data);
                    }
                });
            },
            select: function (event, ui) {
                $("#lblDescripcionProyecto").html(ui.item.objeto.Nombre);
                $(this).closest("tr").find(".iddes").attr("value", ui.item.objeto.Id);
                var proyectoId = ui.item.objeto.Id;
                var ambienteId = $("#cboAmbiente").val();
                var resultadoCertificado = $("#resultadoCertificado");
                obtenerInfoCertificado(proyectoId, ambienteId);
            }
        });
    }
    var cboAmbiente = document.getElementById("cboAmbiente");
    if (cboAmbiente != null) {
        cboAmbiente.addEventListener("change", function () {
            var ambienteId = cboAmbiente.options[cboAmbiente.selectedIndex].value;
            var hdIdProyecto = document.getElementById("hdIdProyecto");
            if (hdIdProyecto != null) {
                var proyectoId = hdIdProyecto.value;
                var resultadoCertificado = document.getElementById("resultadoCertificado");
                obtenerInfoCertificado(proyectoId, ambienteId, resultadoCertificado);
            }
        });
    }
    function obtenerInfoCertificado(proyectoId, ambienteId, resultadoCertificado) {
        if (proyectoId != null && ambienteId != null && proyectoId != "" && ambienteId != "" && resultadoCertificado != null && proyectoId != "0" && ambienteId != "0") {
            $.ajax({
                url: rutaAplicacion + "/Proyecto/ListarCertificado/?proyectoid=" + proyectoId + "&ambienteid=" + ambienteId,
                cache: false,
                dataType: "json",
                success: function (data) {
                    procesarData(data);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $(resultadoCertificado).html(xhr.status + ": " + thrownError);
                },
                cache: false
            });
        }
    }
    function procesarData(data) {
        if (data.certificados.length > 0) {
            var html = '<div class="table-responsive">';
            html = html + '<table class="table table-bordered table-condensed table-hover">';
            html = html + "<thead>";
            html = html + "<tr><th>Usuario</th><th>Estado</th><th>Fecha y Hora</th></tr>";
            html = html + "<tbody>";
            for (var i = 0; i < data.certificados.length; i++) {
                if (data.certificados[i].Certificado) {
                    var certificado = "Certificado";
                } else {
                    var certificado = "No Certificado";
                }
                html = html + "<tr><td>" + data.certificados[i].Usuario.Nombre + "</td><td>" + certificado + "</td><td>" + data.certificados[i].FechaHoraCadena + "</td></tr>";
            }
            html = html + "</tbody></table></div>";
            if (data.certificados[data.certificados.length - 1].Certificado) {
                html = html + "<input class='btn btn-primary' type='button' id='btnQuitarCertificado' value='Quitar Certificado'/>";
            } else {
                html = html + "<input class='btn btn-primary' type='button' id='btnCertificar' value='Certificar'/>";
            }
            $("#resultadoCertificado").html(html);
        } else {
            $("#resultadoCertificado").html("<input class='btn btn-primary' type='button' id='btnCertificar' value='Certificar'/>");
        }
    }
    $("body").on("click", "#btnCertificar", function (e) {
        var rsta = confirm("¿Esta seguro de certificar el proyecto?");
        if (rsta) {
            $(this).prop("disabled", true);
            var proyectoId = $("#hdIdProyecto").val();
            var ambienteId = $("#cboAmbiente").val();
            var urlAplicacion = rutaAplicacion + "/Proyecto/PonerCertificado/?proyectoid=" + proyectoId + "&ambienteid=" + ambienteId;
            $.ajax({
                url: urlAplicacion,
                dataType: "json",
                success: function (data) {
                    $(".mensaje").html("Se certifico el proyecto de forma correcta.");
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $(".mensaje").html(xhr.status + ": " + thrownError);
                },
                cache: false
            });
        }
        e.preventDefault();
    });
    $("body").on("click", "#btnQuitarCertificado", function (e) {
        var rsta = confirm("¿Esta seguro de quitar la certificacion al proyecto?");
        if (rsta) {
            $(this).prop("disabled", true);
            var proyectoId = $("#hdIdProyecto").val();
            var ambienteId = $("#cboAmbiente").val();
            var urlAplicacion = rutaAplicacion + "/Proyecto/QuitarCertificado/?proyectoid=" + proyectoId + "&ambienteid=" + ambienteId;
            $.ajax({
                url: urlAplicacion,
                dataType: "json",
                success: function (data) {
                    $(".mensaje").html("Se quito la certificacion de forma correcta.");
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $(".mensaje").html(xhr.status + ": " + thrownError);
                },
                cache: false
            });
        }
        e.preventDefault();
    });
    $("#btnAgregarAprobacion").click(function () {
        var numeroHijos = $("#aprobaciones >tbody >tr").length;
        var siguiente = numeroHijos + 1;
        var segmento = "<tr><td><input type='hidden' name='nombreaprob" + siguiente + "' id='nombreaprob" + siguiente + "' value='0' /><input type='file' name='txtAprobacion" + siguiente + "' id='txtAprobacion" + siguiente + "' class='form-control' /></td><td></td></tr>"
        $("#aprobaciones > tbody:last-child").append(segmento);
    });
    $("#chkFechaReversion").on("click", function () {
        if ($(this).is(":checked")) {
            $("#chkReversion").removeAttr("checked");
            $("#txtFechaReversion").prop("disabled", false);
            $("#txtFechaReversion").focus();
        } else {
            $("#txtFechaReversion").prop("disabled", true);
            $("#txtFechaReversion").val("");
        }
    });
    $("#chkReversion").on("click", function () {
        if ($(this).is(":checked")) {
            $("#chkFechaReversion").removeAttr("checked");
            $("#txtFechaReversion").prop("disabled", true);
            $("#txtFechaReversion").val("");
        }
    });

    // Area
    $("#btnCrearArea").click(function () {
        if ($.trim($("#txtNombreArea").val()) == "") {
            alert("Ingrese un nombre de area");
            return;
        }
        var continuar = true;
        $("input:text[name*='direccioncorreo']").each(function () {
            if (!isValidEmailAddress($(this).val())) {
                alert("El correo \"" + $(this).val() + "\" no es valido");
                continuar = false;
                return;
            }
        });
        if (continuar) {
            $("#frmNuevaArea").submit();
        }
    });
    $("#btnConsultarArea").click(function () {
        $("#frmCatalogoArea").submit();
    });
    $("#btnActualizarArea").click(function () {
        if ($.trim($("#txtNombreArea").val()) == "") {
            alert("Ingrese un nombre de area");
            return;
        }
        var continuar = true;
        $("input:text[name*='direccioncorreo']").each(function () {
            if (!isValidEmailAddress($(this).val())) {
                alert("El correo \"" + $(this).val() + "\" no es valido");
                continuar = false;
                return;
            }
        });
        if (continuar) {
            $("#frmDatosArea").submit();
        }
    });
    $("#tabs").tabs();
    $("#btnAgregarCorreo").click(function () {
        var filas = $("#tblCorreos tbody tr").length;
        filas = filas + 1;
        $("#tblCorreos > tbody:last").append('<tr><td><input type="hidden" name="hdId' + filas + '" id="hdId' + filas + '" value="" /><input type="hidden" class="eliminadocorreo" name="eliminadocorreo' + filas + '" id="eliminadocorreo' + filas + '" value="0" /><input type="checkbox" class="correo" name="' + filas + '" id="' + filas + '" /></td><td><input class="form-control" type="text" name="direccioncorreo' + filas + '"/></td></tr>');
    });
    $("#btnQuitarCorreo").click(function () {
        $("input:checkbox.correo").each(function () {
            if (this.checked == true) {
                var registro = $(this).attr("name");
                // Determinar el id del hidden que contiene el valor de eliminado
                $("#eliminadocorreo" + registro).attr("value", "1");
                $(this).closest("tr").css("display", "none");
            }
        });
    });
    $("#txtColor").click(function () {
        $("#txtColor").ColorPicker({
            onChange: function (hsb, hex, rgb) {
                $("#txtColor").css('backgroundColor', '#' + hex);
                $("#txtColor").val('rgb(' + rgb.r + ',' + rgb.g + ',' + rgb.b + ')');
            }
        });
    });

    // Ventana
    $("#btnCrearVentana").click(function () {
        $("#frmNuevaVentana").submit();
    });
    $("#btnActualizarVentana").click(function () {
        $("#frmDatosVentana").submit();
    });

    // Observacion
    $("#btnCrearObservacion").click(function () {
        if ($.trim($("#txtNombreObservacion").val()) == "") {
            alert("Ingrese un nombre de observacion");
            return;
        }
        $("#frmNuevaObservacion").submit();
    });
    $("#btnConsultarObservacion").click(function () {
        $("#frmCatalogoObservacion").submit();
    });
    $("#btnActualizarObservacion").click(function () {
        if ($.trim($("#txtNombreObservacion").val()) == "") {
            alert("Ingrese un nombre de observación");
            return;
        }
        $("#frmDatosObservacion").submit();
    });

    // TipoObjetoBD
    $("#btnCrearTipoObjetoBD").click(function () {
        if ($.trim($("#txtNombreTipoObjetoBD").val()) == "") {
            alert("Ingrese un nombre de tipo de objeto de BD");
            return;
        }
        $("#frmNuevaTipoObjetoBD").submit();
    });
    $("#btnConsultarTipoObjetoBD").click(function () {
        $("#frmCatalogoTipoObjetoBD").submit();
    });
    $("#btnActualizarTipoObjetoBD").click(function () {
        if ($.trim($("#txtNombreTipoObjetoBD").val()) == "") {
            alert("Ingrese un nombre de tipo de objeto de BD.");
            return;
        }
        $("#frmDatosTipoObjetoBD").submit();
    });

    // TipoAccionBD
    $("#btnCrearTipoAccionBD").click(function () {
        if ($.trim($("#txtNombreTipoAccionBD").val()) == "") {
            alert("Ingrese un nombre de tipo de accion de BD");
            return;
        }
        $("#frmNuevaTipoAccionBD").submit();
    });
    $("#btnConsultarTipoAccionBD").click(function () {
        $("#frmCatalogoTipoAccionBD").submit();
    });
    $("#btnActualizarTipoAccionBD").click(function () {
        if ($.trim($("#txtNombreTipoAccionBD").val()) == "") {
            alert("Ingrese un nombre de tipo de accion de BD.");
            return;
        }
        $("#frmDatosTipoAccionBD").submit();
    });

    $("#cboAccion").change(function () {
        var valor = $(this).val();
        var indice = valor.indexOf("Observar");
        if (indice >= 0) {
            $("#cboObservacion").css("display", "inline-block");
            $("#divTipoObservacion").css("display", "block");
        } else {
            $("#cboObservacion").css("display", "none");
            $("#divTipoObservacion").css("display", "none");
        }
        if ($.trim(valor) != "") {
            $("#evidencia").css("display", "block");
        }
        else {
            $("#evidencia").css("display", "none");
        }
        indice = valor.indexOf("Ejecutado");
        if (indice >= 0 && $.trim($("#txtComentario").val()) == "") {
            $("#txtComentario").val("Se ejecutaron los pases. Por favor validar.");
        }
    });

    $("#chkFechas").click(function () {
        if ($(this).is(":checked")) {
            $("#txtFechaDesde").prop("disabled", false);
            $("#txtFechaDesde").datepicker("enable");
            $("#txtFechaDesde").datepicker({ dateFormat: 'dd/mm/yy' });

            $("#txtFechaHasta").prop("disabled", false);
            $("#txtFechaHasta").datepicker("enable");
            $("#txtFechaHasta").datepicker({ dateFormat: 'dd/mm/yy' });

        } else {
            $("#txtFechaDesde").val("");
            $("#txtFechaDesde").prop("disabled", true);
            $("#txtFechaDesde").datepicker("disable");

            $("#txtFechaHasta").val("");
            $("#txtFechaHasta").prop("disabled", true);
            $("#txtFechaHasta").datepicker("disable");
        }
    });

    $("#chkFechaEjecucion").click(function () {
        if ($(this).is(":checked")) {
            $("#txtFechaEjecucionDesde").prop("disabled", false);
            $("#txtFechaEjecucionDesde").datepicker("enable");
            $("#txtFechaEjecucionDesde").datepicker({ dateFormat: 'dd/mm/yy' });

            $("#txtFechaEjecucionHasta").prop("disabled", false);
            $("#txtFechaEjecucionHasta").datepicker("enable");
            $("#txtFechaEjecucionHasta").datepicker({ dateFormat: 'dd/mm/yy' });

        } else {
            $("#txtFechaEjecucionDesde").val("");
            $("#txtFechaEjecucionDesde").prop("disabled", true);
            $("#txtFechaEjecucionDesde").datepicker("disable");

            $("#txtFechaEjecucionHasta").val("");
            $("#txtFechaEjecucionHasta").prop("disabled", true);
            $("#txtFechaEjecucionHasta").datepicker("disable");
        }
    });

    // Formato
    $("#btnCrearFormato").click(function () {
        if ($.trim($("#txtNombreFormato").val()) == "") {
            alert("Especifique un archivo.");
            return;
        }
        if ($.trim($("#txtDescripcionFormato").val()) == "") {
            alert("Especifique una descripción para el formato.");
            return;
        }
        if ($.trim($("#txtCodigo").val()) == "") {
            alert("Especifique un codigo para el formato.");
            return;
        }
        if ($.trim($("#txtVersion").val()) == "") {
            alert("Especifique una version para el formato.");
            return;
        }
        $("#frmNuevoFormato").submit();
    });
    $("#btnActualizarFormato").click(function () {
        if ($.trim($("#txtDescripcionFormato").val()) == "") {
            alert("Especifique una descripción para el archivo.");
            return;
        }
        if ($.trim($("#txtCodigo").val()) == "") {
            alert("Especifique un codigo para el formato.");
            return;
        }
        if ($.trim($("#txtVersion").val()) == "") {
            alert("Especifique una version para el formato.");
            return;
        }
        $("#frmDatosFormato").submit();
    });
    $("#btnEliminarFormato").click(function () {
        var rsta = confirm("¿Esta seguro de eliminar el formulario?");
        if (rsta) {
            var id = $("#txtId").val();
            var url = rutaAplicacion + "/Formato/Eliminar/" + id;
            window.location.replace(url);
        }
    });
    $("#btnConfigurarCorreo").click(function () {
        $("#frmConfigurarCorreo").submit();
    });

    $("#dialog-message").dialog({
        modal: true,
        autoOpen: false,
        width: 600,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });

    $(".mostrarmensaje").click(function () {
        var nombreobjeto = $(this).attr("data-contenedor");
        var contenido = $("#" + nombreobjeto).html();
        $("#dialog-message").html(contenido);
        $("#dialog-message").dialog("open");
    });

    $(".opcion").click(function () {
        var id = $(this).attr("data-ambiente");
        $(".opcion").removeClass('marcado');
        $(this).addClass('marcado');
        var contador = 0;
        var contadorAprobado = 0;
        $("table tbody tr").each(function () {
            var idFila = $(this).attr("data-ambiente");
            if (id == idFila) {
                $(this).css("display", "table-row");
                var dataAprobado = $(this).attr("data-aprobado");
                if (dataAprobado != "1") {
                    contador++;
                } else {
                    contadorAprobado++;
                }
            } else {
                $(this).css("display", "none");
            }
        });
        if (contadorAprobado == 0) {
            $(".seccionAprobados").css("display", "none");
        }
        else {
            $(".seccionAprobados").css("display", "block");
        }
        $("#numSolPendientes").html(contador + " Solicitudes");
    });
    $("#btnActualizarSistema").click(function () {
        if ($.trim($("#txtPrimeraSolicitud").val()) != "") {
            // Han especificado informacion en este campo
            var interesados = $.trim($("#txtPrimeraSolicitud").val());
            var listaemails = interesados.split(';');
            var cantemails = listaemails.length;
            var validos = true;
            for (var i = 0; i < cantemails; i++) {
                var email = $.trim(listaemails[i]);
                if (!isValidEmailAddress(email)) {
                    alert("El correo " + email + " no es un correo valido.");
                    validos = false;
                    return;
                }
            }
        }
        $("#frmDatosSistema").submit();
    });
    function isNumber(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }
    $("#txtUsuario").on("keypress", function (e) {
        if (e.keyCode == 13) {
            $("#txtClave").focus();
        }
    });
    $("#txtClave").on("keypress", function (e) {
        if (e.keyCode == 13) {
            $("#btnEnviar").click();
        }
    });
    $("#btnListarObjetos").on("click", function () {
        if ($.trim($("#txtCodigoProyecto").val()) == "") {
            alert("Especifique un codigo de proyecto");
            $("#txtCodigoProyecto").focus();
            return;
        }
        if ($("#cboAmbiente").val() == "") {
            alert("Especifique un ambiente");
            $("#cboAmbiente").focus();
            return;
        }
        if ($("#cboTipoFormulario").val() == "") {
            alert("Especifique un tipo de formulario");
            $("#cboTipoFormulario").focus();
            return;
        }
        $("#frmListarObjetos").submit();
    });
    // Responsables
    $("#btnCrearResponsable").click(function () {
        if ($.trim($("#txtNombreResponsable").val()) == "") {
            alert("Ingrese un nombre de Gerencia");
            return;
        }
        $("#frmNuevoResponsable").submit();
    });
    $("#btnConsultarResponsable").click(function () {
        $("#frmCatalogoResponsable").submit();
    });
    $("#btnActualizarResponsable").click(function () {
        if ($.trim($("#txtNombreResponsable").val()) == "") {
            alert("Ingrese un nombre de Gerencia");
            return;
        }
        $("#frmDatosResponsable").submit();
    });

    // Tipo de Proyecto
    $("#btnCrearTipoProyecto").click(function () {
        if ($.trim($("#txtNombreTipoProyecto").val()) == "") {
            alert("Ingrese un nombre de tipo de proyecto.");
            $("#txtNombreTipoProyecto").focus();
            return;
        }
        $("#frmNuevoTipoProyecto").submit();
    });
    $("#btnConsultarTipoProyecto").click(function () {
        $("#frmCatalogoTipoProyecto").submit();
    });
    $("#btnActualizarTipoProyecto").click(function () {
        if ($.trim($("#txtNombreTipoProyecto").val()) == "") {
            alert("Ingrese un nombre de tipo de proyecto.");
            return;
        }
        $("#frmDatosTipoProyecto").submit();
    });

    
    function ObtenerFecha() {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();

        if (dd < 10) {
            dd = '0' + dd
        }

        if (mm < 10) {
            mm = '0' + mm
        }

        today = dd + '/' + mm + '/' + yyyy;
        return today;
    }
    $("#btnComprobarConexion").on("click", function () {
        $("#progreso").css("display", "inline");
        $.ajax({
            url: rutaAplicacion + "/Home/ComprobarConexion/" + $("#txtOracleDBUExtractConexion").val(),
            dataType: "json",
            cache: false,
            success: function (data) {
                $("#progreso").css("display", "none");
                if (data.Mensaje == "ok") {
                    $("#resultadoConexion").html("Conexion Satisfactoria");
                }
                else {
                    $("#resultadoConexion").html(data.Mensaje);
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $("#progreso").css("display", "none");
                $("#resultadoConexion").html(xhr.status + ": " + thrownError);
            }
        });
    });
    $("#btnValidarObjetos").on("click", function () {
        $("#progreso").css("display", "inline");
        var solicitudId = $(this).attr("data-solicitud");
        $.ajax({
            url: rutaAplicacion + "/Solicitud/ValidarObjeto/" + solicitudId,
            dataType: "json",
            cache: false,
            success: function (data) {
                $("#progreso").css("display", "none");
                if (data.Mensaje != "") {
                    alert(data.Mensaje);
                }
                else {
                    if (data.Objetos.length == 0) {
                        alert("La validacion fue satisfactoria.");
                    } else {
                        var html = "<div id='dvDiferenciaObjetos'><div class='table-responsive'> <table class='table table-bordered table-condensed table-hover' id='tblDiferenciaObjetos'><caption>Objetos Diferentes</caption>";
                        html = html + "<thead><tr><th>Instancia</th><th>Esquema</th><th>Diferencia</th><th>Objeto de Pase</th><th>Objeto Extract</th></tr></thead>";
                        html = html + "<tbody>";
                        for (var i = 0; i < data.Objetos.length; i++) {
                            html = html + "<tr><td>" + data.Objetos[i].Instancia + "</td><td>" + data.Objetos[i].Esquema + "</td><td><span class='mostrardiferencia puntero' id='indicador" + i + "'>" + data.Objetos[i].Nombre + "</span><div style='display:none;' id='objetoExtract" + i + "'>" + data.Objetos[i].ArchivoExtract + "</div><div style='display:none;' id='objetoPase" + i + "'>" + data.Objetos[i].ArchivoPase + "</div></td><td id='mostrarPase" + i + "' class='puntero mostrarPase'>" + data.Objetos[i].Nombre + "</td><td id='mostrarExtract" + i + "' class='puntero mostrarExtract'>" + data.Objetos[i].Nombre + "</td></tr>";
                        }
                        html = html + "</tbody></table></div><div style='display:none;margin-top:10px;border:1px;height:500px;overflow:hidden;overflow-y: scroll;' id='divResultado'></div></div>";
                        $("#resultadoValidacion").html(html);
                        $('html, body').animate({ scrollTop: 1000 }, 2000);
                    }
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $("#progreso").css("display", "none");
                alert(xhr.status + ' ' + thrownError);
            }
        });
    });
    $("#compare").dialog({
        modal: true,
        autoOpen: false,
        width: 1024,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
    $('body').on('click', '.mostrardiferencia', function () {
        var nombre = $(this).attr("id");
        var indice = nombre.substring(9);
        var objetoExtract = $("#objetoExtract" + indice).html();
        var objetoPase = $("#objetoPase" + indice).html();
        $("#dvDiferenciaObjetos").prettyTextDiff({
            cleanup: true,
            originalContent: objetoPase,
            changedContent: objetoExtract,
            diffContainer: "#divResultado"
        });
        if ($("#divResultado").css("display") != "block") {
            $("#divResultado").css("display", "block");
            $('html, body').animate({ scrollTop: 1000 }, 2000);
        }
    });
    $('body').on('click', '.mostrarPase', function () {
        var nombre = $(this).attr("id");
        var indice = nombre.substring(11);
        var objetoPase = $("#objetoPase" + indice).html();
        if ($("#divResultado").css("display") != "block") {
            $("#divResultado").css("display", "block");
            $('html, body').animate({ scrollTop: 1000 }, 2000);
        }
        $("#divResultado").html("<pre>" + objetoPase + "</pre>");
    });
    $('body').on('click', '.mostrarExtract', function () {
        var nombre = $(this).attr("id");
        var indice = nombre.substring(14);
        var objetoExtract = $("#objetoExtract" + indice).html();
        if ($("#divResultado").css("display") != "block") {
            $("#divResultado").css("display", "block");
            $('html, body').animate({ scrollTop: 1000 }, 2000);
        }
        $("#divResultado").html("<pre>" + objetoExtract + "</pre>");
    });
    $("#cboAmbiente").on("change", function () {
        var events = {
            url: rutaAplicacion + "/Proyecto/ObtenerEventos/",
            cache: false,
            data: {
                ambienteId: $(this).val()
            },
            eventRender: function (event, element) {
                element.attr('title', event.tip);
            }
        }
        $("#calendar").fullCalendar("removeEventSource", events);
        $("#calendar").fullCalendar("addEventSource", events);
    });

    $("#calendar").fullCalendar({
        lang: "es",
        firstDay: 0,
        eventLimit: true,
        events: {
            url: rutaAplicacion + "/Proyecto/ObtenerEventos/",
            cache: false,
            data: {
                ambienteId: $("#cboAmbiente").val()
            }
        },
        eventRender: function (event, element) {
            element.qtip({
                content: event.tip
            });
        }
    });

    $("#btnBuscarObjeto").on("click", function () {
        if ($.trim($("#txtNombre").val()) == "") {
            alert("Especifique un nombre de objeto");
            $("#txtNombre").focus();
            return;
        }
        var tipoObjeto = $("#cboTipoObjeto").val();
        if (tipoObjeto == "1") {
            // Objetos BD
            $("#frmBuscarObjeto").attr("action", rutaAplicacion + "/Objeto/BuscarBD");
            $("#frmBuscarObjeto").submit();
        } else if (tipoObjeto == "2") {
            $("#frmBuscarObjeto").attr("action", rutaAplicacion + "/Objeto/BuscarCRMApp");
            $("#frmBuscarObjeto").submit();
        }
    });
    $('[data-toggle="tooltip"]').tooltip();
    $('[data-toggle="popover"]').popover();
    $("#btnLimpiarFormulario").on("click", function () {
        $(".formulario").val("");
    });

    $("#btnRevertirSolicitud").on("click", function () {
        if ($.trim($("#txtNumeroSolicitud").val()) == "") {
            alert("Especifique un número de solicitud");
            $("#txtNumeroSolicitud").focus();
            return;
        }
        $("#frmRevertirSolicitud").submit();
    });
    $("#btnCrearCarpeta").on("click", function () {
        if ($.trim($("#txtRutaOrigen").val()) == "") {
            alert("Especifique una ruta origen");
            $("#txtRutaOrigen").focus();
            return;
        }
        $("#frmCrearCarpeta").submit();
    });
    $("#btnListarRollback").on("click", function () {
        if ($("#cboAmbiente").val() == "") {
            alert("Seleccione un ambiente");
            return;
        }
        $("#frmListarRollback").submit();
    });
    $("#btnMatarProcesoExcel").on("click", function () {
        $("#frmMatarProcesoExcel").submit();
    });
});
