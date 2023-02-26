
import { createConfigsPizza } from '../../../Public/javascript/criargrafico.js';
import { getlocalStorage } from '../../../Public/javascript/localstorage.js';

window.onload = async () => {
    
    const relatorio = await consultarModelos();
    anychart.onDocumentReady(() => {
        createConfigsPizza(relatorio)
    })
}

const consultarModelos = async () => {

    const url = "http://localhost:5000/gerente/negocios/modelospopulares/" + getlocalStorage().id;

    const callapi = await fetch(url, {
        mode: 'cors',
        method: 'GET'
    });

    const relatorio = [];
    let res = callapi.json();
    res.then((data) => {

        if(data.codigo == 400){
            
            swal(data.status, data.mensagem, 'error');
        }
        if(data.codigo == 400 && data.mensagem.includes("permissão")){
            
            swal(data.status, data.mensagem, 'error').then(() => {
                window.location.href = "../../Login/login.html";
            })
        }

        data.map(item => {
            
            relatorio.push({
                x: item.modelo.modelo,
                value: item.numAgendamentos
            });
        })    
    });
    return relatorio;
}
