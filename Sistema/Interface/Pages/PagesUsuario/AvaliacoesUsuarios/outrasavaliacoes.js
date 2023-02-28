
import { getlocalStorage } from "../../../Public/javascript/localstorage.js";
import { colorStar } from '../MinhasAvaliacoes/meusfeedbacks.js';

const user = getlocalStorage();
const nomeuser = document.getElementById("nm-user");

const feedbacks = document.getElementById("feedbacks");
window.onload = async () => {

    nomeuser.appendChild(document.createTextNode(user.user));
    const avls = await verAvaliacoes();

    avls.map((item) => {

        console.log(item)
        feedbacks.appendChild(AddAvaliacao(item));
    })
}

const verAvaliacoes = async () => {

    let url = "http://localhost:5000/avaliacoes/outras?idusuario=" + user.id + "&ordenar=novos";

    const chamaapi = await fetch(url, {
        method: 'GET',
        mode: 'cors'
    });

    let res = chamaapi.json();
    return res;
}

const AddAvaliacao = (InformacoesAvl) => {

    const divavaliacao = document.createElement('div');
    divavaliacao.classList.add("avaliacao");

    // container div avaliacao
    const blocoinfousuario = document.createElement('div');
    blocoinfousuario.classList.add('bloco-informacoesusuario');

    const divusuario = document.createElement('div');
    divusuario.classList.add('usuario');

    const nomeusuario = document.createElement('p');
    nomeusuario.classList.add('nome-usuario');
    nomeusuario.appendChild(document.createTextNode(InformacoesAvl.infousuario.nomeusuario));

    const datapublicacao = document.createElement('div');
    datapublicacao.classList.add('data-publicacao');
    
    const plastupdate = document.createElement('p');
    plastupdate.appendChild(document.createTextNode('Ultima alteração em'));

    const pdataupdate = document.createElement('p');
    const dataPub = AddDataPublicacao(new Date(InformacoesAvl.dataalteracao));
    pdataupdate.appendChild(document.createTextNode(dataPub));

    // container div bloco-comentario
    const blococomentario = document.createElement('div');
    blococomentario.classList.add('bloco-comentario');

    const paragrafocomentario = document.createElement('p');
    paragrafocomentario.classList.add('comentario');
    paragrafocomentario.appendChild(document.createTextNode(InformacoesAvl.avaliacao))

    // container div bloco-nota
    const bloconota = document.createElement('div');
    bloconota.classList.add('bloco-nota');

    const blocoestrelas = document.createElement('div');
    blocoestrelas.classList.add('bloco-estrelas');

    const ulestrelas = document.createElement('ul');
    ulestrelas.classList.add('estrelas');

    for(let i = 0; i < 5; i++){
        
        const star = document.createElement('li');
        star.appendChild(document.createTextNode('★'));
        ulestrelas.appendChild(star);
    }

    colorStar(InformacoesAvl.notaavaliacao, ulestrelas);

    // insercoes divs

    blocoestrelas.appendChild(ulestrelas);
    bloconota.appendChild(blocoestrelas);
    blococomentario.appendChild(paragrafocomentario);

    datapublicacao.appendChild(plastupdate);
    datapublicacao.appendChild(pdataupdate);

    divusuario.appendChild(nomeusuario);

    blocoinfousuario.appendChild(divusuario);
    blocoinfousuario.appendChild(datapublicacao);

    divavaliacao.appendChild(blocoinfousuario);
    divavaliacao.appendChild(blococomentario);
    divavaliacao.appendChild(bloconota);

    return divavaliacao;
}

const AddDataPublicacao = (data) => {

    let dia = data.getDate();
    dia = dia < 10 ? "0" + dia : dia;    

    let mes = data.getMonth() + 1;
    mes = mes < 10 ? "0" + mes : mes;

    let ano = data.getFullYear();
    ano = ano < 10 ? "0" + ano : ano;

    return dia + "/" +  mes + "/" + ano;
}