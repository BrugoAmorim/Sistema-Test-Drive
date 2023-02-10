
export const modeloData = (datetime) => {

    let dia = datetime.getDate();
    dia = dia < 10 ? "0" + dia : dia;
    let mes = datetime.getMonth() + 1;
    mes = mes < 10 ? "0" + mes : mes;
    let ano = datetime.getFullYear();
    
    let hora = datetime.getHours();
    hora = hora < 10 ? "0" + hora : hora;
    let minuto = datetime.getMinutes();
    minuto = minuto < 10 ? "0" + minuto : minuto;
    let segundo = datetime.getSeconds();
    segundo = segundo < 10 ? "0" + segundo : segundo; 
    
    const modeldata = dia + "/" + mes + "/" + ano;
    const horario = hora + ':' + minuto + ':' + segundo;
 
    return modeldata + " ás " + horario;
}