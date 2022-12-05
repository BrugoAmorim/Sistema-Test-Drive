
import { listarAgendamentos, criaRegistro, AgendConcluidos, AgendNaoConcluidos } from "../../../Public/javascript/utilsconsultaragendamentos.js";
import { getlocalStorage } from "../../../Public/javascript/localstorage.js";

const nomeuser = document.getElementById("nm-user");
const tbody = document.getElementById("tbody");
window.onload = async () => {

    nomeuser.appendChild(document.createTextNode(getlocalStorage().user));

    const meusAgendamentos = await listarAgendamentos();
    meusAgendamentos.map(data => {
        
        if(data.codigo == 400)
            swal(data.status, data.mensagem, 'error')
        
        const registro = criaRegistro(data.dados);
        registro.removeChild(registro.firstChild);

        tbody.appendChild(registro);
    })
}

const concluidos = document.getElementById("btn-concluidos");
concluidos.onclick = async () => {
    
    while(tbody.firstChild)
    tbody.removeChild(tbody.firstChild);

    const agenConcluidos = await AgendConcluidos();
    agenConcluidos.map(data => {

        const registro = criaRegistro(data.dados);
        registro.removeChild(registro.firstChild);

        tbody.appendChild(registro);
    })
}

const naoconcluidos = document.getElementById("btn-nao-concluidos");
naoconcluidos.onclick = async () => {

    while(tbody.firstChild)
    tbody.removeChild(tbody.firstChild);

    const agenNaoConcluidos = await AgendNaoConcluidos();
    agenNaoConcluidos.map(data => {
        
        const registro = criaRegistro(data.dados);
        registro.removeChild(registro.firstChild);

        tbody.appendChild(registro);
    })
}