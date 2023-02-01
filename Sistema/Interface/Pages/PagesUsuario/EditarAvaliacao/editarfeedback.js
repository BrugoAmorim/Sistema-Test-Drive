
import { getStorageFeedback, deleteStorageFeedback, postStorageFeedback } from "../../../Public/javascript/localstoragefeedback.js";
import { getlocalStorage } from "../../../Public/javascript/localstorage.js";
import { colorStar } from "../MinhasAvaliacoes/meusfeedbacks.js";

const dataFeedback = getStorageFeedback();
const nameUser = document.getElementById("nm-user");
const ListStars = document.getElementById("nota-usuario");

const avaliacao = document.getElementById("avaliacao-user");
const titulo = document.getElementById("titulo");
const datePub = document.getElementById("data-publicado");
const dateAlt = document.getElementById("data-alterado");

window.onload = () => {

    nameUser.appendChild(document.createTextNode(getlocalStorage().user));

    MudarNota();
    AddvaloresFeedback(dataFeedback)
    colorStar(dataFeedback.nota, ListStars);
}

const modeloData = (datetime) => {

    let dia = datetime.getDate();
    dia = dia < 10 ? "0" + dia : dia;
    let mes = datetime.getMonth() + 1;
    mes = mes < 10 ? "0" + mes : mes;
    let ano = datetime.getFullYear();
    
    let hora = datetime.getHours();
    let minuto = datetime.getMinutes();
    let segundo = datetime.getSeconds();
    
    const modeldata = dia + "/" + mes + "/" + ano;
    const horario = hora + ':' + minuto + ':' + segundo;
 
    return modeldata + " ás " + horario;
}

const btnSalvarAlt = document.getElementById("btn-salvar");
btnSalvarAlt.onclick = async () => {

    const idfeed = getStorageFeedback().id;
    const iduser = getlocalStorage().id;

    let url = "http://localhost:5000/avaliacoes/editar/" + iduser + '/' + idfeed;

    const ObjFeedbackReq = {
        "avaliacao": avaliacao.value,
        "notaavaliacao": novaNota
    };

    const chamaapi = await fetch(url, {
        mode: 'cors',
        method: 'PUT',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(ObjFeedbackReq)
    });

    let res = chamaapi.json();
    res.then(data => {

        if(data.codigo == 200){

            RemovervaloresFeedback();

            deleteStorageFeedback();
            postStorageFeedback(data.avaliacao);

            carregarInformacoesFeedback(data.avaliacao);
            swal('A avaliação foi atualizada com sucesso', '', 'success');
        }
        else if(data.codigo == 400)
            swal(data.status, data.mensagem, 'error')
    })
}

// Essa função será usada apenas caso o usuario queria atualizar as informacoes do feedback
const carregarInformacoesFeedback = (novosValores) => {

    avaliacao.appendChild(document.createTextNode(novosValores.avaliacao))

    const dtPub = modeloData(new Date(novosValores.datapostagem));
    datePub.appendChild(document.createTextNode(dtPub));

    const dtAlt = modeloData(new Date(novosValores.dataalteracao));
    dateAlt.appendChild(document.createTextNode(dtAlt));

    const diames = dtPub.substring(0, 5);
    titulo.appendChild(document.createTextNode(diames));
}

// método usado quando a página carrega para exibir as informações do feedback
const AddvaloresFeedback = (infoFeedback) => {

    avaliacao.appendChild(document.createTextNode(infoFeedback.avaliacao));

    const dtPub = modeloData(new Date(infoFeedback.datapost));
    datePub.appendChild(document.createTextNode(dtPub));

    const dtAlt = modeloData(new Date(infoFeedback.dataupdate));
    dateAlt.appendChild(document.createTextNode(dtAlt));

    const diames = dtPub.substring(0, 5);
    titulo.appendChild(document.createTextNode(diames));
}

const RemovervaloresFeedback = () => {

    avaliacao.removeChild(avaliacao.firstChild);
    datePub.removeChild(datePub.firstChild);
    dateAlt.removeChild(dateAlt.firstChild);
    titulo.removeChild(titulo.lastChild);
}

var novaNota = dataFeedback.nota;
const MudarNota = () => {

    const stars = document.querySelectorAll(".star");
    let rating = dataFeedback.nota;
    let initialRating = rating;

    for (let i = 0; i < stars.length; i++) {
        
        stars[i].addEventListener("mouseover", function() {
          
            for (let j = 0; j <= i; j++) {
                stars[j].style.color = "yellow";
            }
        });
    
        stars[i].addEventListener("mouseout", function() {
          
            for (let j = 0; j < stars.length; j++) {
                stars[j].style.color = "black";
            }
            for (let j = 0; j < initialRating; j++) {
                stars[j].style.color = "orange";
            }
        });
    
        stars[i].addEventListener("click", function() {
            initialRating = i + 1;
            rating = initialRating;
            
            novaNota = rating;
        });
    }
}

const voltar = document.getElementById("btnVoltar");
voltar.onclick = () => {
    
    deleteStorageFeedback();
}