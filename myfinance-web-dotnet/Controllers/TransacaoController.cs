using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet_domain;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoService _transacaoService;
        private readonly IPlanoContaService _planoContaService;

        public TransacaoController(
            ILogger<TransacaoController> logger,
            ITransacaoService transacaoService,
            IPlanoContaService planoContaService
            )
        {
            _logger = logger;
            _transacaoService = transacaoService;
            _planoContaService = planoContaService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var listaTransacao = _transacaoService.ListarRegistros();
            List<TransacaoModel> listaTransacaoModel = new List<TransacaoModel>();

            foreach(var item in listaTransacao)
            {
                TransacaoModel itemTransacao = new TransacaoModel()
                {
                    Id = item.Id,
                    Historico = item.Historico,
                    Date = item.Date,
                    Valor = item.Valor,
                    PlanoContaId = item.PlanoContaId,
                    Tipo = item.PlanoConta.Tipo
                };

                listaTransacaoModel.Add(itemTransacao);
            }

            ViewBag.ListaTransacao = listaTransacaoModel;

            return View();
        }

        public IActionResult Cadastrar(int? Id)
        {

            var listaPlanoConta = new SelectList(_planoContaService.ListarRegistros(), "Id", "Descricao");

            var transacaoModel = new TransacaoModel()
            {
                Date = DateTime.Now,
                ListaPlanoContas = listaPlanoConta
            };

            if (Id != null)
            {
                var transacao = _transacaoService.RetornarRegistro((int)Id);

                transacaoModel.Id = transacao.Id;
                transacaoModel.Historico = transacao.Historico;
                transacaoModel.Date = transacao.Date;
                transacaoModel.Valor = transacao.Valor;
                transacaoModel.PlanoContaId = transacao.PlanoContaId;
            }

                return View(transacaoModel);

        }

        [HttpPost]
        public IActionResult Cadastrar(TransacaoModel model)
        {
            var transacao = new Transacao()
            {
                Id = model.Id,
                Historico = model.Historico,
                Date = model.Date,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId,
            };

            _transacaoService.Cadastrar(transacao);

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int? Id)
        {
            _transacaoService.Excluir((int)Id);
            return RedirectToAction("Index");
        }
    }
}

