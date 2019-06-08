using Datos;
using ModeloDatos;
using Sistema_Inventario_Web.CifrarContrasena;
using Sistema_Inventario_Web.Models;
using System;
using System.Web.Mvc;

namespace Sistema_Inventario_Web.Controllers
{
    public class CuentassController : Controller
    {
        // GET: Cuentass
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string password,bool? recordar)
        {
            DatosInventarios datosInventarios = new ModeloDatos.Dto();
            var objUsu = datosInventarios.FindEntity<Usuarios>(c=> c.CorreoElectronico == email && c.Activo == true);
            int id = 0;
            string strMensaje = "El usuario y/o contraseña son incorrectos.";
            if (objUsu != null)
            {
                if (Contraseña.Confirm(password, objUsu.Password, Contraseña.Supported_HA.SHA512))
                {
                    id = -1;
                    Sesssion.AddUserToSession(objUsu.id.ToString(), (bool)recordar);
                    Sesssion.ActualizarSession(objUsu);
                    if (objUsu.Rol_id == 1)
                    {
                        strMensaje = Url.Content("~/Home");
                    }
                }
            }
            return Json(new Response { IsSuccess = true, Message = strMensaje, Id = id }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Registrar(string NombreEmpresa, string CorreoElectronico, string Password)
        {
            DatosInventarios datosInventarios = new ModeloDatos.Dto();
            var objUsu = datosInventarios.FindEntity<Usuarios>(c => c.CorreoElectronico == CorreoElectronico);
            string strMensaje = "";
            int id = 0;
            if (objUsu != null)
            {
                strMensaje = "El usuario ya existe en nuestra base de datos, intente recuperar su cuenta para cambiar su contraseña.";
            }
            else
            {
                string strPass = Contraseña.ComputeHash(Password, Contraseña.Supported_HA.SHA512, null);
                var objEmpresa = datosInventarios.Create(new Empresas
                {
                    CorreoElectronicos = CorreoElectronico,
                    Direccion = "",
                    Logo = "",
                    Moneda = "Pesos",
                    NombreEmpresa = NombreEmpresa,
                    Telefono = "",
                    Tipo_id = 2,
                    ZonaHoraria_id = null
                });
                if (objEmpresa != null)
                {
                    var objUsuNew = datosInventarios.Create(new Usuarios
                    {
                        Activo = true,
                        CorreoElectronico = CorreoElectronico,
                        Empresaid = objEmpresa.id,
                        Fecha = DateTime.Now,
                        Nombres = "",
                        Password = strPass,
                        Rol_id = 1,
                        Telefono = ""
                    });
                    if (objUsuNew != null)
                    {
                        var baseAddress = new Uri(CifrarContrasena.EnviarCorreo.UrlOriginal(Request));
                        string Mensaje = "Gracias por inscribirse al sistema de inventarios, puede entrar con el usuario " +
                            "y contraseña registrada. <a href='" + baseAddress + "'>INVENTARIOS</a>";
                        CifrarContrasena.EnviarCorreo.EnviarMail(CorreoElectronico, "Gracias por registrarte a INVENTARIOS", Mensaje);
                        strMensaje = "Te registraste correctamente, ya puedes entrar al sistema.";
                        id = objUsuNew.id;
                    }
                    else
                    {
                        strMensaje = "Disculpe las molestias, por el momento no podemos conectarnos con el servidor, intentelo nuevamente.";
                    }
                }
                else
                {
                    strMensaje = "Disculpe las molestias, por el momento no podemos conectarnos con el servidor, intentelo nuevamente.";
                }
            }
            return Json(new Response { IsSuccess = true, Message = strMensaje, Id = id }, JsonRequestBehavior.AllowGet);
        }

    }
}
