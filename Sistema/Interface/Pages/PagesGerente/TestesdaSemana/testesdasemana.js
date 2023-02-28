
import { modeloData, AnoMesDia } from '../../../Public/javascript/utilsdata.js';
import { createConfigsColumn } from '../../../Public/javascript/criargrafico.js';
import { getlocalStorage } from '../../../Public/javascript/localstorage.js';

window.onload = async () => {

    const relatorio = await getRelatorio("");
    const RelGraficoUm = addDatasRelatorio(relatorio, 5, 0);
    const RelGraficoDois = addDatasRelatorio(relatorio, 10, 5);

    anychart.onDocumentReady(() => {
        createConfigsColumn(RelGraficoUm, "grafico-um", "Relatório da semana");
        createConfigsColumn(RelGraficoDois, "grafico-dois", "Relatório da semana anterior")
    })
}

const addDatasRelatorio = (datas, inicio, fim) => {

    const list = [];
    for(let i = inicio; i >= fim; i--){
        list.push(datas[i]);
    }

    list.shift();

    const dadosRelatorio = [];
    list.map(rel => {

        let novaData = new Date(rel.data);
        let formData = modeloData(novaData); 

        let relatorioDia = [ identificarDiaSemana(novaData) + " " + formData.substring(0, 5), rel.numTestDrive];
        dadosRelatorio.push(relatorioDia);
    })

    return dadosRelatorio;
}

const getRelatorio = async (date) => {

    let url = "http://localhost:5000/gerente/negocios/relatorio/" + getlocalStorage().id + "?data=";
    if(date == "")
        url = url + CriarData("");
    else
        url = url + CriarData(date);

    const api = await fetch(url, {
        mode: 'cors',
        method: 'GET'
    });

    let res = api.json();
    res.then(data => {
        
        if(data.codigo == 400){
            
            swal(data.status, data.mensagem, 'error');
        }
        if(data.codigo == 400 && data.mensagem.includes("permissão")){
            
            swal(data.status, data.mensagem, 'error').then(() => {
                window.location.href = "../../Login/login.html";
            })
        }
    })
    
    return res;
}

const identificarDiaSemana = (data) => {

    if(data.getDay() == 1)
        return "Seg";
    else if(data.getDay() == 2)
        return "Ter";
    else if(data.getDay() == 3)
        return "Qua";
    else if(data.getDay() == 4)
        return "Qui";
    else if(data.getDay() == 5)
        return "Sex";
}

const graficOne = document.getElementById("grafico-um");
const graficTwo = document.getElementById("grafico-dois");

const selData = document.getElementById("btn-buscar");
const inpData = document.getElementById("inp-data");
selData.onclick = async () => {
    
    const dt = CriarData(inpData.value);
    const novoRel = await getRelatorio(dt);

    while(graficOne.firstChild)
        graficOne.removeChild(graficOne.firstChild);
    while(graficTwo.firstChild)
        graficTwo.removeChild(graficTwo.firstChild);

    const RelGraficoUm = addDatasRelatorio(novoRel, 5, 0);
    const RelGraficoDois = addDatasRelatorio(novoRel, 10, 5);

    anychart.onDocumentReady(() => {
        createConfigsColumn(RelGraficoUm, "grafico-um", "Relatório da semana");
        createConfigsColumn(RelGraficoDois, "grafico-dois", "Relatório da semana anterior")
    })
}

const CriarData = (date) => {

    let vl;
    if(date == ""){

        const dtNow = new Date();
        vl = AnoMesDia(dtNow);
        return vl;
    }
    else{
        
        vl = AnoMesDia(new Date(date));
        return vl;
    }
}