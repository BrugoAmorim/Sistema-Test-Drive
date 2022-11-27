
export const gerarMensagemAgendar = (dataTest) => {

    const dtTest = new Date(dataTest.dados.datatest);
        
    const diaTest = (dtTest.getDate() < 10) ? "0" + dtTest.getDate() : dtTest.getDate();
    const mesTest = (dtTest.getMonth() < 10) ? "0" + dtTest.getMonth() : dtTest.getMonth();

    const hrTest = (dtTest.getHours() < 10) ? "0" + dtTest.getHours() : dtTest.getHours();
    const mnTest = (dtTest.getMinutes() < 10) ? "0" + dtTest.getMinutes() : dtTest.getMinutes();

    const mensagem = "Seu test drive foi marcado para o dia " + diaTest + "/" + mesTest + " ás " + hrTest + ":" + mnTest;

    return mensagem;
}

export const validarInputsAgendar = (Datatest, SelecionarCarro) => {

    if(Datatest.value === "")
        swal("Falha na requisição", "Insira uma data de agendamento válida", "error")
    
    if(SelecionarCarro.value === "Null" || SelecionarCarro.value === "")
        swal("Falha na requisição", "Selecione um veículo antes de prosseguir", "error")

}

export const limparCamposAgendar = (body) => {

    body.Cliente.value = "";
    body.Endereco.value = "";
    body.Rg.value = "";
    body.Cpf.value = "";
    body.Cnh.value = "";
    body.Telefone.value = "";
    body.Celular.value = "";
    body.Datatest.value = "";
}