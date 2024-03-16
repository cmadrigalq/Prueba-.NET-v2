using Microsoft.AspNetCore.Mvc;
using SalesSystem.Data;
using SalesSystem.Models;
using System;
using System.Collections.Generic;

namespace SalesSystem.Controllers
{
    public class FacturaController : Controller
    {
        FacturaDatos _FacturaDatos = new FacturaDatos();

        public FacturaController() { }
        public ActionResult Factura()
        {
            return View();

        }
        public ActionResult Listar()
        {
            var oLista = _FacturaDatos.Listar();

            return View(oLista);
        }

        public ActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(TFactura oFactura)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _FacturaDatos.Guardar(oFactura);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        [HttpPost]
        public ActionResult GuardarFilasFactura(string datos)
        {
            var filas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(datos);
            TFactura oFactura = new TFactura();

            foreach (var fila in filas)
            {
                //oFactura.CodigoArticulo = fila["columna1"];
              /*  oFactura.UsuarioFactura = fila["columna2"];
                oFactura.CantidadArticulo = Convert.ToUInt32( fila["columna3"]);
                oFactura.ConsecutivoFactura = fila["columna4"];*/
                oFactura.FechaFactura = System.DateTime.Now;
                oFactura.DetallesFactura = "Direccion: Lorem ipsum Telefono: +1 000 000 0000";
                _FacturaDatos.Guardar(oFactura);
            }

            return Json(new { success = true });
        }
        public ActionResult Obtener(string codigo)
        {
            var ocontacto = _FacturaDatos.Obtener(codigo);
            return View(ocontacto);
        }

        [HttpPost]
        public ActionResult Editar(TFactura oFactura)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _FacturaDatos.Editar(oFactura);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public ActionResult Eliminar(string codigo)
        {
            var ocontacto = _FacturaDatos.Obtener(codigo);
            return View(ocontacto);
        }

        [HttpPost]
        public ActionResult Eliminar(TFactura oFactura)
        {

            var respuesta = _FacturaDatos.Eliminar(oFactura.ConsecutivoFactura);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
