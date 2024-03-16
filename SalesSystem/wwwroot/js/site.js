// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var principal = new Principal();

/*CODIGO DE USUARIOS*/
//var shopping = new Shopping();

/*CODIGO DE CLIENTES*/
var factura = new Factura();

$().ready(() => {
    let URLactual = window.location.pathname;
    principal.userLink(URLactual);
   
});