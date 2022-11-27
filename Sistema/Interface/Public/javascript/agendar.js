
import { getlocalStorage } from "./localstorage.js";
import { gerarMensagemAgendar, validarInputsAgendar, limparCamposAgendar } from "./utilsagendar.js";

const SelecionarCarro = document.getElementById("selecionarCarro");
const Cliente = document.getElementById('nome-cliente');
const Rg = document.getElementById('rg-cliente');
const Endereco = document.getElementById('endereco-cliente');
const Cnh = document.getElementById('cnh-cliente');
const Telefone = document.getElementById('telefone-cliente');
const Cpf = document.getElementById('cpf-cliente');
const Celular = document.getElementById('celular-cliente');
const Datatest = document.getElementById('datatest-cliente');

const Agendar = document.getElementById('btn-agendar');
Agendar.onclick = async () => {

    const idusuario = getlocalStorage().id;
    const url = "http://localhost:5000/TestDrive/agendar/novotest/" + idusuario;

    const request = {
        cliente: Cliente.value,
        endereco: Endereco.value,
        rg: Rg.value,
        cpf: Cpf.value,
        cnh: Cnh.value,
        telefone: Telefone.value,
        celular: Celular.value,
        datatest: Datatest.value,
        idcarro: SelecionarCarro.value
    };

    validarInputsAgendar(Datatest, SelecionarCarro);

    const chamaApi = await fetch(url, {
        mode: 'cors',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(request)
    })

    const res = chamaApi.json();
    res.then((data) => {

        const mensagem = gerarMensagemAgendar(data);

        if(data.codigo === 200){

            swal(data.status, mensagem, "success");

            const body = { Cliente, Endereco, Rg, Cpf, Cnh, Telefone, Celular, Datatest };
            limparCamposAgendar(body);
        }
        else if(data.codigo === 400)
            swal(data.status, data.mensagem, "error");
        else
            swal("Falha na requisição", "Erro desconhecido", "error");
    })
}

const Voltar = document.getElementById("btn-voltar");
Voltar.onclick = () => {

    const nivel = getlocalStorage().nvlacesso;

    if(nivel === "Gerente")
        window.location.href = "../PagesGerente/Home/homegerente.html";
    else if(nivel === "Cliente")
        window.location.href = "../PagesUsuario/Home/homeusuario.html";
    else
        alert('Usuário não identificado');
}