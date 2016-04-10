/******************************************************
    PARA BLOQUEAR "EL PEGAR TEXTO EN EL DOCUMENTO"
*/

//document.oncontextmenu = function () { return false }

/******************************************************/

function ValidaSoloNumeroCopiar(field) {
    event.returnValue = false;
    var valor = window.clipboardData.getData("Text");
    var patron = /^([0-9])*$/;
    if (!valor.match(patron)) {
        return false;
    }

    event.returnValue = true;
} 

function checkKey(evt) {
    if (evt.ctrlKey)
        return false;
} 
function ValidaCampoTipo(campo, tipo) {

    var patron

    switch (tipo) {
        case "Fecha": patron = /^(0?[1-9]|[1,2][0-9]|3[0,1])\/(0?[1-9]|1[0,1,2])\/\d{4}$/; break;
        case "Ruc": patron = /^\d{11}/; break;
        case "Dni": patron = /^\d{8}/; break;
        case "Email": patron = /^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$/; break;
        case "Periodo": patron = /^(0?[1-9]|1[0,1,2])\/\d{4}$/; break;
        case "Digito": patron = /\d/; break;
        case "Entero": patron = /([\+\-])?\d/; break;
        case "EnteroPositivo": patron = /\+?\d/; break;
        case "Decimal": patron = /[\+\-]?(\.\d+)|(\d+\.?)|(\d+.\d+)/; break;
        case "DecimalPositivo": patron = /\+?(\.\d+)|(\d+\.?)|(\d+.\d+)/; break;
        default: campo.focus(); break;
    }
    if (!campo.value.match(patron) && campo.value != "") {
        campo.focus();
    }
}
/** 
* @author Rodriguez Jose
* @since v 1.0
* <p>ValidaMonto2Decimal :Valida numeros con 2 decimal
* @param campo		     :Objeto que se evalua. Caja de texto
*/
function ValidaMonto2Decimal(campo) {
    var valor = campo.value;
    var patron = /^(\d{0,1})(\,?)(\d{0,3})(\,?)(\d{0,3})(\,?)(\d{0,3})(\.\d{0,2})?$/;
    if (!campo.value.match(patron) && campo.value != "") {
        alert("Formato incorrecto. Solo se permiten 10 enteros y 2 decimales");
        campo.focus();
        return false;
    }
    return true;
}
function ValidaMonto4Decimal(campo) {
    var valor = campo.value;
    var patron = /^(\d{0,1})(\,?)(\d{0,3})(\,?)(\d{0,3})(\,?)(\d{0,3})(\.\d{0,4})?$/;
    if (!campo.value.match(patron) && campo.value != "") {
        alert("Formato incorrecto. Solo se permiten 10 enteros y 4 decimales");
        campo.focus();
        return false;
    }
    return true;
}
function ValidaMonto7Decimal(campo) {
    var valor = campo.value;
    var patron = /^(\d{0,2})(\,?)(\d{0,3})(\,?)(\d{0,3})(\.\d{0,7})?$/;
    if (!campo.value.match(patron) && campo.value != "") {
        alert("Formato incorrecto. Solo se permiten 8 enteros y 7 decimales");
        campo.focus();
        return false;
    }
    return true;
}
/** 
* @author Rodriguez Jose
* @since v 1.0
* <p>formateoAMilesDecimales :Valida numeros con 2 decimal
* @param campo              :valor ingresado en el elemento. por ejemplo: en la caja de texto.
*/
function formateoAMilesDecimales(campo) {
    var num = campo.value;        
    if (num == null)
        return '';
    num = num.toString().replace(/\,/g, '');
    
    var nroNegativo;
    if (num < 0) { nroNegativo = true; } else { nroNegativo = false; }    
    if (nroNegativo) { num = num.toString().replace(/-/g, ''); }    
    if (isNaN(num)) num = "0";
    cents = Math.floor((num * 100 + 0.5) % 100);
    num = Math.floor((num * 100 + 0.5) / 100).toString();
    if (cents < 10) cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++) {
        num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));
    }
    campo.value = (((nroNegativo) ? '-' : '') + num + '.' + cents);
}

function formateoAMilesDecimales7(campo) {
    var num = campo.value;
    if (num == null)
        return '';
    num = num.toString().replace(/\,/g, '');

    var nroNegativo;
    if (num < 0) { nroNegativo = true; } else { nroNegativo = false; }
    if (nroNegativo) { num = num.toString().replace(/-/g, ''); }
    if (isNaN(num)) num = "0";
    cents = Math.floor((num * 10000000 + 0.000005) % 10000000);
    num = Math.floor((num * 10000000 + 0.000005) / 10000000).toString();

    var dec = cents;

    if (cents < 1000000) dec = "0" + cents;
    if (cents < 100000) dec = "00" + cents;
    if (cents < 10000) dec = "000" + cents;
    if (cents < 1000) dec = "0000" + cents;
    if (cents < 100) dec = "00000" + cents;
    if (cents < 10) dec = "000000" + cents;

    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++) {
        num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));
    }
    campo.value = (((nroNegativo) ? '-' : '') + num + '.' + dec);
}
function ObtieneNumFechaActual() {
    var f = new Date();
    var ano = f.getFullYear();
    var mes = f.getMonth() + 1;
    var dia = f.getDate();

    var fechaActual = "";

    fechaActual = fechaActual + ano;

    if (mes < 10) {
        fechaActual = fechaActual + "0" + mes;
    }
    else {
        fechaActual = fechaActual + mes;
    }

    if (dia < 10) {
        fechaActual = fechaActual + "0" + dia;
    }
    else {
        fechaActual = fechaActual + dia;
    }
    return fechaActual;
}
function ValidaCampoPatron(campo, patron) {
    if (!campo.value.match(patron) && campo.value != "") {
        campo.focus();
    }
}
function ValidaCaracterTipo(e, tipo) {
    var patron
    switch (tipo) {
        case "Fecha": patron = /[\/\d]/; break;
        case "Digito": patron = /\d/; break;
        case "Numero": patron = /[\d\+\-\.\,]/; break;
        case "Email": patron = /[\w\.\-\_\@]/; break;
        default: campo.focus(); break;
    }
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8 || tecla == 46) return true;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function ValidaCaracterPatron(evento, patron) {
    tecla = (document.all) ? evento.keyCode : evento.which;
    if (tecla == 8 || tecla == 46) return true;
    te = String.fromCharCode(patron);
    return patron.test(te);
}

function nocaracteresespeciales() {
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
    if (tecla == 8 || tecla == 46) return true; // 3
    patron = /[A-Za-záéíóúñÑ0-9\s]/; // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6
    if (sw == false)
    { window.event.keyCode = 0; }
}

function alphanumericoFam() {
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
     
    if (tecla == 8 || tecla == 46 ) { return true; } // 3
      if (tecla == 40) { sw = true; } // (
    if (tecla == 41) { sw = true; } // )
    if (tecla == 45) { sw = true; } // Guión

    patron = /[A-Za-zÁÉÍÓÚáéíóúñÑ0-9;.,\s()-]/;  // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6
    if (sw == false)
    { window.event.keyCode = 0; }
}
function ValidaAlphanumericoFam(obj) { 
 var valor = obj.value.toLowerCase();
 if (valor != "") {
     var regex = /^[A-Z0-9 a-záéíó&úÁÉÍÓÚ\s*ñÑ.;,()-]*$/i 
     if (!regex.exec(valor)) {
         alert("Se ha ingresado caracteres inválidos en el campo; por favor corregir el dato");
         obj.focus();
         return false;
     }
 }

}


function alphanumerico() {
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
     
    if (tecla == 8 || tecla == 46 ) { return true; } // 3

    patron = /[A-Za-zÁÉÍÓÚáéíóúñÑ0-9;.,\s]/;  // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6
    if (sw == false)
    { window.event.keyCode = 0; }
}

function alphanumerico2() {
    //% & -  '  "
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
    //alert(tecla);

    patron = /[A-Za-zÁÉÍÓÚáéíóúñÑ0-9;.,%&\s]/;  // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6

    if (tecla == 8 || tecla == 46) { sw = true; } // 3
    //if (tecla == 34) { sw = true; } // Comilla Doble
    //if (tecla == 39) { sw = true; } // Comilla Simple
    if (tecla == 40) { sw = true; } // (
    if (tecla == 41) { sw = true; } // )
    if (tecla == 45) { sw = true; } // Guión
    if (tecla == 47) { sw = true; } // SLASH
    if (tecla == 64) { sw = true; } // ARROBA
    if (tecla == 95) { sw = true; } // _
    if (tecla == 58) { sw = true; } // :
    if (tecla == 36) { sw = true; } // $
    if (tecla == 92) { sw = true; } // \
    if (tecla == 38) { sw = false; } // \

    if (sw == false)
    { window.event.keyCode = 0; }
}

function alphanumerico3() {
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
     
    if (tecla == 8 || tecla == 46 ) { return true; } // 3

    patron = /[A-Za-zÁÉÍÓÚáéíóúñÑ0-9%\s]/;  // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6
    if (sw == false)
    { window.event.keyCode = 0; }
}

function alphanumerico4() {     //  Material -> Para el campo "Nombre"
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
    //alert(tecla);

    patron = /[A-Za-zÁÉÍÓÚáéíóúñÑ0-9.,%#+*\s]/;  // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6

    if (tecla == 8 || tecla == 46) { sw = true; } // 3
    if (tecla == 34) { sw = true; } // Comilla Doble
    if (tecla == 39) { sw = true; } // Comilla Simple
    if (tecla == 40) { sw = true; } // (
    if (tecla == 41) { sw = true; } // )
    if (tecla == 45) { sw = true; } // Guión
    if (tecla == 47) { sw = true; } // SLASH
    //if (tecla == 64) { sw = true; } // ARROBA
    //if (tecla == 95) { sw = true; } // _
    if (tecla == 58) { sw = true; } // :
    //if (tecla == 36) { sw = true; } // $
    if (tecla == 92) { sw = true; } // \
    if (tecla == 38) { sw = false; } // \

    if (sw == false)
    { window.event.keyCode = 0; }
}

function VerificaRazonSocial() {
    //% & -  '  "
var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
    //alert(tecla);

    patron = /[A-Za-zÁÉÍÓÚáéíóúñÑ0-9;.,%&\s]/;  // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6

    if (tecla == 8 || tecla == 46) { sw=true; } // 3
    if (tecla == 34) { sw=true; } // Comilla Doble
    if (tecla == 39) { sw = true; } // Comilla Simple
    if (tecla == 45) { sw = true; } // Guión

    if (sw == false)
    { window.event.keyCode = 0; }
}

function VerificaInputStringBuscador() {
    //% & -  '  "
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
    //alert(tecla);

    patron = /[A-Za-zÁÉÍÓÚáéíóúñÑ0-9%\s]/;  // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6

    if (tecla == 8 || tecla == 46) { sw = true; } // 3
    //if (tecla == 34) { sw = true; } // Comilla Doble
    //if (tecla == 39) { sw = true; } // Comilla Simple
    //if (tecla == 45) { sw = true; } // Guión

    if (sw == false)
    { window.event.keyCode = 0; }
}

function ValidaInputStringBuscador(obj) {
    var valor = obj.value.toLowerCase();
    if (valor != "") {
        var regex = /^[A-Za-z0-9áéíó&úÁÉÍÓÚñÑ%\s*]*$/i
        if (!regex.exec(valor)) {
            alert("Se ha ingresado caracteres inválidos en el campo; por favor corregir el dato");
            obj.focus();
            return false;
        }
    }
    //alert();
}

function solonumeros() {
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2

    if (tecla == 8) return true; // 3
    patron = /[0-9\s]/; // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6
    if (tecla == 32) { sw = false; } //
    if (sw == false)
    { window.event.keyCode = 0; }
   
}

function solonumeroyletras() {
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2

    if (tecla == 8) return true; // 3
    patron = /[A-Za-zÁÉÍÓÚáéíóúñÑ0-9\s]/; // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6

    if (sw == false)
    { window.event.keyCode = 0; }
}

function ValidaSolonumeroyYletras(obj) {
    var valor = obj.value.toLowerCase();
    if (valor != "") {
        var regex = /^[A-Za-z0-9áéíó&úÁÉÍÓÚñÑ\s*]*$/i
        if (!regex.exec(valor)) {
            alert("Se ha ingresado caracteres inválidos en el campo; por favor corregir el dato");
            obj.focus();
            return false;
        }
    }
}

/*
Modificacion:   M01
Asunto      :   Funciones Ajustadas
Fecha       :   10/10/2012
Autor       :   Samuel Gómez Luna
*/
function ValidaSolonumeroyYletrasDef1(obj) {
    var valor = obj.value.toLowerCase();
    if (valor != "") {
        var regex = /^[A-Za-z0-9áéíó&úÁÉÍÓÚñÑ\s*]*$/i
        var sw=true;
        var rpt;
        rpt=regex.exec(valor);
        if(!rpt){sw=false;}
        var str="";
        if(!rpt)
        {
            for(a=0;a<obj.value.length;a++)
            {
                str=obj.value.substring(a,a+1);
                if(str=="("){ sw=true; }
                else if(str==")"){ sw=true; }
                else if(str=="-"){ sw=true; }
                else if(str=="."){ sw=true; }
                else if(str=="#"){ sw=true; }
                else if(str=='"'){ sw=true; }
                else if(str=="/"){ sw=true; }
                else if(str==":"){ sw=true; }
                else if(str==","){ sw=true; }
                else if(str=="+"){ sw=true; }
                else if(str=="%"){ sw=true; }
                else if(str=="*"){ sw=true; }
            }
        }
        //alert(sw);
        if (sw==false) {
            alert("Se ha ingresado caracteres inválidos en el campo; por favor corregir el dato");
            obj.focus();
            return false;
        }
    }
}
/*
FIN M01
*/

/*
function solonumerosingresados(obj) {
    var cadena = obj.value;
    patron = /[0-9\s]/; // 4

    sw = patron.test(cadena); // 6
    if (sw == false) {
        alert("Solo debe ingresar Numeros");
        obj.focus();
    }
}
*/
function solodecimales() {
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
    if (tecla == 8) return true; // 3
    patron = /[0-9.\s]/; // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6
    if (sw == false)
    { window.event.keyCode = 0; }
}

function ValidaMontoPrecio(campo) {
    var sw = true;
    var e; 
    e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
    if (tecla == 8) return true; // 3
    patron = /[0-9.\s]/; // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6
    if (sw == false)
    { window.event.keyCode = 0; }

    var valor = campo.value;    
    var patron = /^(\d{0,2})(\,?)(\d{0,3})(\,?)(\d{0,3})(\.\d{0,7})?$/;
    
    if (!valor.match(patron) && valor != "") {        
        window.event.keyCode = 0;
    }
    return true;

}

function formatodecimal(obj) {
    var nchar = 0;
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
    if (tecla == 8) return true; // 3
    patron = /[0-9.\s]/; // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6
    for (a = 0; a < obj.value.length; a++) {
        if (obj.value.substring(a, a + 1) == ".") {nchar++; }
    }
    if (sw == false)
    { window.event.keyCode = 0; }
    if (nchar > 0 && tecla==46)
    { window.event.keyCode = 0; }
}

function sololetras() {
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
    if (tecla == 8 || tecla == 46) return true; // 3
    patron = /[A-Za-záéíóú\s]/; // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6
    if (sw == false)
    { window.event.keyCode = 0; }
}

function solonumerosyletras() {
    if ((window.event.keyCode > 47) && (window.event.keyCode < 58))
    { return; }
    else if ((window.event.keyCode > 64) && (window.event.keyCode < 91))
    { return; }
    else if ((window.event.keyCode > 96) && (window.event.keyCode < 123))
    { return; }
    else if (window.event.keyCode == 8)
    { return; }
    else if (window.event.keyCode == 32)
    { return; }
    else
    { window.event.keyCode = 0; }
}

function formatoemail() {
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
    if (tecla == 8 || tecla == 46) return true; // 3
    patron = /[A-Za-z@._0-9\s]/; // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6
    if (sw == false)
    { window.event.keyCode = 0; }
}

function validaEmail(obj) {
    var valor = obj.value.toLowerCase();
    if (valor != "") {
        //        var re = /^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,3})$/;
        var re = /^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$/i;
        if (!re.exec(valor)) {
            alert("El correo ingresado no es correcto");
            obj.focus();
            //return false;
        } //else {
        //return true;
        //}        
    }

}

function formatearfecha(obj) {

    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
    if (tecla !=8 && tecla!=46) {
        if (obj.value.length == 2) {
            obj.value = obj.value + '/';
        }
        if (obj.value.length == 5) {
            obj.value = obj.value + '/';
        }
    }
}

function formatofechadmy(obj) {
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
    //    if (tecla == 8 || tecla == 46) return true; // 3
    patron = /[_0-9\s]/; // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6
    if (sw == true) {
        if (window.event.keyCode != 8 && window.event.keyCode != 46) {
            if (obj.value.length > 2 && obj.value.substring(2, 3) != "/" && obj.value.substring(1, 2) != "/" && obj.value.substring(4, 5) != "/") {
                obj.value = obj.value.substring(0, 2) + "/" + obj.value.substring(2, obj.value.length);
            }
            if (obj.value.length > 5 && obj.value.substring(5, 6) != "/" && obj.value.substring(1, 2) != "/" && obj.value.substring(4, 5) != "/") {
                obj.value = obj.value.substring(0, 5) + "/" + obj.value.substring(5, obj.value.length);
            }
        }
        if (obj.value.length > 10) { obj.value = obj.value.substring(0, 10); }
    }
    else { window.event.keyCode = 0; }
}

function formatofechamy(obj) {
    if (window.event.keyCode != 8 && window.event.keyCode != 46) {
        if (obj.value.length > 2 && obj.value.substring(2, 3) != "/" && obj.value.substring(1, 2) != "/") {
            obj.value = obj.value.substring(0, 2) + "/" + obj.value.substring(2, obj.value.length);
        }
    }
    if (obj.value.length > 7) { obj.value = obj.value.substring(0, 7); }
}

function formatohorahm(obj) {
    if (window.event.keyCode != 8 && window.event.keyCode != 46) {
        if (obj.value.length > 2 && obj.value.substring(2, 3) != ":" && obj.value.substring(1, 2) != ":") {
            obj.value = obj.value.substring(0, 2) + ":" + obj.value.substring(2, obj.value.length);
        }
    }
    if (obj.value.length > 5) { obj.value = obj.value.substring(0, 5); }
}

function getCursorPos(campo) {
    if (document.selection) {// IE Support 
        campo.focus();                                        // Set focus on the element 
        var oSel = document.selection.createRange();        // To get cursor position, get empty selection range 
        oSel.moveStart('character', -campo.value.length);    // Move selection start to 0 position 
        campo.selectionEnd = oSel.text.length;                    // The caret position is selection length 
        oSel.setEndPoint('EndToStart', document.selection.createRange());
        campo.selectionStart = oSel.text.length;
    }
    return { start: campo.selectionStart, end: campo.selectionEnd };
}

function cupper(obj) {
    var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which;
    //Izquierda 37      Arriba 38       Abajo 40        Derecha 39
    if (tecla != 37 && tecla != 38 && tecla != 39 && tecla != 40) {
        obj.value = obj.value.toUpperCase();

        //getCursorPos(obj);

        if (obj.style.textTransform != "uppercase") { obj.style.textTransform = "uppercase"; }
    }
}

function getFechaHoy() {
    var fecha_hoy = new Date();
    var anio = fecha_hoy.getFullYear();
    var mes = fecha_hoy.getMonth()+1;
    var dia = fecha_hoy.getDate();
    if (dia <= 9) {
        dia = '0' + dia;
    }
    if (mes <= 9) {
        mes = '0' + mes;
    }
    return dia + '/' + mes + '/' + anio;
}

function getNumFechaYMD(fecha) {
    var nfecha = 0;
    fecha = fecha.replace("/", "");
    fecha = fecha.replace("/", "");
    fecha = fecha.substring(4, 8) + "" + fecha.substring(2, 4) + "" + fecha.substring(0, 2);
    nfecha = parseInt(fecha);
    return nfecha;
}

function daysInMonth(humanMonth, year) {
    var f = new Date(year || new Date().getFullYear(), humanMonth, 0);
    return f.getDate();
}

function ValidaFecha(obj) {
    if (obj.value.length != 10 && obj.value.length > 0) {
        alert("Fecha Incompleta");
        obj.focus();
    }
    if (obj.value.length == 10 && obj.value.length > 0) {
        var dia = parseInt(obj.value.substring(0, 2));
        if (obj.value.substring(0, 1) == "0") {dia = parseInt(obj.value.substring(1, 2)); }
        var mes = parseInt(obj.value.substring(3, 5));
        if (obj.value.substring(3, 4) == "0") { mes = parseInt(obj.value.substring(4, 5)) }
        var anio = parseInt(obj.value.substring(6, 10));
        var lastday = daysInMonth(mes, anio);

        var regex = /^[A-Z/a-záéíó&úÁÉÍÓÚñÑ\s*]*$/i
        var swregex = true;
        if (regex.test(obj.value.toLowerCase())) {
            swregex = false;
        }

        if (dia > lastday || dia == 0 || mes > 12 || mes == 0 || swregex == false) {
            alert("Fecha Incorrecta");
            obj.focus();
        }
    }
}

function ValidaURL(obj) {

    var url = obj.value.toLowerCase();
    if (url != "") {
        var regex = /^(ht|f)tps?:\/\/\w+([\.\-\w]+)?\.([a-z]{2,4}|travel)(:\d{2,5})?(\/.*)?$/i
        if (!regex.test(url)) {
            alert("La dirección Web es incorrecta. Ejemplo : http://www.pagina.com");
            obj.focus();
        }        
    }

}

function validaNumeroyLetras(obj) {
    var valor = obj.value.toLowerCase();
    if (valor != "") {
        var regex = /^[A-Za-z0-9áéíó&úÁÉÍÓÚñÑ\s*]*$/i
        if (!regex.exec(valor)) {
            alert("Se ha ingresado caracteres inválidos en el campo; por favor corregir el dato");
            obj.focus();
            return false;
        }
    }
}

function validaNumeros(obj) {
    var valor = obj.value.toLowerCase();
    if (valor != "") {
        var regex = /^[0-9]*$/i
        if (!regex.exec(valor)) {
            alert("Se ha ingresado caracteres inválidos en el campo; por favor corregir el dato");
            obj.focus();
            return false;
        }
    }
   
 
}

function validaLetras(obj) {
    var valor = obj.value.toLowerCase();
    if (valor != "") {
        var regex = /^[A-Za-záéíóúÁÉÍÓÚñÑ\s*]*$/i
        if (!regex.exec(valor)) {
            alert("Se ha ingresado caracteres inválidos en el campo; por favor corregir el dato");
            obj.focus();
            return false;
        }
    
    }

}

function ValidaAlphanumerico(obj) { 
 var valor = obj.value.toLowerCase();
 if (valor != "") {
     var regex = /^[A-Z0-9 a-záéíó&úÁÉÍÓÚ\s*ñÑ.;,-]*$/i
     if (!regex.exec(valor)) {
         alert("Se ha ingresado caracteres inválidos en el campo; por favor corregir el dato");
         obj.focus();
         return false;
     }
 }

}

function ValidaFechaMY(obj) {
    if (obj.value.length != 7 && obj.value.length > 0) {
        alert("El periodo ingresado es incorrecto; por favor verifique"); obj.focus();
    }
    if (obj.value.length == 7 && obj.value.length > 0) {
        var mes = parseInt(obj.value.substring(0, 2));
        var anio = parseInt(obj.value.substring(3, 7));
        var lastday = daysInMonth(mes, anio);
               if ((anio < 1900) || (anio > 2050) || mes > 12 || mes == 0) {
            alert("El periodo ingresado es incorrecto; por favor verifique"); obj.focus();
        }
      
    }
}


function formatofechamy(obj) {
    if (window.event.keyCode != 8 && window.event.keyCode != 46) {
        if (obj.value.length > 2 && obj.value.substring(2, 3) != "/" && obj.value.substring(1, 2) != "/") {
            obj.value = obj.value.substring(0, 2) + "/" + obj.value.substring(2, obj.value.length);
        }
    }
    if (obj.value.length > 7) { obj.value = obj.value.substring(0, 7); }
}

function formatofechamyF(obj) {
    var sw = true; var e; e = window.event;
    tecla = (document.all) ? e.keyCode : e.which; // 2
       patron = /[_0-9\s]/; // 4
    te = String.fromCharCode(tecla); // 5
    sw = patron.test(te); // 6
    if (sw == true) {
        if (window.event.keyCode != 8 && window.event.keyCode != 46) {
            if (obj.value.length > 2 && obj.value.substring(2, 3) != "/" && obj.value.substring(1, 2) != "/") {
                obj.value = obj.value.substring(0, 2) + "/" + obj.value.substring(2, obj.value.length);
            }
        }
        if (obj.value.length > 7) { obj.value = obj.value.substring(0, 7); }
    }
    else { window.event.keyCode = 0; }
}

function TextAreaMaxlength(obj, max) {
    if (obj.value.length > max) {
        obj.value = obj.value.substring(0, max);
    }
}

function OnblurUpper(obj){
    obj.value=obj.value.toUpperCase();
}

//    function ValidaCaractere(evento) {
//        if (evento.keyCode < 48 || evento.keyCode > 39)
//            evento.returnValue = false;
//    }
////    function ValidaCaracteresEnteros(evento) {
//        if ((evento.keyCode >= 45 && evento.keyCode <= 57) || (evento.keyCode == 43) || (evento.keyCode == 45))
//            evento.returnValue = true;
//        else
//            evento.returnValue = false;
//    }
//    function ValidaCaracteresEnterosPositivos(evento) {                         .                           +                       ,
//        if ((evento.keyCode >= 45 && evento.keyCode <= 57) || (evento.keyCode == 43) || (evento.keyCode == 44) || (evento.keyCode == 46))
//            evento.returnValue = true;
//        else
//            evento.returnValue = false;
//    }

//    function ValidaCaracteresFecha(evento) {//                                     /
//        if ((evento.keyCode >= 45 && evento.keyCode <= 57) || (evento.keyCode == 47) )
//            evento.returnValue = true;
//        else
//            evento.returnValue = false;
//    }

//    function ValidaCaracteresSoloLetras(evento) {
//        if (evento.keyCode < 45 || evento.keyCode > 57)
//            evento.returnValue = false;
//    }

//    function val(e) {
//    tecla = (document.all) ? e.keyCode : e.which;
////    e.returnValue = true;
//    //if (tecla==8) return true;
//    patron =/[A-Za-z]/;
//    te = String.fromCharCode(tecla);
//    return (patron.test(te));
////           {e.returnValue = false;}
////    return e.returnValue; 

//}