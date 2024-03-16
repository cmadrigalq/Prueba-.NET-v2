using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Data;
using SalesSystem.Models;

namespace SalesSystem.Controllers
{
    public class PrincipalController : Controller
    {
		public IActionResult Principal(int id, string filtrar, int registros)
        {
				return View();
        }
    }
}