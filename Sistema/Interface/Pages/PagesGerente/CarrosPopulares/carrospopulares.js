
import { createConfigsPizza } from "../../../Public/javascript/criargrafico.js";
import { getlocalStorage } from '../../../Public/javascript/localstorage.js';

window.onload = async () => {

    const relatorio = await CarrosPopulares();
    anychart.onDocumentReady(() => {
        createConfigsPizza(relatorio);
    });
}

export const CarrosPopulares = async () => {

    const url = "http://localhost:5000/gerente/negocios/carrosrequeridos/" + getlocalStorage().id;

    const chamaApi = await fetch(url, {
        method: 'GET',
        mode: 'cors'
    });

    const relatorio = [];
    const res = chamaApi.json();
    res.then((data) => {

        if(data.codigo == 400){
            
            swal(data.status, data.mensagem, 'error');
        }
        if(data.codigo == 400 && data.mensagem.includes("permissão")){
            
            swal(data.status, data.mensagem, 'error').then(() => {
                window.location.href = "../../Login/login.html";
            })
        }
        
        data.map((item) => {

            let relCar = {
                x: item.carro.carro,
                value: item.numeroagendamentos
            };
            relatorio.push(relCar);
        })
    });

    return relatorio;
}