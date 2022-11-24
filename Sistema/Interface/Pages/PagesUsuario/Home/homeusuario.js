
import { getlocalStorage, deletelocalStorage } from "../../../Public/javascript/localstorage.js";

const nmuser = document.getElementById("nm-user");
window.onload = () => {

  const dados = getlocalStorage();
  nmuser.appendChild(document.createTextNode(dados.user));
}

const logoff = document.getElementById("btn-logoff");
logoff.onclick = () => {

    deletelocalStorage();
    window.location.href = "../../Login/login.html";
}

