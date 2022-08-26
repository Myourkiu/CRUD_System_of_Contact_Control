using CRUD4.Models;
using CRUD4.Repositório;
using Microsoft.AspNetCore.Mvc;

namespace CRUD4.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuarioRep;

        public UsuarioController(IUsuario usuarioRep)
        {
            _usuarioRep = usuarioRep;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRep.ListarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao(Guid Id)
        {
            UsuarioModel usuario = _usuarioRep.Listar(Id);
            return View(usuario);
        }

        public IActionResult Editar(Guid Id) 
        {
            UsuarioModel usuario = _usuarioRep.Listar(Id);
            return View(usuario);
        }

        public IActionResult Apagar(Guid Id)
        {
            try
            {
                bool apagado = _usuarioRep.Apagar(Id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu usuário.";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuário. Detalhes do erro: {e.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(UsuarioModel_noPass usuarioNoPass)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {

                    usuario = new UsuarioModel()
                    {
                        Id = usuarioNoPass.Id,
                        Nome = usuarioNoPass.Nome,
                        Login = usuarioNoPass.Login,
                        Email = usuarioNoPass.Email,
                        Perfil = usuarioNoPass.Perfil

                        //passa as informações do usuarioNoPass pra variavel usuario
                    };

                    usuario = _usuarioRep.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu usuário. Tente novamente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRep.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);

            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário. Tente novamente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
