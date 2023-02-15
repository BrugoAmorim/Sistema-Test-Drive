
import { getlocalStorage } from "./localstorage.js";

export const listarAgendamentos = async () => {
    
    const url = "http://localhost:5000/TestDrive/consultar/agendamentos/" + getlocalStorage().id;

    const chamaapi = await fetch(url, {
        mode: 'cors',
        method: 'GET'
    });

    let res = chamaapi.json();
    return res;
}

export const criaRegistro = (registro) => {

    const Tr = document.createElement('tr');
    Tr.classList.add('registros');

    const Nome = document.createElement('td');
    Nome.appendChild(document.createTextNode(registro.cliente.cliente))

    const Carro = document.createElement('td');
    Carro.appendChild(document.createTextNode(registro.carro.carro))

    const Data = document.createElement('td');
    const dtFormatado = formatarData(registro.datatest);
    Data.appendChild(document.createTextNode(dtFormatado));

    const Realizado = document.createElement('td');
    Realizado.appendChild(document.createTextNode(registro.realizado));
    
    const Desmarcado = document.createElement('td');
    Desmarcado.appendChild(document.createTextNode(registro.desmarcado));

    const Detalhes = document.createElement('td');
    const link = document.createElement('a');
    link.href = RedirecionarUsuario();
    link.onclick = () => {
        localStorage.setItem("IDagend", registro.idagendamento);
    }

    link.appendChild(document.createTextNode('detalhes'));
    Detalhes.appendChild(link);

    Tr.appendChild(Nome);
    Tr.appendChild(Carro);
    Tr.appendChild(Data);
    Tr.appendChild(Realizado);
    Tr.appendChild(Desmarcado);
    Tr.appendChild(Detalhes);

    return Tr;
}

export const formatarData = (datatest) => {

    const data = new Date(datatest);

    let hora = data.getHours();
    hora = hora < 10 ? "0" + hora : hora;

    let minuto = data.getMinutes();
    minuto = minuto < 10 ? "0" + minuto : minuto;

    let dia = data.getDate();
    dia = dia < 10 ? "0" + dia : dia;

    let mes = data.getMonth() + 1;
    mes = mes < 10 ? "0" + mes : mes;

    return dia + "/" + mes + " ás " + hora + ":" + minuto;
}

export const AgendConcluidos = async () => {
    
    const agendamentos = await listarAgendamentos();
    const concluidos = agendamentos.filter(x => x.dados.realizado == true && x.dados.desmarcado == false);

    return concluidos;
}

export const AgendNaoConcluidos = async () => {

    const agendamentos = await listarAgendamentos();
    const naoconcluidos = agendamentos.filter(x => x.dados.realizado == false && x.dados.desmarcado == true || x.dados.realizado == false && x.dados.desmarcado == false);

    return naoconcluidos;
}

const RedirecionarUsuario = (idagendamento) => {

    const nivel = getlocalStorage().nvlacesso;

    if(nivel == "Gerente"){
        return "../DetalhesTestDrive/detalhestestdrive.html";
    }
    else if(nivel == "Cliente"){
        return "../DetalhesTestDrive/detalhestestdrive.html";
    }
}