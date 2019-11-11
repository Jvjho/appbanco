using AppBancoDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var metodoUsuario = new UsuarioDAO();
            var TodosUsuarios = metodoUsuario.Listar();
            return View(TodosUsuarios);
        }

    }
}