
import { getlocalStorage } from "../../../Public/javascript/localstorage.js";

const inpSenha = document.createElement('input');
inpSenha.placeholder = "Senha de acesso";
inpSenha.classList.add('senha-acesso');
inpSenha.type = "password";

const buttonExcluir = document.getElementById('btn-excluir');
buttonExcluir.onclick = async () => {

    swal({
        title: 'Voce irá excluir a sua conta.',
        text: 'Para poder apagar a sua conta é necessário fornecer a sua senha de acesso, uma vez apagado não existe chance de recuperação, tem certeza que deseja continuar?',
        icon: 'warning',
        content: inpSenha,
        buttons: {
            cancel: 'Cancelar',
            catch: {
                text: 'Sim, quero continuar',
                value: 'excluir'
            }
        }
    }).then(async (data) => {

        switch(data){
            
            case 'excluir':
                
                if(inpSenha.value === "")
                    swal("Você precisa informar a senha de acesso", '', 'error');
                else                    
                    await ExcluirConta(inpSenha.value);
                break;

            default:
                inpSenha.value = "";
                break
        }
    })
}
const ExcluirConta = async () => {

    const iduser = getlocalStorage().id;
    let url = "http://localhost:5000/acesso/conta/excluir/" + iduser + "?senhaacesso=" + inpSenha.value;

    const chamaApi = await fetch(url, {
        method: 'DELETE',
        mode: 'cors'
    });

    let res = chamaApi.json();
    res.then((data) => {

        switch(data.codigo){

            case 200:
                window.location.href = "../../Login/login.html";
                break;

            case 400:
                swal(data.status, data.mensagem, 'error');
                inpSenha.value = "";
                break;

            default:
                swal('Erro no servidor', 'Por favor, tente novamente mais tarde.', 'error');
                inpSenha.value = "";
                break;
        }
    })
}