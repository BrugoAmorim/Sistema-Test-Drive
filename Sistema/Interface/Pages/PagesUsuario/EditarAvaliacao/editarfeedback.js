
window.onload = () => {

    console.log(localStorage.getItem("idAvaliacao"))
}

const voltar = document.getElementById("btnVoltar");
voltar.onclick = () => {
    localStorage.removeItem("idAvaliacao");
}