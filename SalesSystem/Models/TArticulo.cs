using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesSystem.Models
{
    public class TArticulo
    {
        public string Codigo { set; get; }
        [Required(ErrorMessage = "El codigo es obligatorio.")]
        public string NombreArticulo { set; get; }
        public decimal PrecioArticulo { set; get; }
        public bool AplicarIVA { set; get; }
        public decimal PrecioConIVA { set; get; }
        public string ErrorMessage { get; set; }

    }
}
