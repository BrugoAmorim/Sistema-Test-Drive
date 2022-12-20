
window.onload = async () => {

    const id = localStorage.getItem("IDagend");

    const url = "http://localhost:5000/TestDrive/agendamento/detalhes/" + id;
    const chamaapi = await fetch(url, {
        mode: 'cors',
        method: 'GET'
    });

    const res = chamaapi.json();
    res.then(data => {

        InserirValores(data.dados.cliente, data.dados.datatest);
        InserirValoresCarro(data.dados.carro);
    })
}

const Nome = document.getElementById("nomeusuario");
const Rg = document.getElementById("rgusuario");
const Endereco = document.getElementById("enderecousuario");
const CNH = document.getElementById("cnhusuario");
const Telefone = document.getElementById("telusuario");
const Celular = document.getElementById("cellusuario");
const DataTest = document.getElementById("datatest");
const CPF = document.getElementById("cpfusuario");

const InserirValores = (dadoscliente, datatest) => {

    Nome.value = dadoscliente.cliente;
    Rg.value = dadoscliente.rg;
    Endereco.value = dadoscliente.endereco;
    CNH.value = dadoscliente.cnh;
    Telefone.value = dadoscliente.telefone;
    Celular.value = dadoscliente.celular;
    CPF.value = dadoscliente.cpf;
    DataTest.value = datatest;
}

const NmCarro = document.getElementById("NomeCarro");
const Modelo = document.getElementById("modelo");
const Fabricante = document.getElementById("fabricante");
const Potencia = document.getElementById("potencia");
const Cambio = document.getElementById("cambio");
const Combustivel = document.getElementById("combustivel");
const Anomodelo = document.getElementById("anomodelo");
const Anofabricacao = document.getElementById("anofabricacao");
const Preco = document.getElementById("preco");

const InserirValoresCarro = (dadoscarro) => {

    NmCarro.appendChild(document.createTextNode(dadoscarro.carro));
    Modelo.appendChild(document.createTextNode(dadoscarro.modelo));
    Fabricante.appendChild(document.createTextNode(dadoscarro.fabricante));
    Potencia.appendChild(document.createTextNode(dadoscarro.potencia));
    Cambio.appendChild(document.createTextNode(dadoscarro.cambio));
    Combustivel.appendChild(document.createTextNode(dadoscarro.combustivel));
    Anomodelo.appendChild(document.createTextNode(dadoscarro.anomodelo));
    Anofabricacao.appendChild(document.createTextNode(dadoscarro.anofabricacao));
    Preco.appendChild(document.createTextNode("R$ " + dadoscarro.preco));
}