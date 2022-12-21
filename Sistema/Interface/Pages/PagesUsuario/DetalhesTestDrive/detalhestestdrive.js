
const nomeusuario = document.getElementById("nm-user");
window.onload = async () => {

    const detalhes = await DetalhesTestDrive();    
    nomeusuario.appendChild(document.createTextNode(localStorage.getItem("user")));
    InserirValores(detalhes.dados.cliente, detalhes.dados.datatest);
    InserirValoresCarro(detalhes.dados.carro);
}

const btnSalvar = document.getElementById("btn-salvar-alteracoes");
btnSalvar.onclick = async () => {

    swal("Você tem certeza que deseja salvar as alterações?", '', 'info', {
        buttons: {
            cancel: "Não",
            catch: {
                text: "Sim, eu quero continuar",
                value: "continuar"
            }
        }
    }).then(async value => {

        if(value == "continuar")
            await atualizarDadosCliente();
        else
            swal("Ação cancelada!", '', 'success');
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

const atualizarDadosCliente = async () => {

    const iduser = localStorage.getItem("id");
    const idcliente = await DetalhesTestDrive();

    const url = "http://localhost:5000/TestDrive/agendamento/atualizarCliente/" + iduser + "/" + idcliente.dados.cliente.idcliente;
    const dadosClienteReq = {
 
        nomecliente: Nome.value,
        endereco: Endereco.value,
        rg: Rg.value,
        cpf: CPF.value,
        cnh: CNH.value,
        telefone: Telefone.value,
        celular: Celular.value   
    }

    const chamaapi = await fetch(url, {
        method: 'PUT',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dadosClienteReq)
    });

    const res = chamaapi.json();
    res.then(data => {

        if(data.codigo == 200)
            swal(data.status, data.mensagem, 'success')
        else if(data.codigo == 400)
            swal(data.status, data.mensagem, 'error')
    });
}

const DetalhesTestDrive = async () => {

    const id = localStorage.getItem("IDagend");

    const url = "http://localhost:5000/TestDrive/agendamento/detalhes/" + id;
    const chamaapi = await fetch(url, {
        mode: 'cors',
        method: 'GET'
    });

    const res = chamaapi.json();
    return res;
}