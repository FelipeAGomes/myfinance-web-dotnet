using System;
using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_infra.Interfaces
{
	public class PlanoContaRepository : Repository<PlanoConta>, IPlanoContaRepository
	{
		public PlanoContaRepository(MyFinanceDbContext myFinanceDbContext): base(myFinanceDbContext)
		{
		}
	}
}

