function js_ValidaCaracteres(e, caracteres, especiales) {
    key = e.keyCode || e.which;
    //alert(key);
    tecla = String.fromCharCode(key).toLowerCase();
    letras = caracteres;
    if (especiales) especiales = [8, 9, 37, 38, 39, 40, 46];

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial)
        return false;
}

function js_soloNumeros(control) {
    re = /[^0-9]/;
    if (re.test($('#' + control).val())) {
        $('#' + control).val('');
    }
}

function js_soloNumeros2(event) {
    var charCode = (event.which) ? event.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function js_soloAlfaNumerico(control) {
    re = /[^a-zA-Z0-9]/;
    if (re.test($('#' + control).val())) {
        $('#' + control).val('');
    }
}

function js_RestarFechas(f1, f2) {
    var aFecha1 = f1.split('/');
    var aFecha2 = f2.split('/');
    var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
    var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
    var dif = fFecha2 - fFecha1;
    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
    return dias;
}

function js_ValidaFecha(fecha) {
    var arreglo = fecha.split("/");

    if (arreglo.length != 3)
        return false;

    if (!parseInt(arreglo[0], 10) || !parseInt(arreglo[1], 10) || !parseInt(arreglo[2]))
        return false;

    var dia = parseInt(arreglo[0], 10);
    var mes = parseInt(arreglo[1], 10);
    var anio = parseInt(arreglo[2]);

    if (dia < 1 || dia > 31 || mes < 1 || mes > 12 || anio < 1)
        return false;

    switch (mes) {
        case 4:
        case 6:
        case 9:
        case 11:
            if (dia > 30)
                return false;
            break;
        case 2:
            if (js_esBisiesto(anio)) {
                if (dia > 29)
                    return false;
            }
            else {
                if (dia > 28)
                    return false;
            }
    }
    return true;
}

function js_esBisiesto(anio) {
    if ((anio % 100 != 0) && ((anio % 4 == 0) || (anio % 400 == 0))) {
        return true;
    }
    else {
        return false;
    }
}


function js_ValidaIntervalo(intervalo) {
    var primero = intervalo.substring(0, 1);
    var valor = intervalo.substring(1, intervalo.length);

    if (primero != "+" && primero != "-")
        return false;

    if (!parseInt(valor))
        return false;

    return true;
}

function js_fechaSumaMeses(fecha, intervalo) {
    var arrayFecha = fecha.split('/');
    var interv = intervalo.substring(1, intervalo.length);
    var operacion = intervalo.substring(0, 1);
    var dia = arrayFecha[0];
    var mes = arrayFecha[1];
    var anio = arrayFecha[2];
    var fechaInicial = new Date(anio, mes - 1, dia);
    var fechaFinal = fechaInicial;
    //fechaFinal.setDate(fechaInicial.getDate() + parseInt(intervalo));
    if (operacion == "+")
        fechaFinal.setMonth(fechaInicial.getMonth() + parseInt(intervalo));
    else
        fechaFinal.setMonth(fechaInicial.getMonth() - parseInt(intervalo));

    dia = fechaFinal.getDate();
    mes = fechaFinal.getMonth() + 1;
    anio = fechaFinal.getFullYear();

    dia = (dia.toString().length == 1) ? "0" + dia.toString() : dia;
    mes = (mes.toString().length == 1) ? "0" + mes.toString() : mes;

    return dia + "/" + mes + "/" + anio;
}

function js_fechaSumaDias(fecha, intervalo) {
    var arrayFecha = fecha.split('/');
    var interv = intervalo.substring(1, intervalo.length);
    var operacion = intervalo.substring(0, 1);
    var dia = arrayFecha[0];
    var mes = arrayFecha[1];
    var anio = arrayFecha[2];
    var fechaInicial = new Date(anio, mes - 1, dia);
    var fechaFinal = fechaInicial;

    fechaFinal.setDate(fechaInicial.getDate() + parseInt(intervalo));

//    if (operacion == "+")
//        fechaFinal.setDate(fechaInicial.getDate() + parseInt(intervalo));
//    else
//        fechaFinal.setDate(fechaInicial.getDate() + parseInt(intervalo));

    dia = fechaFinal.getDate();
    mes = fechaFinal.getMonth() + 1;
    anio = fechaFinal.getFullYear();

    dia = (dia.toString().length == 1) ? "0" + dia.toString() : dia;
    mes = (mes.toString().length == 1) ? "0" + mes.toString() : mes;

    return dia + "/" + mes + "/" + anio;
};


function js_NuevaFecha(fecha, frecuencia) {
    var intervalo;
    var vfechaNueva;

    intervalo = js_ObtenerIntervalo(frecuencia);

    if (js_ValidaFecha(fecha)) {
        if (js_ValidaIntervalo(intervalo)) {
            vfechaNueva = js_fechaSumaMeses(fecha, intervalo);
        }
    }

    return vfechaNueva;
}

function js_ObtenerIntervalo(frecuencia) {
    var intervalo = "+1";

    if (frecuencia == 8)
        intervalo = "+4"; // CuaTrimestral

    if (frecuencia == 5)
        intervalo = "+1"; // Mensual

    if (frecuencia == 4)
        intervalo = "+2"; //  Bimestral

    if (frecuencia == 3)
        intervalo = "+3"; // Trimestral

    if (frecuencia == 2)
        intervalo = "+6"; // Semestral

    if (frecuencia == 1)
        intervalo = "+12"; // Anual

    return intervalo;
}


function SoloNumeroDecimal(e, field) {
    key = e.keyCode ? e.keyCode : e.which
    // backspace
    if (key == 8) return true

    // 0-9 a partir del .decimal  
    if (field.value != "") {
        if ((field.value.indexOf(".")) > 0) {
            //si tiene un punto valida dos digitos en la parte decimal
            if (key > 47 && key < 58) {
                if (field.value == "") return true
                //regexp = /[0-9]{1,10}[\.][0-9]{1,3}$/
                regexp = /[0-9]{3}$/
                return !(regexp.test(field.value))
            }
        }
    }
    // 0-9 
    if (key > 47 && key < 58) {
        if (field.value == "") return true
        regexp = /[0-9]{2}/
        return !(regexp.test(field.value))
    }
    // .
    if (key == 46) {
        if (field.value == "") return false
        regexp = /^[0-9]+$/
        return regexp.test(field.value)
    }
    // other key
    return false
}
function validateFloatKeyPress(el, evt, ints, decimals) {

    //alert(el.value);
    // El punto lo cambiamos por la coma
    if (evt.keyCode == 44) {
        evt.keyCode = 46;
    }

    // Valores numéricos
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57)) {
        return false;
    }

    // Sólo una coma
    if (charCode == 46) {
        if (el.value.indexOf(".") !== -1) {
            return false;
        }

        return true;
    }

    // Determinamos si hay decimales o no
    if (el.value.indexOf(".") == -1) {
        // Si no hay decimales, directamente comprobamos que el número que hay ya supero el número de enteros permitidos
        if (el.value.length >= ints) {
            return false;
        }
    }
    else {

        // Damos el foco al elemento
        el.focus();

        // Para obtener la posición del cursor, obtenemos el rango de la selección vacía
        //=== INI LBENITES 29/04/2015 ===
        var oSel;
        var savedrange;
        //var oSel = window.getSelection();

        if (window.getSelection) {
            if (window.getSelection().empty) {  // Chrome
                oSel = window.getSelection();
            } else if (window.getSelection().removeAllRanges) {  // Firefox
                oSel = window.getSelection().removeAllRanges();
            }
        } else if (document.selection) {  // IE?
            oSel = document.selection;
        }

        // Movemos el inicio de la selección a la posición 0
        if (window.getSelection) {  // all browsers, except IE before version 9
            var selection = window.getSelection();
            if (selection.rangeCount > 0) {
                oSel.getRangeAt(0);
            }
        }
        else {
            if (document.selection) {   // Internet Explorer
                var range = document.selection.createRange();
                range.getBookmark();
            }
        }
        //=== FIN LBENITES 29/04/2015 ===

        // La posición de caret es la longitud de la selección
        iCaretPos = decimals;

        // Distancia que hay hasta la coma
        var dec = el.value.indexOf(".");

        // Si la posición es anterior a los decimales, el cursor está en la parte entera
        if (iCaretPos <= dec) {
            // Obtenemos la longitud que hay desde la posición 0 hasta la coma, y comparamos
            if (dec >= ints) {
                return false;
            }
        }
        else { // El cursor está en la parte decimal
            // Obtenemos la longitud de decimales (longitud total menos distancia hasta la coma menos el carácter coma)
            var numDecimals = el.value.length - dec - 1;

            if (numDecimals >= decimals) {
                return false;
            }
        }
    }

    return true;
}

//------Solo dos decimales y N enteros 
function js_validateFloatKeyPress(el, evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    var number = el.value.split('.');
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    //just one dot (thanks ddlab)
    if (number.length > 1 && charCode == 46) {
        return false;
    }
    //get the carat position
    var caratPos = getSelectionStart(el);
    var dotPos = el.value.indexOf(".");
    if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) {
        return false;
    }
    return true;
}

function getSelectionStart(o) {
    if (o.createTextRange) {
        var r = document.selection.createRange().duplicate()
        r.moveEnd('character', o.value.length)
        if (r.text == '') return o.value.length
        return o.value.lastIndexOf(r.text)
    } else return o.selectionStart
}


function js_ocultarTextBox(control) {
    control.attr("disabled", "disabled");
    control.removeClass("textbox");
    control.addClass("enabletextbox");

    //return false;
}

function js_mostrarTextBox(control) {
    control.removeAttr("disabled");
    control.removeAttr("readonly");
    control.removeClass("enabletextbox");
    control.addClass("textbox");
    //return false;
}

function dateDiff(since, until) {
    since = since.split("/");
    since = new Date(since[2], since[1], since[0], 0, 0, 0, 0);
    until = until.split("/");
    until = new Date(until[2], until[1], until[0], 0, 0, 0, 0);

    if (since > until) {
        var temp = since;
        since = until;
        until = temp;
    }

    var years, months, days;

    //Years
    years = (until.getFullYear() - since.getFullYear());
    if (until.getMonth() == since.getMonth()) {
        if (since.getDate() < (until.getDate() - 1)) {
            years += 1;
        }
        if (since.getDate() == until.getDate()) {
            years += 1;
        }
    }
    if (since.getMonth() > until.getMonth()) {
        years = (years - 1);
    }
    //Months
    if (since.getDate() > until.getDate()) {
        if (since.getMonth() > (until.getMonth() - 1)) {
            months = 11 - (since.getMonth() - until.getMonth());
            if (since.getMonth() == until.getMonth()) {
                months = 11;
            }
        } else {
            months = until.getMonth() - since.getMonth() - 1;
        }
    } else {
        if (since.getMonth() > until.getMonth()) {
            months = 12 - (until.getMonth() - since.getMonth());
        } else {
            months = until.getMonth() - since.getMonth();
        }
    }
    //Days
    if (since.getDate() > (until.getDate() - 1)) {
        var days_pm = dayssInmonths(until.getMonth(until.getMonth() - 1));
        days = days_pm - since.getDate() + until.getDate();
        if ((since.getMonth() == until.getMonth()) & (since.getDate() == until.getDate())) {
            days = 0;
        }
    } else {
        days = until.getDate() - since.getDate();
    }

    return ({ "years": years, "months": months, "days": days });
}

function dayssInmonths(date) {
    date = new Date(date);
    return 32 - new Date(date.getFullYear(), date.getMonth(), 32).getDate();
}
//---INI: EROJAS 04/05/2015 ---
function ValidarFecha(strValue) {
    if (strValue.toString() == '')
        return false;
    var regex = /^(\d{2})\/(\d{2})\/(\d{4})$/;
    if (!regex.test(strValue)) return false;
    var array = strValue.split('/');
    var dia = parseInt(array[0], 10);
    var mes = parseInt(array[1], 10);
    var anio = parseInt(array[2], 10);
    var dmax = -1;
    if ((parseInt(anio) < 1900) || (parseInt(anio) > 2050) || (parseInt(mes) < 1) || (parseInt(mes) > 12) || (parseInt(dia) < 1) || (parseInt(dia) > 31))
        return false;
    else {
        switch (parseInt(mes)) {
            case 1: dmax = 31; break;
            case 2: if (anio % 4 == 0) dmax = 29; else dmax = 28; break;
            case 3: dmax = 31; break;
            case 4: dmax = 30; break;
            case 5: dmax = 31; break;
            case 6: dmax = 30; break;
            case 7: dmax = 31; break;
            case 8: dmax = 31; break;
            case 9: dmax = 30; break;
            case 10: dmax = 31; break;
            case 11: dmax = 30; break;
            case 12: dmax = 31; break;
        }
        if (parseInt(dia) > dmax)
            return false;
    }
    return true;
}
function fechaMayor(fecha, fecha2) {

    var xMes = fecha.substring(3, 5);
    var xDia = fecha.substring(0, 2);
    var xAnio = fecha.substring(6, 10);
    var yMes = fecha2.substring(3, 5);
    var yDia = fecha2.substring(0, 2);
    var yAnio = fecha2.substring(6, 10);
    if (xAnio > yAnio) {
        return true;
    }
    else {
        if (xAnio == yAnio) {
            if (xMes > yMes) {
                return true;
            }
            if (xMes == yMes) {
                if (xDia > yDia) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }
}
function fechaMayorIgual(fecha, fecha2) {

    var xMes = fecha.substring(3, 5);
    var xDia = fecha.substring(0, 2);
    var xAnio = fecha.substring(6, 10);
    var yMes = fecha2.substring(3, 5);
    var yDia = fecha2.substring(0, 2);
    var yAnio = fecha2.substring(6, 10);
    var fecha01 = "";
    var fecha02 = "";

    fechaTemp1 = fecha01.concat(xDia, xMes, xAnio);
    fechaTemp2 = fecha02.concat(yDia, yMes, yAnio);

    if (fechaTemp1 == fechaTemp2) {
        return true;
    }

    if (xAnio > yAnio) {
        return true;
    }
    else {
        if (xAnio == yAnio) {
            if (xMes > yMes) {
                return true;
            }
            if (xMes == yMes) {
                if (xDia > yDia) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }
}
//---FIN: EROJAS 04/05/2015 ---
//--- INI: EROJAS 18/05/2015---
function prevenirBackspace(e) {
    var evt = e || window.event;

    if (evt) {
        var keyCode = evt.charCode || evt.keyCode;
        if (keyCode === 8) {
            if (evt.preventDefault) {
                evt.preventDefault();
            } else {
                evt.returnValue = false;
            }
        }
    }
}
//--- FIN: EROJAS 18/05/2015---


// === INI: LBENITES 26/05/2015 ===
function js_getDateDiff(date1, date2, interval) {
    var second = 1000, minute = second * 60, hour = minute * 60, day = hour * 24, week = day * 7;
    var timediff = date2 - date1;
    switch (interval) {
        case "years":
            return date2.getFullYear() - date1.getFullYear();
        case "months":
            return ((date2.getFullYear() * 12 + date2.getMonth()) - (date1.getFullYear() * 12 + date1.getMonth()));
        case "weeks":
            return Math.floor(timediff / week);
        case "days":
            return Math.floor(timediff / day);
        case "hours":
            return Math.floor(timediff / hour);
        case "minutes":
            return Math.floor(timediff / minute);
        case "seconds":
            return Math.floor(timediff / second);
        default:
            return undefined;
    }
}

// === FIN: LBENITES 26/05/2015 ===
//--Ini: Erojas 15/06/2015----
function precise_round(num, decimals) {
    return Math.round(num * Math.pow(10, decimals)) / Math.pow(10, decimals);
}
//--Fin: Erojs 15/06/2015--

//--Ini: Erojas 10/07/2015----
function js_DatosDiferenciaFecha(Finicio, Ffin) {

    var aFecha1 = Finicio.split('/');
    var aFecha2 = Ffin.split('/');

    var fFechaFin = new Date(parseInt(aFecha2[2], 10), parseInt(aFecha2[1], 10) - 1, parseInt(aFecha2[0], 10));

    var diaIni = parseInt(aFecha1[0], 10);
    var mesIni = parseInt(aFecha1[1], 10);
    var anioIni = parseInt(aFecha1[2], 10);

    //variables de resultados
    var contadorDias = 0;
    var contadorMes = 0;
    var contadorAnio = 0;
    var contadorRestoDias = 0;
    var contadorRestoMes = 0;

    //variables temporales para calculo
    var ContadorDiaTemp = diaIni;
    var mesTemp = mesIni;
    var anioTemp = anioIni;
    var fechaTemp = new Date(anioIni, mesIni - 1, diaIni);

    //--Calcular hasta llegar a la fecha final
    while (fFechaFin > fechaTemp) {
        ContadorDiaTemp++;
        fechaTemp = new Date(anioIni, mesIni - 1, ContadorDiaTemp);
        if (diaIni == fechaTemp.getDate()) {
            contadorMes++;
            contadorRestoDias = 0;
            if (contadorMes % 12 == 0) { contadorAnio++; }
        }
        else { contadorRestoDias++; }

        contadorDias++;
    }//--fin while---

    if (contadorMes == 0) { contadorRestoDias = 0; }
    if (contadorAnio > 0) { 
        contadorRestoMes = contadorMes - (contadorAnio * 12);
    }

    var ObResto = { "meses": contadorRestoMes, "dias": contadorRestoDias };
    var obDatoFecha = { "anio": contadorAnio, "meses": contadorMes, "dias": contadorDias, "resto": ObResto };

    return obDatoFecha;
}
//--Fin: Erojas 10/07/2015--

//Ini: Erojas 17/08/20154--
function js_CalcularFechaFinVigencia(CantMeses, FechaInicio, TipoCalculo, TipoOperacion) {
    /*
    CantMeses: cantidad mese de Vigencia
    FechaInicio: Fecha Inicio de Vigencia
    TipoCalculo: "S": Siguientes "R": Retroactivo
    TipoOperacion: EMI: EMISION, REN: RENOVACION, DEC: DECLARACION
    */
var l_date = new Date();
var l_date_c = "";

var l_day;

var l_day_end;
var l_month_end;
var l_year_end;

var l_day_month;

var l_div;
var l_divd;
var mesInicio;

var aFecha1 = FechaInicio.split('/'); 

    l_day_month = null;

    l_day = parseInt(aFecha1[0], 10);
    l_month_end = parseInt(aFecha1[1], 10);
    mesInicio = parseInt(aFecha1[1], 10);
    l_year_end = parseInt(aFecha1[2], 10);

    for (var l_i = 1; l_i <= CantMeses; l_i++) {
        if (TipoCalculo == "S") {
             if(l_month_end == 12 ){
                l_month_end = 1;
                l_year_end = l_year_end + 1;
             }
             else{
                l_year_end = l_year_end;
                l_month_end = l_month_end + 1;
             }
         }
        else if (TipoCalculo == "R") {
             if (l_month_end == 1 ){
                 l_month_end = 12;
                 l_year_end = l_year_end - 1;
              }
             else{
                 l_year_end =l_year_end;
                 l_month_end = l_month_end - 1;
             };
        }
    }
    
    if (l_month_end == 1 || l_month_end == 3 || l_month_end == 5  ||
       l_month_end == 7 || l_month_end == 8 || l_month_end == 10 ||
       l_month_end == 12 ){
         l_day_month = 31;
    }
    
    if (l_month_end == 4 || l_month_end == 6 || l_month_end == 9  ||
       l_month_end == 11 ){
          l_day_month = 30;
    }
    
    if(l_month_end == 2 ){
        l_divd = parseInt((l_year_end / 4), 10);
        l_div  = parseFloat(l_year_end / 4);
        
        if( (l_divd - l_div) == 0) {
            l_day_month = 29;
           }
        else{
            l_day_month = 28;
        }
    }
    
    if (l_day > l_day_month){
        l_day_end = l_day_month;
    }
    else{
        l_day_end = l_day;
    }     
    //---Casos especiales---
    switch (TipoOperacion) {
        case "DEC": case "REN": 
            if (mesInicio == 2) { 
                if (l_day == 28 || l_day == 29) { 
                    l_day_end = 30;
                }
            }
            break;
        default:
            break;
    }
    //----------------------

    l_date_c = "";
    l_date_c = l_date_c.concat(l_day_end < 10 ? "".concat("0", l_day_end) : l_day_end); // Dia
    l_date_c = l_date_c.concat("/",l_month_end < 10 ? "".concat("0", l_month_end) : l_month_end,"/"); // Mes
    l_date_c = l_date_c.concat(l_year_end); // Año
          
      return l_date_c;
}
//Fin: Erojas 17/08/20154--

//Ini: Erojas 19/08/20154--
function js_IntervalorFrecuencia(valor) {
    var vRetorno = 0;
    switch (parseInt(valor)) {
        case 1: // Anual
            vRetorno = 12;
            break;
        case 2: //Semestral
            vRetorno = 6;
            break;
        case 3: //Trimestral
            vRetorno = 3;
            break;
        case 4: //Bimestral
            vRetorno = 2;
            break;
        case 5: //Mensual
            vRetorno = 1;
            break; 
        case 8: //Cada 4 Meses
            vRetorno = 4;
            break;
        default:
            vRetorno = 0;
            break;
    }

    return parseInt(vRetorno); 
}
//Fin: Erojas 19/08/20154--