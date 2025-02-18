const hamBurger = document.querySelector(".toggle-btn");
document.querySelector("#sidebar").classList.toggle("expand");

hamBurger.addEventListener("click", function () {
  document.querySelector("#sidebar").classList.toggle("expand");
}
);

//const submenu = document.querySelector(".toggle-btn");
//document.querySelector("#sidebarsub").classList.toggle("expand");

//submenu.addEventListener("click", function () {
//    document.querySelector("#sidebarsub").classList.toggle("expand");
//});


