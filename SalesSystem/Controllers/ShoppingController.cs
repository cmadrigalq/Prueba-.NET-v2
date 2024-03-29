﻿using Microsoft.AspNetCore.Mvc;
using SalesSystem.Data;
using SalesSystem.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SalesSystem.Controllers
{
    public class ShoppingController : Controller
    {
        ArticuloDatos _ArticuloDatos = new ArticuloDatos();

        public ShoppingController() { }
        public ActionResult Shopping()
        {
            return View();

        }
        [HttpGet]
        public List<TArticulo> Listar()
        {
            var oLista = _ArticuloDatos.Listar();

            return oLista;
        }

        [HttpPost]
        public ActionResult NuevoArticulo([FromBody] object data)
        {
            if (!ModelState.IsValid)
                return View();

            // Deserializa la cadena JSON en un objeto TArticulo
            TArticulo articulo = JsonConvert.DeserializeObject<TArticulo>(data.ToString());

            // Ahora puedes usar el objeto articulo como desees
            var respuesta = _ArticuloDatos.Guardar(articulo);

            if (respuesta)
                return RedirectToAction("NuevoArticulo");
            else
                return View();
        }        

        [HttpGet]
        public TArticulo Obtener(string codigo)
        {
            var oarticulo = _ArticuloDatos.Obtener(codigo);
            return oarticulo;
        }



        [HttpPut]
        public ActionResult EditarArticulo(TArticulo oArticulo)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ArticuloDatos.Editar(oArticulo);

            if (respuesta)
                return RedirectToAction("EditarArticulo");
            else
                return View();
        }

        [HttpDelete]
        public ActionResult Eliminar(string codArticulo)
        {
            var oArticulo = _ArticuloDatos.Obtener(codArticulo);
            return View(oArticulo);
        }

        [HttpDelete]
        public ActionResult Eliminar(TArticulo oArticulo)
        {

            var respuesta = _ArticuloDatos.Eliminar(oArticulo.Codigo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
