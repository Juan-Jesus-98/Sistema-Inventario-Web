using Repositorio;
using Sistema_Inventario_Web.Cifrado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Model;

namespace Sistema_Inventario_Web.Atributos
{
    public class AtributoAutomatic : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!SessionHelper.ExistUserInSession())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "Index",
                }));
            }
            else
            {
                IRepositorio Repositorio = new Model.Repositorio();
                int idUser = SessionHelper.GetUser();
                var Usuario = Repositorio.FindEntity<Usuarios>(c => c.id == idUser);
                if (Usuario != null)
                {
                    SessionHelper.ActualizarSession(Usuario);
                }
            }
        }
    }

    public class NoLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (SessionHelper.ExistUserInSession())
            {
                IRepositorio Repositorio = new Model.Repositorio();
                    int idUser = SessionHelper.GetUser();
                var Usuario = Repositorio.FindEntity<Usuarios>(c => c.id == idUser && c.Activo == true);
                if (Usuario != null)
                {
                    SessionHelper.ActualizarSession(Usuario);
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