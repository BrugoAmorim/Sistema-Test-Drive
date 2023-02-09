
export const ExcluirAvaliacao = async (iduser, idavaliacao) => {

    let url = "http://localhost:5000/avaliacoes/excluir/" + iduser + "/" + idavaliacao;

    const api = await fetch(url, {
        method: 'DELETE',
        mode: 'cors'
    });

    let res = api.json();
    res.then((data) => {

        if(data.codigo == 200){
            swal(data.status, data.mensagem, 'success');
        }
        else if(data.codigo == 400){
            swal(data.mensagem, '', 'error');
        }
        else
            swal('Algo deu errado', 'Tente novamente mais tarde', 'error');
    })

    window.onload();
}