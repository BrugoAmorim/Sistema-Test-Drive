
import { getlocalStorage, deletelocalStorage } from "../../../Public/javascript/localstorage.js";

const logoff = document.getElementById("btn-logoff");

window.onload = () => {

    const dados = getlocalStorage();
    console.log(dados);
}

logoff.onclick = () => {

    deletelocalStorage();
    window.location.href = "../../Login/login.html";
}