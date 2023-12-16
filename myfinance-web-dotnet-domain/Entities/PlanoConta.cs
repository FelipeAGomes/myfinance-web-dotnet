using myfinance_web_dotnet_domain.Entities.Base;

namespace myfinance_web_dotnet_domain.Entities;

public class PlanoConta : EntityBase
{

    public string Descricao { get; set; }

    public string Tipo { get; set; }

    public PlanoConta(int? id, string descricao, string tipo)
    {
        Id = id;
        Descricao = descricao;
        Tipo = tipo;
    }

    public PlanoConta()
    {
    }
}
