using System;

namespace SalesSystem.Models
{
    public class TFactura
    {
        public int UsuarioFactura { set; get; }
        public int ConsecutivoFactura { set; get; }
        public DateTime FechaFactura { set; get; }
        public string DetallesFactura { set; get; }
    }
}
