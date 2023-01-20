
const nota = document.getElementById("nota");
var rating = 0;

const avaliar = (r) => {
    for (let i = 0; i < rating; i++) {
        nota.getElementsByTagName("li")[i].style.color = "black";
    }
    rating = r;
    for (let i = 0; i < r; i++) {
        nota.getElementsByTagName("li")[i].style.color = "orange";
    }
}
const resaltar = (r) => {
    for (let i = 0; i < r; i++) {
        nota.getElementsByTagName("li")[i].style.color = "yellow";
    }
}
const resetar = () => {
    for (let i = 0; i < rating; i++) {
        nota.getElementsByTagName("li")[i].style.color = "orange";
    }
    for (let i = rating; i < 5; i++) {
        nota.getElementsByTagName("li")[i].style.color = "black";
    }
}
const avaliacao = (r) => {
    rating = r;
    resetar();
    for (let i = 0; i < r; i++) {
        nota.getElementsByTagName("li")[i].style.color = "orange";
    }
}