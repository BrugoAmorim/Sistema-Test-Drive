
const Email = document.getElementById("inp-email");
const Usuario = document.getElementById("inp-usuario");
const Datanascimento = document.getElementById("inp-nasc");
const Senha = document.getElementById("inp-senha");
const ConfirmarSenha = document.getElementById("inp-confirmar-senha");

const btnCriar = document.getElementById("btn-criar-conta");
btnCriar.onclick = async () => {

    if(Datanascimento.value == "")
        swal('Falha na requisição', 'Campo data de nascimento inválido', 'error');
    else{
        const objReq = {
            email: Email.value,
            usuario: Usuario.value,
            nascimento: Datanascimento.value,
            senha: Senha.value,
            confirmarsenha: ConfirmarSenha.value
        };

        const url = "http://localhost:5000/Acesso/novaconta";
        const chamaApi = await fetch(url, {

            method: 'POST',
            mode: 'cors',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(objReq)
        });

        const res = chamaApi.json();
        res.then((data) => {
            
            if(data.codigo == 200){
                swal(data.mensagem, 'A conta para o usuário ' + data.dados.usuario + ' foi criada com sucesso', 'success');
                Email.value = "";
                Usuario.value = "";
                Datanascimento.value = "";
                Senha.value = "";
                ConfirmarSenha.value = "";
            }

            else if(data.codigo == 400)
                swal(data.status, data.mensagem, 'error');
        })
    }
}