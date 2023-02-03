
import { getlocalStorage } from "../../../Public/javascript/localstorage.js";

const user = getlocalStorage();
const nomeuser = document.getElementById("nm-user");
const minhaAvaliacao = document.getElementById("minha-avaliacao");

window.onload = () => {

    nomeuser.appendChild(document.createTextNode(user.user));
    novaNota()
}

const btnEnviar = document.getElementById("btn-enviar");
btnEnviar.onclick = async () => {

    let url = "http://localhost:5000/avaliacoes/fazeravaliacao/" + user.id; 

    const AvaliacaoReq = {
        avaliacao: minhaAvaliacao.value,
        notaavaliacao: notauser
    }

    const api = await fetch(url, {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(AvaliacaoReq)
    })

    let res = api.json();
    res.then(data => {

        if(data.codigo == 200)
            swal('Sua avaliação foi salva!', '', 'success');
        else if(data.codigo == 400)
            swal(data.status, data.mensagem, 'error');
        else
            swal('Erro desconhecido', 'Tente novamente mais tarde', 'error');

    })
}

var notauser = 0;
const novaNota = () => {

    const stars = document.querySelectorAll(".star");
    let rating = 0;

    for(let i = 0; i < stars.length; i++){

        stars[i].addEventListener('mouseover', () => {

            for(let j = 0; j <= i; j++){
                stars[j].style.color = "orange"
            }
        });
        stars[i].addEventListener('mouseout', () => {

            for (let j = 0; j < stars.length; j++) {
                
                if (j <= rating - 1) {
                  stars[j].style.color = "orange";
                } else {
                  stars[j].style.color = "black";
                }
            }
        })
        stars[i].addEventListener('click', () => {
            
            rating = i + 1;
            notauser = rating;

            for(let j = rating; j < stars.length; j++){
                stars[j].style.color = "black";
            }
        })

    }
}