
import { getlocalStorage, deletelocalStorage, createlocalStorage } from '../../../Public/javascript/localstorage.js';

const nmuser = document.getElementById('nomeusuario');
const datanasc = document.getElementById('inpdatanascimento');
const senhaantiga = document.getElementById('senhaantiga');
const senhanova = document.getElementById('novasenha');
const confirmar = document.getElementById('confirmar');

window.onload = () => {
    
    nmuser.value = getlocalStorage().user;

    const dt = new Date(getlocalStorage().nasc);
    datanasc.value = dt.toISOString().substring(0, 10);
}

const Atualizar = document.getElementById('btn-atualizar');
Atualizar.onclick = () => { EditarConta() };

const EditarConta = async () => {

    let url = "http://localhost:5000/acesso/conta/editar/" + getlocalStorage().id;

    const ContaReq = {
        usuario: nmuser.value,
        nascimento: new Date(datanasc.value),
        antigasenha: senhaantiga.value,
        senha: senhanova.value,
        confirmarsenha: confirmar.value
    };

    const api = await fetch(url, {
        method: 'PUT',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(ContaReq)
    });

    let res = api.json();
    res.then(data => {

        if(data.codigo == 200){
            
            deletelocalStorage();
            createlocalStorage(data.dados);

            swal(data.status, data.mensagem, 'success');
        }
        else if(data.codigo == 400){
            swal(data.status, data.mensagem, 'error');
        }
        else{
            swal('Ops! Algo deu errado', 'Tente novamente mais tarde', 'error');
        }
    })
}