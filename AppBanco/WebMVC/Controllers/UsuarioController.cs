using AppBancoDLL;
using AppBancoDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            var metodoUsuario = new UsuarioDAO();
            var TodosUsuarios = metodoUsuario.Listar();
            return View(TodosUsuarios);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
               var metodoUsuario = new UsuarioDAO();
                metodoUsuario.Insert(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        //Adicionar ideia ao projeto
        public ActionResult Editar(int Id)
        {
            var metodoUsuario = new UsuarioDAO();
            var usuario = metodoUsuario.ListarID(Id);

            if(usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }
        
        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var metodoUsuario = new UsuarioDAO();
                metodoUsuario.Salvar(usuario);
            }
                return RedirectToAction("Index");
 
        }

        public ActionResult Detalhes(int Id)
        {
            var metodoUsuario = new UsuarioDAO();
            var usuario = metodoUsuario.ListarID(Id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

  
        public ActionResult Deletar(int Id)
        {
            var metodoUsuario = new UsuarioDAO();
            var usuario = metodoUsuario.ListarID(Id);
            
            if (usuario == null)
            {
                return HttpNotFound();
            }

           return View(usuario);
        }

        //A ActionName deve receber o mesmo nome da outra action, neste caso "Deletar"
        [HttpPost, ActionName("Deletar")]
        public ActionResult ConfirmaDeletar(int Id)
        {         
            var metodoUsuario = new UsuarioDAO();
            //O metodo inicialmente recebe um Id, porem o método Excluir recebe como parametro um objeto do tipo Usuario
            //Basta instanciar o objeto e dar a propriedade IdUsu para ele receber o parametro int do metodo 'ConfirmaDeletar'
            var usuario = new Usuario();
            usuario.IdUsu = Id;
            metodoUsuario.Excluir(usuario);

            return RedirectToAction("Index");
        }
    }
}