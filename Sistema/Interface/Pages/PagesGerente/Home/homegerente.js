
import { getlocalStorage, deletelocalStorage } from "../../../Public/javascript/localstorage.js";

const logoff = document.getElementById("btn-logoff");

logoff.onclick = () => {

    deletelocalStorage();
    window.location.href = "../../Login/login.html";
}