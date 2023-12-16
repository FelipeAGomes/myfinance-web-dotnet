using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _dbContext;

        public TransacaoService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        void ITransacaoService.Cadastrar(Transacao Entidade)
        {
            var dbSet = _dbContext.Transacao;

            if(Entidade.Id == null)
            {
                dbSet.Add(Entidade);
            }
            else
            {
                dbSet.Attach(Entidade);
                _dbContext.Entry(Entidade).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        void ITransacaoService.Excluir(int Id)
        {
            var transacao = new Transacao() { Id = Id };
            _dbContext.Attach(transacao);
            _dbContext.Remove(transacao);
            _dbContext.SaveChanges();
        }

        List<Transacao> ITransacaoService.ListarRegistros()
        {
            var dbSet = _dbContext.Transacao.Include(x => x.PlanoConta);
            return dbSet.ToList();
        }

        Transacao ITransacaoService.RetornarRegistro(int Id)
        {
            return _dbContext.Transacao.Where(x => x.Id == Id).First();
        }
    }
}

