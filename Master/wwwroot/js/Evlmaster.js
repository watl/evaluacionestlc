
//validar informacion
function validardatos() {
    var res = validatedata();
    if (res == false) {
        return false;
    }
    $(".sw-btn-next").prop("disabled", false);


}


//Validar campos
function validatedata() {
    var isValid = true;
    var cbx = $('#cbxTPEVA').val();
    if (cbx == 0) {
        toastr.error('!Debe seleccionar tipo de evaluacion!', { timeOut: 6500 })
        $('#cbxTPEVA').css('border-color', 'Red');
        isValid = false;
    }
    
    else {
        $('#cbxTPEVA').css('border-color', 'lightgrey');
    }
    if ($('#Fnccbx').val() == 0) {
        toastr.error('!Debe seleccionar un funcionario!', { timeOut: 6500 })
        $('#errortag1').show();
        isValid = false;
    }
    else {
        $('#errortag1').hide();
    }
    if ($('#fchactual').val() == 0) {
        toastr.error('!Debe seleccionar la fecha actual!', { timeOut: 6500 })
        $('#errortag2').show();
        isValid = false;
    }
    else {
        $('#errortag2').hide();
    }

    if ($('#cbxcrg1').val() == 0) {
        toastr.error('!Debe seleccionar cargo que desempeña!', { timeOut: 6500 })
        $('#errortag3').show();
        isValid = false;
    }
    else {
        $('#errortag3').hide();
    }

    if ($('#Dircbx').val() == 0) {
        toastr.error('!Debe seleccionar direccion admistrativa!', { timeOut: 6000 })
        $('#errortag4').show();
        isValid = false;
    }
    else {
        $('#errortag4').hide();
    }

    if ($('#Evlcbx').val() == 0) {
        toastr.error('!Debe seleccionar evaluador!', { timeOut: 6000 })
        $('#errortag5').show();
        isValid = false;
    }
    else {
        $('#errortag5').hide();
    }

    if ($('#cbxcrg2').val() == 0) {
        toastr.error('!Debe seleccionar cargo evaluador!', { timeOut: 6000 })
        $('#errortag6').show();
        isValid = false;
    }
    else {
        $('#errortag6').hide();
    }



    return isValid;
}