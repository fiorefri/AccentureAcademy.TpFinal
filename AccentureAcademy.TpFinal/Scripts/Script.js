/* BOTON MENU */
let menu = document.querySelector(".menu")
let nav = document.querySelector("nav")

menu.addEventListener("click", () => {
    nav.classList.add("abierto")
})

/* BOTON CERRAR */
let cerrar = document.querySelector(".cerrar")

cerrar.addEventListener("click", () => {
    nav.classList.remove("abierto")
})

