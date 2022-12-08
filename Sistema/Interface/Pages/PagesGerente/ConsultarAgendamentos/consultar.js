
import { criaRegistro, AgendConcluidos, AgendNaoConcluidos, listarAgendamentos } from "../../../Public/javascript/utilsconsultaragendamentos.js";

const tbody = document.getElementById("registros");
window.onload = async () => {

    const data = await listarAgendamentos();
    data.map(item => {

        const registro = criaRegistro(item.dados);
        tbody.appendChild(registro);
    })
}

const Concluido = document.getElementById("btn-concluido");
Concluido.onclick = async () => {

    while(tbody.firstChild)
        tbody.removeChild(tbody.firstChild);

    const concluidos = await AgendConcluidos();
    concluidos.map(item => {
        
        const registro = criaRegistro(item.dados);
        tbody.appendChild(registro);
    })

}

const Naoconcluido = document.getElementById("btn-nao-concluido");
Naoconcluido.onclick = async () => {

    while(tbody.firstChild)
        tbody.removeChild(tbody.firstChild);

    const naoconcluidos = await AgendNaoConcluidos();
    naoconcluidos.map(item => {

        const registro = criaRegistro(item.dados);
        tbody.appendChild(registro);
    })
}

const PesquisarNome = document.getElementById("btn-pesquisar-nome");
PesquisarNome.onclick = async () => {

    const agendamentos = await listarAgendamentos();
    
    const Nome = document.getElementById("inp-nome").value;
    const user = agendamentos.filter(x => x.dados.cliente.cliente.toLowerCase() == Nome.toLowerCase());

    if(user.length == 0)
        swal("Este cliente não foi encontrado", '', "error");
    else{

        while(tbody.firstChild)
            tbody.removeChild(tbody.firstChild);

        user.map(item => {

            const registro = criaRegistro(item.dados);
            tbody.appendChild(registro);
        })
    }
}

const PesquisarCpf = document.getElementById("btn-pesquisar-cpf");
PesquisarCpf.onclick = async () => {

    const cpf = document.getElementById("inp-cpf").value;
    const filtrarCpf = cpf.replaceAll(".", "").replaceAll("-", "");

    const Agendamentos = await listarAgendamentos();
    const user = Agendamentos.filter(x => removeMascara(x.dados.cliente.cpf) == filtrarCpf);

    if(user.length === 0)
        swal("Não foram encontrados registros com esse CPF", "", "error");
    else{
        
        while(tbody.firstChild)
        tbody.removeChild(tbody.firstChild);

        user.map(item => {

            const registro = criaRegistro(item.dados);
            tbody.appendChild(registro);
        })
    }
}

const removeMascara = (req) => {
    return req.replaceAll(".", "").replaceAll("-", "");
}