

function subString() {

    var entrada = $('[name="Entrada"]').val();
    var string = entrada;
    var arrayString = string.split('');
    var _str = "";
    var strCont = "";

    for (var i = 0, len = arrayString.length; i < len; i++) {
        _str = arrayString[i];

        if (lastLetter != _str) {
            strCont = strCont.concat(_str);
        }
        var lastLetter = strCont.substr(-1);

    }
    document.getElementById("ValorSaida").value = strCont;

}