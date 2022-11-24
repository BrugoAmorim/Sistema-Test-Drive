
const formatarData = (data) => {

    let mes = data.getMonth() + 1;
    let dia = data.getDate();

    if(mes < 10)
        mes = '0' + mes;

    if(dia < 10)
        dia = '0' + dia;

    return dia + '/' + mes + '/' + data.getFullYear();
}

const ModelosCarros = document.getElementById("escolherModelo");
const SelecionarCarro = document.getElementById("selecionarCarro");

export const consultarCarros = async () => {

    let url = "http://localhost:5000/TestDrive/consultar/carros";

    const chamaApi = await fetch(url, {
        method: 'GET',
        mode: 'cors'
    });

    const res = chamaApi.json();
    return res;
}

window.onload = async () => {

    const res = await consultarCarros();

    const Modelos = [];
    res.map(data => {

        if(Modelos.includes(data.modelo) == false)
            Modelos.push(data.modelo);
    })

    Modelos.map(item => {

        const opt = document.createElement('option');
        opt.value = item;
        opt.appendChild(document.createTextNode(item));

        ModelosCarros.appendChild(opt);
    })
}

const FiltrarCarroModelo = async (modelo) => {

    const carros = await consultarCarros();
    const filtrarModelo = carros.filter(x => x.modelo == modelo);

    return filtrarModelo;
}

ModelosCarros.onclick = async () => {

    const carros = await FiltrarCarroModelo(ModelosCarros.value);

    while(SelecionarCarro.firstChild)
        SelecionarCarro.removeChild(SelecionarCarro.firstChild);

    carros.map((data) => {

        const opt = document.createElement('option');
        opt.value = data.idcarro;
        opt.appendChild(document.createTextNode(data.carro));
        SelecionarCarro.appendChild(opt);
    })
}

const modelo = document.getElementById("modelo-carro");
const fabricante = document.getElementById("fabricante-carro");
const potencia = document.getElementById("potencia-carro");
const cambio = document.getElementById("cambio-carro");
const anofab = document.getElementById("anofab-carro");
const anomod = document.getElementById("anomod-carro");
const combustivel = document.getElementById("combustivel-carro");
const preco = document.getElementById("preco-carro");

SelecionarCarro.onclick = async () => {

    LimparCampos();

    const getCars = await consultarCarros();
    const infoCarro = getCars.find(x => x.idcarro == SelecionarCarro.value);
    
    const fabricacao = new Date(infoCarro.anofabricacao);
    const fabFormatado = formatarData(fabricacao);
    
    const dtmodelo = new Date(infoCarro.anomodelo);
    const modFormatado = formatarData(dtmodelo);

    modelo.appendChild(document.createTextNode(infoCarro.modelo));
    fabricante.appendChild(document.createTextNode(infoCarro.fabricante));
    potencia.appendChild(document.createTextNode(infoCarro.potencia));
    cambio.appendChild(document.createTextNode(infoCarro.cambio));
    anofab.appendChild(document.createTextNode(fabFormatado));
    anomod.appendChild(document.createTextNode(modFormatado));
    combustivel.appendChild(document.createTextNode(infoCarro.combustivel));
    preco.appendChild(document.createTextNode( 'R$ ' + infoCarro.preco));
}

const LimparCampos = () => {

    modelo.innerHTML = "";
    fabricante.innerHTML= "";
    potencia.innerHTML= "";
    cambio.innerHTML= "";
    anofab.innerHTML= "";
    anomod.innerHTML= "";
    combustivel.innerHTML= "";
    preco.innerHTML= "";
}