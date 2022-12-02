
import { getlocalStorage } from '../../../Public/javascript/localstorage.js';
import { criaRegistro } from '../../../Public/javascript/utilsconsultaragendamentos.js';

const tbody = document.getElementById("registros");
window.onload = async () => {

    const url = "http://localhost:5000/TestDrive/consultar/agendamentos/" + getlocalStorage().id;

    const chamaapi = await fetch(url, {
        mode: 'cors',
        method: 'GET'
    });

    let res = chamaapi.json();
    res.then((data) => {

        data.map(item => {

            const registro = criaRegistro(item.dados);
            tbody.appendChild(registro);
        })
    })
}