using asp_with_users_and_rols.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_with_users_and_rols.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        // Metodo POST para capturar el User y el Password
        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            try
            {
                // Abrimos conexión a nuestra base de datos
                using (DB_LogginEntities db = new DB_LogginEntities())
                {
                    // Encriptamos la contraseña que el usuario escribio antes de realizar proceso de autenticación.
                    pass = Tools.Encriptation.GetSHA256(pass);
                    // Declaramos variale que captura los datos de los input
                    var oUser = (from d in db.Usuarios
                                 where d.Correo == email.Trim() && d.Contraseña == pass.Trim()
                                 select d).FirstOrDefault();

                    // Validamos la información
                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o contraseña incorrecta";
                        return View();
                    }

                    // Creamos el filtro para bloquear el acceso a las demas páginas
                    Session["User"] = oUser;

                }
                // Si la autenticación del usuario es correcta, redireccionamos a la página de principal.
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                // En caso de error mandamos un mensaje con el error
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}