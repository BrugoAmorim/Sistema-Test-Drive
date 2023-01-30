
export const postStorageFeedback = (avaliacao) => {

    localStorage.setItem("idavaliacao", avaliacao.idavaliacao);
    localStorage.setItem("avaliacao", avaliacao.avaliacao);
    localStorage.setItem("dataupdate", avaliacao.dataalteracao);
    localStorage.setItem("datapost", avaliacao.datapostagem);
    localStorage.setItem("nota", avaliacao.notaavaliacao);
    localStorage.setItem("iduser", avaliacao.infousuario.idusuario);
    localStorage.setItem("nomeuser", avaliacao.infousuario.nomeusuario);
    localStorage.setItem("emailuser", avaliacao.infousuario.email);
}

export const deleteStorageFeedback = () => {

    localStorage.removeItem("idavaliacao");
    localStorage.removeItem("avaliacao");
    localStorage.removeItem("dataupdate");
    localStorage.removeItem("datapost");
    localStorage.removeItem("nota");
    localStorage.removeItem("iduser");
    localStorage.removeItem("nomeuser");
    localStorage.removeItem("emailuser");
}

export const getStorageFeedback = () => {

    return {
        id: localStorage.getItem("idavaliacao"),
        avaliacao: localStorage.getItem("avaliacao"),
        dataupdate: localStorage.getItem("dataupdate"),
        datapost: localStorage.getItem("datapost"),
        nota: localStorage.getItem("nota"),
        infoUsuario: {
            iduser: localStorage.getItem("iduser"),
            nome: localStorage.getItem("nomeuser"),
            email: localStorage.getItem("emailuser")
        }
    }
}

export const updateStorageFeedback = (FeedbackUpdated) => {

    deleteStorageFeedback();
    postStorageFeedback(FeedbackUpdated);
}