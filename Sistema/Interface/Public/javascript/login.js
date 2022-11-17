
import { createlocalStorage, deletelocalStorage } from "./localstorage.js";

const email = document.getElementById("inpEmail");
const senha = document.getElementById("inpSenha");
const logar = document.getElementById("btnLogin");

window.onload = () => {

    deletelocalStorage();
}

logar.onclick = async () => {

    let url = "http://localhost:5000/Acesso/login";

    const objReq = {
        "email": email.value,
        "senha": senha.value
    };

    const API = await fetch(url, {
        mode: 'cors',
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(objReq)
    });

    const res = API.json();
    res.then(data => {

        if(data.codigo == 200){
                        
            const nivel = data.dados.nivelacesso;
                    
            if(nivel == "Gerente"){
                createlocalStorage(data.dados);
                window.location.href = "../PagesGerente/Home/homegerente.html";
            }
            else if(nivel == "Cliente"){
                createlocalStorage(data.dados);
                window.location.href = "../PagesUsuario/Home/homeusuario.html";
            }
            else
                swal('Falha de segurança', 'Nível de acesso não reconhecido', 'error')
        }
        else if(data.codigo == 400)
            swal({
                icon: "error",
                title: data.status,
                text: data.mensagem
            })

    })
}