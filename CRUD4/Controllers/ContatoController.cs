using CRUD4.Models;
using CRUD4.Repositório;
using Microsoft.AspNetCore.Mvc;

namespace CRUD4.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContato _contatoRep;
        public ContatoController(IContato contatoRep)
        {
            _contatoRep = contatoRep;
        }

        public IActionResult Index()
        {
           List<ContatoModel> contatos = _contatoRep.ListarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(Guid Id)
        {
            ContatoModel contato = _contatoRep.Listar(Id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(Guid Id)
        {
            ContatoModel contato = _contatoRep.Listar(Id);
            return View(contato);
        }

        public IActionResult Apagar(Guid Id)
        {
            try
            {
                bool apagado = _contatoRep.Apagar(Id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato.";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato. Detalhes do erro: {e.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   contato = _contatoRep.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);

            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato. Tente novamente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRep.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch(System.Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu contato. Tente novamente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
            
        }
    }
}
