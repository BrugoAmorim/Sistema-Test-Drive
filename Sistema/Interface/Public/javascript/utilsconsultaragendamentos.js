
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

const formatarData = (datatest) => {

    const data = new Date(datatest);
    console.log(datatest)

    const hora = data.getHours();
    const minuto = data.getMinutes();
    const dia = data.getDate();
    const mes = data.getMonth() + 1;

    if(mes < 10)
        mes = "0" + mes;

    return hora + ":" + minuto + " ás " + dia + "/" + mes;
}