
import { colorStar } from '../../PagesUsuario/MinhasAvaliacoes/meusfeedbacks.js';
import { DiaMesAno } from '../../../Public/javascript/utilsdata.js';
import { getlocalStorage } from '../../../Public/javascript/localstorage.js';

const Avls = document.getElementById('feedbacks');
const select = document.getElementById("ordenar-avl");

window.onload =  async() => {

    const avaliacoesUser = await getFeedbacks();
    avaliacoesUser.map((item) => {

        const Obj = createAvl(item);
        Avls.appendChild(Obj);
    })
}

const createAvl = (data) => {

    const divAvl = document.createElement('div');
    divAvl.classList.add('avl');

    // container informacoes junto de suas tags filho
    const divInfo = document.createElement('div');
    divInfo.classList.add('informacoes');

    const divNomeEmail = document.createElement('div');
    divNomeEmail.classList.add('nome-email');

    const divNome = document.createElement('div');
    divNome.classList.add('nome-user');

    const hNome = document.createElement('h1');
    hNome.appendChild(document.createTextNode(data.infousuario.nomeusuario));

    const divEmail = document.createElement('div');
    divEmail.classList.add('email-user');

    const pEmail = document.createElement('p');
    pEmail.appendChild(document.createTextNode(data.infousuario.email));

    const divDataAlt = document.createElement('div');
    divDataAlt.classList.add('data-alt');

    const pData = document.createElement('p');
    const formBr = DiaMesAno(new Date(data.dataalteracao));
    pData.appendChild(document.createTextNode('Última alteração em ' + formBr.replaceAll('-', '/')));

    // container comentario junto de suas tags filho
    const divComentario = document.createElement('div');
    divComentario.classList.add('comentario');

    const pComentario = document.createElement('p');
    pComentario.appendChild(document.createTextNode(data.avaliacao));

    // container bloco-estrelas junto de suas tags filho
    const divBlocoStars = document.createElement('div');
    divBlocoStars.classList.add('bloco-estrelas');

    const divEstrelas = document.createElement('div');
    divEstrelas.classList.add('estrelas');

    const ulEstrelas = document.createElement('ul');
    ulEstrelas.classList.add('lista-estrelas');

    for(let i = 0; i < 5; i++){

        const liStar = document.createElement('li');
        liStar.classList.add('stars');
        liStar.appendChild(document.createTextNode('★'));

        ulEstrelas.appendChild(liStar);
    }
    colorStar(data.notaavaliacao, ulEstrelas)

    // insercoes das tags
    divEstrelas.appendChild(ulEstrelas);
    divBlocoStars.appendChild(divEstrelas);

    divComentario.appendChild(pComentario);

    divNome.appendChild(hNome);
    divEmail.appendChild(pEmail);

    divNomeEmail.appendChild(divNome);
    divNomeEmail.appendChild(divEmail);
    divDataAlt.appendChild(pData);

    divInfo.appendChild(divNomeEmail);
    divInfo.appendChild(divDataAlt);

    divAvl.appendChild(divInfo);
    divAvl.appendChild(divComentario);
    divAvl.appendChild(divBlocoStars);

    return divAvl;
}

const getFeedbacks = async () => {

    const ordem = OrdenarAvl(select.value);
    const idUser = getlocalStorage().id;

    let url = "http://localhost:5000/avaliacoes/outras?idusuario=" + idUser + "&ordenar=" + ordem;

    const api = await fetch(url, {
        mode: 'cors',
        method: 'GET'
    });

    let res = api.json();
    res.then((data) => {

        if(data.codigo == 400)
            swal(data.status, data.mensagem, 'error');
    })

    return res;
}

const OrdenarAvl = (ordem) => {
    return ordem == "novos" ? "novos" : "antigos";
}

select.onclick = async () => {

    while(Avls.firstChild)
        Avls.removeChild(Avls.firstChild);

    const avaliacoesUser = await getFeedbacks();
    avaliacoesUser.map((item) => {

        const Obj = createAvl(item);
        Avls.appendChild(Obj);
    })
}
