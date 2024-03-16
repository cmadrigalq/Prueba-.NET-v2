using System;

namespace SalesSystem.Models
{
    public class TDetalle
    {
        public int CodigoDetalle { set; get; }
        public int ConsecutivoFactura { set; get; }
        public string CodigoArticulo { set; get; }
        public int Cantidad { set; get; }
        public int PrecioFinal { set; get; }
    }
}
