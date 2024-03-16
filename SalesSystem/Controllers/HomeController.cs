using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SalesSystem.Data;
using SalesSystem.Models;

namespace SalesSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeController()
        {
           
        }

        public Task<IActionResult> Index()
        {
            return Task.FromResult<IActionResult>(View());    
        }
            

        [HttpPost]
        public Task<IActionResult> Index(Usuario usuario)
        {
            var cadenaConexion = new ApplicationDbContext();

            usuario.Contraseña = ConvertirSha256(usuario.Contraseña);

            using (SqlConnection cn = new SqlConnection(cadenaConexion.getCadenaSQL()))
            {

                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("NombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("Contraseña", usuario.Contraseña);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                usuario.NombreUsuario = cmd.ExecuteScalar().ToString();

            }

            if (usuario.NombreUsuario != "")
            {
                return Task.FromResult<IActionResult>( RedirectToAction(nameof(Principal), "Principal"));
            }
            else
            {
                ViewData["Mensaje"] = "usuario no encontrado";
        
                return Task.FromResult<IActionResult>(View());
            }

        }

        private string ConvertirSha256(string contraseña)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(contraseña));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
