
import { getlocalStorage } from '../../../Public/javascript/localstorage.js';
import { modeloData } from '../../../Public/javascript/utilsdata.js';
import { listarAgendamentos } from '../../../Public/javascript/utilsconsultaragendamentos.js';
import { listarFeedbacks, colorStar } from '../MinhasAvaliacoes/meusfeedbacks.js';

const nameUser = document.getElementById('nm-user');
const emailUser = document.getElementById('meuEmail');
const nascimento = document.getElementById('dtnascimento');
const ultimologin = document.getElementById('dtultimoLogin');
const contacriada = document.getElementById('dtcontaCriada');
const ultimaalteracao = document.getElementById('dtultimaAlteracao');

window.onload = async () => {

    AddValores();
}

const UsuariodatetimeRes = () => {

    let dtcriada = new Date(getlocalStorage().criada);
    dtcriada = modeloData(dtcriada);

    let dtlastlogin = new Date(getlocalStorage().login);
    dtlastlogin = modeloData(dtlastlogin);

    let dtupdate = new Date(getlocalStorage().update);
    dtupdate = modeloData(dtupdate);

    let dtnasc = new Date(getlocalStorage().nasc);
    dtnasc = modeloData(dtnasc);
    dtnasc = dtnasc.substr(0, dtnasc.indexOf(" "));

    return { 
        criada: dtcriada,
        lastlogin: dtlastlogin,
        update: dtupdate,
        nasc: dtnasc
    };
}

const divinfoAtividades = document.getElementById('info-atividades');

const avaliacoes = document.getElementById('btn-avaliacoes');
avaliacoes.onclick = async () => {

    while(divinfoAtividades.firstChild)
        divinfoAtividades.removeChild(divinfoAtividades.firstChild);

    const Feedbacks = await listarFeedbacks();

    const divcontaineravaliacoes = document.createElement('div');
    divcontaineravaliacoes.classList.add('container-avaliacoes');

    Feedbacks.map(data => {

        const htmlAvaliacao = containerAvaliacao(data);
        divcontaineravaliacoes.appendChild(htmlAvaliacao);
    })

    divinfoAtividades.appendChild(divcontaineravaliacoes);
};

const containerAvaliacao = (datafeedback) => {

    const divavaliacao = document.createElement('div');
    divavaliacao.classList.add('avaliacao');

    const divcomentario = document.createElement('div');
    divcomentario.classList.add('comentario');

    const txtcomentario = document.createElement('textarea');
    txtcomentario.value = datafeedback.avaliacao;
    txtcomentario.readOnly = true;
    txtcomentario.rows = 5;
    txtcomentario.cols = 30;

    const divnotadatapub = document.createElement('div');
    divnotadatapub.classList.add('nota-data-publicacao');

    const divnota = document.createElement('div');
    divnota.classList.add('nota');

    const ulestrelas = document.createElement('ul');
    ulestrelas.classList.add('estrelas');
    ulestrelas.id = "list-stars";

    AddEstrelas(datafeedback.notaavaliacao, ulestrelas);

    const divdatapub = document.createElement('div');
    divdatapub.classList.add('data-pub');

    const strongdatapub = document.createElement('strong');
    strongdatapub.appendChild(document.createTextNode('Ultima alteração:'));

    const spandatapub = document.createElement('span');
    spandatapub.style.marginLeft = "2%";

    let datapub = new Date(datafeedback.dataalteracao);
    datapub = modeloData(datapub);

    spandatapub.appendChild(document.createTextNode(datapub));

    // insercoes das divs
    divdatapub.appendChild(strongdatapub);
    divdatapub.appendChild(spandatapub);

    divnota.appendChild(ulestrelas);

    divnotadatapub.appendChild(divnota);
    divnotadatapub.appendChild(divdatapub);

    divcomentario.appendChild(txtcomentario);

    divavaliacao.appendChild(divcomentario);
    divavaliacao.appendChild(divnotadatapub);

    return divavaliacao;
}

const containerAgendamentos = () => {

    while(divinfoAtividades.firstChild)
        divinfoAtividades.removeChild(divinfoAtividades.firstChild);

    const divAgendamento = document.createElement('div');
    divAgendamento.classList.add('container-agendamentos');

    const table = document.createElement('table');
    table.classList.add('table');

    // bloco thead
    const thead = document.createElement('thead');
    thead.classList.add('coluna');

    const trhead = document.createElement('tr');
    trhead.classList.add('info-column');

    const th1 = document.createElement('th');
    th1.appendChild(document.createTextNode('Carro'));
    const th2 = document.createElement('th');
    th2.appendChild(document.createTextNode('Data do teste'));
    const th3 = document.createElement('th');
    th3.appendChild(document.createTextNode('Realizado'));
    const th4 = document.createElement('th');
    th4.appendChild(document.createTextNode('Desmarcado'));

    // bloco tbody
    const tbody = document.createElement('tbody');
    tbody.classList.add('registros');

    // insercoes div's
    trhead.appendChild(th1);
    trhead.appendChild(th2);
    trhead.appendChild(th3);
    trhead.appendChild(th4);

    thead.appendChild(trhead);

    table.appendChild(thead);
    table.appendChild(tbody);
    divAgendamento.appendChild(table);

    return {
        divTest: divAgendamento,
        body: tbody        
    };
}

const agendamentos = document.getElementById('btn-agendamentos');
agendamentos.onclick = async () => {
    
    while(divinfoAtividades.firstChild)
        divinfoAtividades.removeChild(divinfoAtividades.firstChild);

    const tests = await listarAgendamentos();
    const Agendamentos = containerAgendamentos();
    
    tests.map(data => {

        if(data.dados.realizado == true){
            const trbody = document.createElement('tr');
            trbody.classList.add('info-reg');

            const td1 = document.createElement('td');
            td1.appendChild(document.createTextNode(data.dados.carro.carro));
            
            const td2 = document.createElement('td');
            let datatestModel = new Date(data.dados.datatest);
            datatestModel = modeloData(datatestModel);

            td2.appendChild(document.createTextNode(datatestModel.substr(0, datatestModel.indexOf(" "))));
            
            const td3 = document.createElement('td');
            td3.appendChild(document.createTextNode(data.dados.realizado));
            const td4 = document.createElement('td');
            td4.appendChild(document.createTextNode(data.dados.desmarcado));

            trbody.appendChild(td1);
            trbody.appendChild(td2);
            trbody.appendChild(td3);
            trbody.appendChild(td4);

            Agendamentos.body.appendChild(trbody);
        }
    })
    
    divinfoAtividades.appendChild(Agendamentos.divTest);

}

const AddValores = () => {

    nameUser.appendChild(document.createTextNode(getlocalStorage().user));
    emailUser.value = getlocalStorage().email;

    const datasUser = UsuariodatetimeRes();
    nascimento.value = datasUser.nasc;

    ultimologin.appendChild(document.createTextNode(datasUser.lastlogin));
    contacriada.appendChild(document.createTextNode(datasUser.criada));
    ultimaalteracao.appendChild(document.createTextNode(datasUser.update));
}

const AddEstrelas = (notaAvl, ulestrelas) => {

    for(let i = 0; i < 5; i++){
        const li = document.createElement('li');
        li.appendChild(document.createTextNode('★'));

        ulestrelas.appendChild(li);
    }

    return colorStar(notaAvl, ulestrelas);
}