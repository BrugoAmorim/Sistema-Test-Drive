
import { getlocalStorage } from "../../../Public/javascript/localstorage.js";

const user = getlocalStorage();
const nomeuser = document.getElementById("nm-user");

window.onload = () => {

    nomeuser.appendChild(document.createTextNode(user.user));
}