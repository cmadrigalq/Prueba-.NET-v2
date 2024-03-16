using SalesSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesSystem.Repositorio
{
    public interface IAPIService
    {
        Task<List<TArticulo>> ListarArticulos();
        Task<TArticulo> BuscarArticulo(string codArticulo);
        Task<bool> GuardarArticulo(TArticulo articulo);
        Task<bool> ModificarArticulo(TArticulo articulo);
        Task<bool> EliminarArticulo(string codArticulo);

        Task<List<TFactura>> ListaFacturaConArticulos();

        Task<bool> AgregarArticuloAFactura(TFactura factura);



    }
}
