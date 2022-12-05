
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

    link.appendChild(document.createTextNode('detalhes'));
    link.href = "#";
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

    const hora = data.getHours();
    const minuto = data.getMinutes();
    const dia = data.getDate();
    const mes = data.getMonth() + 1;

    if(mes < 10)
        mes = "0" + mes;

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