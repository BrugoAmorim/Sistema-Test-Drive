
const id = localStorage.getItem("IDagend");

window.onload = async () => {

    const url = "http://localhost:5000/TestDrive/agendamento/detalhes/" + id;
    const chamaapi = await fetch(url, {
        mode: 'cors',
        method: 'GET'
    });

    const res = chamaapi.json();
    res.then(data => {

        const dadosCliente = data.dados.cliente;
        const dadosCarro = data.dados.carro;

        AdicionarRegistros(dadosCliente, data.dados.datatest);
        AdicionarInformacoesCarro(dadosCarro);
    })
}

const NomeCliente = document.getElementById("inp-nome");
const RG = document.getElementById("inp-rg");
const Endereco = document.getElementById("inp-endereco");
const CNH = document.getElementById("inp-cnh");
const CPF = document.getElementById("inp-cpf");
const Telefone = document.getElementById("inp-telefone");
const Celular = document.getElementById("inp-celular");
const DataTest = document.getElementById("inp-datatest");

const AdicionarRegistros = (cliente, datatest) => {

    NomeCliente.value = cliente.cliente;
    RG.value = cliente.rg;
    Endereco.value = cliente.endereco;
    CNH.value = cliente.cnh;
    CPF.value = cliente.cpf;
    Telefone.value = cliente.telefone;
    Celular.value = cliente.celular;

    DataTest.value = datatest
}

const Modelo = document.getElementById("txt-modelo");
const Fabricante = document.getElementById("txt-fabricante");
const Potencia = document.getElementById("txt-potencia");
const Cambio = document.getElementById("txt-cambio");
const Combustivel = document.getElementById("txt-combustivel");
const AnoModelo = document.getElementById("txt-anomodelo");
const AnoFabricacao = document.getElementById("txt-anofabricacao");
const Preco = document.getElementById("txt-preco");

const AdicionarInformacoesCarro = (carro) => {

    Modelo.appendChild(document.createTextNode(carro.modelo));
    Fabricante.appendChild(document.createTextNode(carro.fabricante));
    Potencia.appendChild(document.createTextNode(carro.potencia));
    Cambio.appendChild(document.createTextNode(carro.cambio));
    Combustivel.appendChild(document.createTextNode(carro.combustivel));
    AnoModelo.appendChild(document.createTextNode(carro.anomodelo));
    AnoFabricacao.appendChild(document.createTextNode(carro.anofabricacao));
    Preco.appendChild(document.createTextNode("R$ " + carro.preco));
}

const Voltar = document.getElementById("btn-voltar");
Voltar.onclick = () => {
    localStorage.removeItem("IDagend")
}

const rdFeito = document.getElementById("rd-feito");
const rdNaoFeito = document.getElementById("rd-nao-feito");

rdFeito.onclick = async () => {

    const url = "http://localhost:5000/TestDrive/agendamento/marcarRealizado/" + id;

    const chamaapi = await fetch(url, {
        method: 'PUT',
        mode: 'cors'
    });

    const res = chamaapi.json();
    res.then(data => {

        if(data.codigo == 200)
            swal(data.status, data.mensagem, 'success');
        else if(data.codigo == 400)
            swal(data.status, data.mensagem, 'error');

        window.onload;
    })
}

rdNaoFeito.onclick = async () => {

    const url = "http://localhost:5000/TestDrive/agendamento/marcarNaoRealizado/" + id;

    const chamaapi = await fetch(url, {
        method: 'PUT',
        mode: 'cors'
    });

    const res = chamaapi.json();
    res.then(data => {

        if(data.codigo == 200)
            swal(data.status, data.mensagem, 'success');
        else if(data.codigo == 400)
            swal(data.status, data.mensagem, 'error');

        window.onload;
    })
}