
import { getlocalStorage } from "../../../Public/javascript/localstorage.js";

const user = getlocalStorage();
const nomeuser = document.getElementById("nm-user");

const feedback = document.getElementById("container-avaliacoes");
window.onload = () => {

    nomeuser.appendChild(document.createTextNode(user.user));

    for(let i = 0; i < 5; i++){
        
        const x = ObjavaliacaoUsuario();
        feedback.appendChild(x);
    }
}

const ObjavaliacaoUsuario = () => {

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
    paragrafodata.appendChild(document.createTextNode("ultima alteração em"));

    const span = document.createElement('span');
    span.appendChild(document.createTextNode('01/01/0001'));

    // Elementos da div conteudo-feedback
    const divconteudofeedback = document.createElement('div');
    divconteudofeedback.classList.add("conteudo-feedback");

    const paragrafofeedback = document.createElement('p');
    paragrafofeedback.classList.add("feedback");
    paragrafofeedback.appendChild(document.createTextNode('çalsdfjasçdkljfçasdljfçlasdj'))

    // Elementos da div nota-feedback
    const divnotafeedback = document.createElement('div');
    divnotafeedback.classList.add("nota-feedback");
    
    const divnotaestrela = document.createElement('div');
    divnotaestrela.classList.add("nota-estrela");
    
    const divestrelas = document.createElement('div');
    divestrelas.classList.add("estrelas");
    divestrelas.appendChild(document.createTextNode("★★★★★"));

    //Insercoes das divs
    divnotafeedback.appendChild(divnotaestrela);
    divnotaestrela.appendChild(divestrelas);

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