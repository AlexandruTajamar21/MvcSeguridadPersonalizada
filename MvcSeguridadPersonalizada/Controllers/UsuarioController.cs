using Microsoft.AspNetCore.Mvc;
using MvcSeguridadPersonalizada.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSeguridadPersonalizada.Controllers
{
    public class UsuarioController : Controller
    {
        [AuthorizeUsers]
        public IActionResult Perfil()
        {
            return View();
        }
    }
}
