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

/* DESCRIPCION LIBROS */
/* let libroList = document.querySelectorAll(".libro")
let libro = Array.prototype.slice.call(libroList)

libro.forEach(e => {
    console.dir(e)
    for (var i; i < libro.length; i++){
        if (i == libro[])
    }
}) */


/* let main = document.querySelector("main")
let links = document.querySelectorAll(".link")
let [perfil, portfolio, contacto] = links

links.forEach(link => {
    link.addEventListener("click", e => {
        e.preventDefault()
        ajax(`${e.target.href}`)
        nav.classList.remove("abierto")
    })
})

function ajax(url) {
    let xhr = new XMLHttpRequest
    xhr.open("GET", url)
    xhr.addEventListener("readystatechange", () => {
        if (xhr.readyState == 4 && xhr.status == 200) {
            main.innerHTML = xhr.response
        }
    })
    xhr.send()
} */