using Datos;
using ModeloDatos;
using Sistema_Inventario_Web.CifrarContrasena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sistema_Inventario_Web.Atributos
{
    public class AutomaticPage: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!Sesssion.ExistUserInSession())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "Index"
                }));
            }
            else
            {
                DatosInventarios datosInventarios = new ModeloDatos.Dto();
                int idUser = Sesssion.GetUser();
                var Usuario = datosInventarios.FindEntity<Usuarios>(c => c.id == idUser);
                if (Usuario != null)
                {
                    Sesssion.ActualizarSession(Usuario);
                }
            }
        }
    }

    public class NoLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Sesssion.ExistUserInSession())
            {
                DatosInventarios datosinventarios = new ModeloDatos.Dto();
                int idUser = Sesssion.GetUser();
                var Usuario = datosinventarios.FindEntity<Usuarios>(c => c.id == idUser && c.Activo == true);
                if (Usuario != null)
                {
                    Sesssion.ActualizarSession(Usuario);
                    if (Usuario.Rol_id == 1)
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Admin",
                            action = "Index"
                        }));
                    }
                }

            }
        }
    }
}
