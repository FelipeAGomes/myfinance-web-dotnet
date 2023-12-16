using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_domain.Entities.Base;

namespace myfinance_web_dotnet_domain;

public class Transacao : EntityBase
{

    public string Historico { get; set; }

    public DateTime Date { get; set; }

    public decimal Valor { get; set; }

    public int PlanoContaId { get; set; }

    public PlanoConta PlanoConta { get; set; }

    public Transacao(int? id, string historico, DateTime date, decimal valor, int planoContaId, PlanoConta planoConta)
    {
        Id = id;
        Historico = historico;
        Date = date;
        Valor = valor;
        PlanoContaId = planoContaId;
        PlanoConta = planoConta;
    }

    public Transacao()
    {
    }
}
