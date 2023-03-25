
$(document).ready(function () {
    /* Executa a requisição quando o campo CEP perder o foco */
    $('#CEP').blur(function () {
        /* Configura a requisição AJAX */
        $.ajax({
            type: 'GET', /* Tipo da requisição */
            url: '/Services/getAddress', /* URL que será chamada */
            data: 'CEP=' + $('#CEP').val(), /* dado que será enviado via POST */
            dataType: 'xml', /* Tipo de transmissão */
            cache: false,
            success: function (data) {
                //alert(data);
                $(data).find("webservicecep").each(function () {
                    $('#Endereco').val($(this).find("tipo_logradouro").text() + ' ' + $(this).find("logradouro").text());
                    $('#Bairro').val($(this).find("bairro").text());
                    $('#Cidade').val($(this).find("cidade").text());
                    $('#UF').val($(this).find("uf").text());

                    $('#Numero').focus();
                });
            },
            async: true
        });
        return false;
    });
});