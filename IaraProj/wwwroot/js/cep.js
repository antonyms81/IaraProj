

function buscaCep() {

     var cep = $('[name="CEP"]').val()

    if (cep != "") {
      
        const value = cep.replace(/[^0-9]+/, '');
        const url = "https://viacep.com.br/ws/"+ value +"/json/";

            fetch(url)
                .then(response => response.json())
                .then(json => {

                    console.log("TESTE 04")
                    console.log(json)

                    if (json.logradouro) {
                        document.getElementById("Logradouro").value = json.logradouro;
                        document.getElementById("Bairro").value = json.bairro;
                        document.getElementById("UF").value = json.uf;
                    }

                });

    }
}


window.onload = function () {
   
    let txtcep = document.getElementById("CEP");
        txtcep.addEventListener("blur", buscaCep);

}