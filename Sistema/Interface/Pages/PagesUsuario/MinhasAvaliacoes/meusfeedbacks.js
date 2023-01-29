
import { getlocalStorage } from "../../../Public/javascript/localstorage.js";

const user = getlocalStorage();
const nomeuser = document.getElementById("nm-user");

const containerfeedback = document.getElementById("container-avaliacoes");
window.onload = async () => {

    nomeuser.appendChild(document.createTextNode(user.user));
    const meusFeedbacks = await listarFeedbacks();
    
    meusFeedbacks.map(item => {

        console.log(item)

        const avl = CriarObjetoAvaliacao(item);
        containerfeedback.appendChild(avl)
    })
}

const listarFeedbacks = async () => {

    let url = "http://localhost:5000/avaliacoes/minhas?idusuario=" + getlocalStorage().id;

    const chamaapi = await fetch(url, {
        mode: 'cors',
        method: 'GET'
    });

    let res = chamaapi.json();
    return res;
}

const CriarObjetoAvaliacao = (Feedback) => {

    const divblocoAval = document.createElement('div');
    divblocoAval.classList.add("bloco-avaliacao");

    const divAval = document.createElement('div');
    divAval.classList.add("avaliacao");

    // Elementos da div eventos-datapublicacao
    const divdatapublicacao = document.createElement('div');
    divdatapublicacao.classList.add("eventos-datapublicacao");
    
    const diveventos = document.createElement('div');
    diveventos.classList.add("eventos");

    const btneditar = document.createElement('button');
    btneditar.classList.add("btn-edit");
    
    const ibars = document.createElement('i');
    ibars.classList.add("fa");
    ibars.classList.add("fa-bars");
    btneditar.appendChild(ibars);
    
    btneditar.appendChild(document.createTextNode("Editar"));
    btneditar.onclick = () => { Editar(Feedback.idavaliacao) };

    const btnapagar = document.createElement('button');
    btnapagar.classList.add("btn-apag");

    const itrash = document.createElement('i');
    itrash.classList.add("fa");
    itrash.classList.add("fa-trash");
    btnapagar.appendChild(itrash);

    btnapagar.appendChild(document.createTextNode("Apagar"));

    const datapublicacao = document.createElement('div');
    datapublicacao.classList.add("datapublicacao");

    const paragrafodata = document.createElement('p');
    paragrafodata.appendChild(document.createTextNode("Ultima alteração em"));

    const span = document.createElement('span');
    const data = new Date(Feedback.dataalteracao);
    span.appendChild(document.createTextNode(formatarData(data)));

    // Elementos da div conteudo-feedback
    const divconteudofeedback = document.createElement('div');
    divconteudofeedback.classList.add("conteudo-feedback");

    const paragrafofeedback = document.createElement('p');
    paragrafofeedback.classList.add("feedback");
    paragrafofeedback.appendChild(document.createTextNode(Feedback.avaliacao));

    // Elementos da div nota-feedback
    const divnotafeedback = document.createElement('div');
    divnotafeedback.classList.add("nota-feedback");
    
    const divnotaestrela = document.createElement('div');
    divnotaestrela.classList.add("nota-estrela");
    
    const divestrelas = document.createElement('div');
    divestrelas.classList.add("estrelas");

    const listestrelas = document.createElement('ul');
    listestrelas.classList.add("lista-estrelas");
    listestrelas.setAttribute('id', 'list-star');
    
    AddStars(listestrelas);
    colorStar(Feedback.notaavaliacao, listestrelas);

    //Insercoes das divs
    divnotafeedback.appendChild(divnotaestrela);
    
    divestrelas.appendChild(listestrelas);
    divnotaestrela.appendChild(divestrelas);

    divnotafeedback.appendChild(divnotaestrela);
    divconteudofeedback.appendChild(paragrafofeedback);

    datapublicacao.appendChild(paragrafodata);
    datapublicacao.appendChild(span);

    divdatapublicacao.appendChild(diveventos);
    divdatapublicacao.appendChild(datapublicacao);

    divdatapublicacao.appendChild(diveventos);
    divdatapublicacao.appendChild(datapublicacao);

    diveventos.appendChild(btneditar);
    diveventos.appendChild(btnapagar);

    divAval.appendChild(divdatapublicacao);
    divAval.appendChild(divconteudofeedback);
    divAval.appendChild(divnotafeedback);

    divblocoAval.appendChild(divAval);

    return divblocoAval;
}

const formatarData = (data) => {

    let mes = data.getMonth() + 1;
    if(mes < 10)
        mes = "0" + mes;

    let dia = data.getDate();
    if(dia < 10)
        dia = "0" + dia;

    return dia + '/' + mes + '/' + data.getFullYear();
}

const colorStar = (notaAvl, List) => {

    for(let i = 0; i < notaAvl; i++){

        List.getElementsByTagName("li")[i].style.color = "orange";
    }
}

const Editar = (idFeedback) => {

    localStorage.setItem("idAvaliacao", idFeedback);
    window.location.href = "../EditarAvaliacao/editarfeedback.html";
}

const AddStars = (listestrelas) => {
    
    for(let i = 0; i < 5; i++){

        const star = document.createElement('li');
        star.appendChild(document.createTextNode("★"));

        listestrelas.appendChild(star);
    }
}