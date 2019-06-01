using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Inventario_Web.Controllers
{
    public class CuentasController : Controller
    {
        // GET: Cuentas
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email,string Password)
        {
            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }
    }

}