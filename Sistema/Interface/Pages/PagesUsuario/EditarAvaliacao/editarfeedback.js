
import { getStorageFeedback, deleteStorageFeedback } from "../../../Public/javascript/localstoragefeedback.js";
import { getlocalStorage } from "../../../Public/javascript/localstorage.js";
import { colorStar } from "../MinhasAvaliacoes/meusfeedbacks.js";

const dataFeedback = getStorageFeedback();
const nameUser = document.getElementById("nm-user");
const ListStars = document.getElementById("nota-usuario");

window.onload = () => {

    nameUser.appendChild(document.createTextNode(getlocalStorage().user));
    AddvaloresFeedback(dataFeedback);

    colorStar(dataFeedback.nota, ListStars);
    console.log(dataFeedback);
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

const AddvaloresFeedback = (infoFeedback) => {

    const titulo = document.getElementById("titulo");
    const avaliacao = document.getElementById("avaliacao-user");
    const datePub = document.getElementById("data-publicado");
    const dateAlt = document.getElementById("data-alterado");

    avaliacao.appendChild(document.createTextNode(infoFeedback.avaliacao));

    const dtPub = modeloData(new Date(infoFeedback.datapost));
    datePub.appendChild(document.createTextNode(dtPub));

    const dtAlt = modeloData(new Date(infoFeedback.dataupdate));
    dateAlt.appendChild(document.createTextNode(dtAlt));

    const diames = dtPub.substring(0, 5);
    titulo.appendChild(document.createTextNode(diames));
}

const voltar = document.getElementById("btnVoltar");
voltar.onclick = () => {
    
    deleteStorageFeedback();
}