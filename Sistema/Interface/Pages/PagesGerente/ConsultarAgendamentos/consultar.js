
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