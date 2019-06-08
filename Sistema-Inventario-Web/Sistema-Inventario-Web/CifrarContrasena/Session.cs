using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Sistema_Inventario_Web.CifrarContrasena
{
   
        public class Sesssion
        {
            public static bool ExistUserInSession()
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
            public static void DestroyUserSession()
            {
                FormsAuthentication.SignOut();
            }
            public static int GetUser()
            {
                int user_id = 0;
                if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
                {
                    FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                    if (ticket != null)
                    {
                        user_id = Convert.ToInt32(ticket.UserData);
                    }
                }
                return user_id;
            }

            public static void AddUserToSession(string id, bool persist)
            {
                var cookie = FormsAuthentication.GetAuthCookie("UserInventory", persist);

                cookie.Name = FormsAuthentication.FormsCookieName;
                cookie.Expires = DateTime.Now.AddMonths(1);

                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, id);

                cookie.Value = FormsAuthentication.Encrypt(newTicket);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

            public static void ActualizarSession(Usuarios Usuario)
            {
                HttpContext.Current.Session["Usuario_ID"] = Usuario.id;
                HttpContext.Current.Session["CorreoElectronico"] = Usuario.CorreoElectronico;
                HttpContext.Current.Session["EmpresaId"] = Usuario.Empresaid;
                HttpContext.Current.Session["Rol_Id"] = Usuario.Rol_id;
                HttpContext.Current.Session["Nombres"] = Usuario.Nombres;
            }

        }
    }
