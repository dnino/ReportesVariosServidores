
function abrirPopup(pagina) {


//    var options = 'location=1,status=1,scrollbars=1,width,height=500';
//    window.open(pagina,'Holas ','');
//  $("#modal-content").load("frmDatosServicios.aspx");
  

    var div = window.parent.document.getElementById("divPopup");
    if (div != null) {
        div.style.display = "block";
        var ifr = window.parent.document.getElementById("ifrPopup");
        if (ifr != null) {
            ifr.src = pagina;
        }
    }
    return false;
}

function cerrarPopup() {
    var div = window.parent.document.getElementById("divPopup");
    if (div != null) {
        div.style.display = "none";
        var ifr = window.parent.document.getElementById("ifrPopup");
        if (ifr != null) {
            ifr.src = "";
        }
    }
    return false;
}

function validarCampo(id, mensaje) {
    var txt = document.getElementById(id);
    if (txt.value == "") {
        alert("Ingresa " + mensaje);
        txt.focus();
        return false;
    }
}

function validarActualizar(ibn) {
    var celda = ibn.parentNode;
    var fila = celda.parentNode;
    var textos = fila.getElementsByTagName("input");
    var txtApellido = textos[0];
    if (validarCampo(txtApellido.id, "Apellido") == false) return false;
    var txtNombre = textos[1];
    if (validarCampo(txtNombre.id, "Nombre") == false) return false;
    var txtFechaNac = textos[2];
    if (validarCampo(txtFechaNac.id, "Fecha Nac") == false) return false;
    return true;
}

function validarDatosEmpleado() {
    if (validarCampo("txtApellido", "Apellido") == false) return false;
    if (validarCampo("txtNombre", "Nombre") == false) return false;
    if (validarCampo("txtFechaNac", "Fecha de Nacimiento") == false) return false;
    return true;
}

function iniciarPopup() {
    window.onload = function () {
        var btnProcesar = document.getElementById("btnProcesar");
        if (btnProcesar != null) {
            btnProcesar.onclick = function () {
                return validarDatosEmpleado();
            }
        }
    }
}

function listarEmpleados() {
    var btn = window.top.document.getElementById("btnListarEmpleados");
    if (btn != null) {
        btn.click();
        return false;
    }
}