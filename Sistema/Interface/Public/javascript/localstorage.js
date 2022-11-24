
export const createlocalStorage = (user) => {

    localStorage.setItem("id", user.idusuario);
    localStorage.setItem("user", user.usuario);
    localStorage.setItem("email", user.email);
    localStorage.setItem("nasc", user.datanascimento);
    localStorage.setItem("login", user.ultimologin);
    localStorage.setItem("criada", user.contacriada);
    localStorage.setItem("update", user.contaatualizada);
    localStorage.setItem("nivelacesso", user.nivelacesso);
}

export const getlocalStorage = () => {

    const informacoes = {
        id: localStorage.getItem("id"),
        user: localStorage.getItem("user"),
        email: localStorage.getItem("email"),
        nasc: localStorage.getItem("nasc"),
        login: localStorage.getItem("login"),
        criada: localStorage.getItem("criada"),
        update: localStorage.getItem("update"),
        nvlacesso: localStorage.getItem("nivelacesso")
    }

    return informacoes;
}

export const deletelocalStorage = () => {

    localStorage.removeItem("id");
    localStorage.removeItem("user");
    localStorage.removeItem("email");
    localStorage.removeItem("nasc");
    localStorage.removeItem("login");
    localStorage.removeItem("criada");
    localStorage.removeItem("update");
    localStorage.removeItem("nivelacesso");
}