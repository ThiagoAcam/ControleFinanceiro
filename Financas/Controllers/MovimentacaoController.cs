using Financas.DAO;
using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financas.Controllers
{
    [Authorize]
    public class MovimentacaoController : Controller
    {
        private MovimentacaoDAO movimentacaoDADO;
        private UsuarioDAO usuarioDAO;

        public MovimentacaoController(MovimentacaoDAO movimentacaoDAO, UsuarioDAO usuarioDAO)
        {
            this.movimentacaoDADO = movimentacaoDAO;
            this.usuarioDAO = usuarioDAO;
        }

        // GET: Movimentacao
        public ActionResult Form()
        {
            ViewBag.Usuarios = usuarioDAO.Lista();

            return View();
        }

        public ActionResult Adiciona(Movimentacao movimentacao)
        {
            if(ModelState.IsValid)
            {
                movimentacaoDADO.Adiciona(movimentacao);
                return RedirectToAction("Index", "Movimentacao");
            }
            else
            {
                ViewBag.Usuarios = usuarioDAO.Lista();
                return View("Form", movimentacao);
            }
        }

        public ActionResult Index()
        {
            IList<Movimentacao> movimentacoes = movimentacaoDADO.Lista();

            return View(movimentacoes);
        }

    }
}