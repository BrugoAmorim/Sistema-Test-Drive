
import { createConfigsBars } from '../../../Public/javascript/criargrafico.js';
import { getlocalStorage } from '../../../Public/javascript/localstorage.js';

window.onload = async () => {

    const relatorio = await consultarClientes();
    anychart.onDocumentReady(() => {
        createConfigsBars(relatorio);
    })
}

const consultarClientes = async () => {

    let url = "http://localhost:5000/gerente/negocios/melhoresclientes/1";

    const api = await fetch(url, {
        mode: 'cors',
        method: 'GET'
    });

    let relatorio = [];
    let res = api.json();
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

            relatorio.push([
                item.usuario.nome,
                item.numAgendamentos
            ]);
        })
    })
    return relatorio;
}