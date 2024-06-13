using MauiAppBlazor3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppBlazor3.Services
{
	internal interface IInComeDebtItemService : IGenericService<IncomeDebtItemModel>
	{
		Task<List<IncomeDebtItemModel>> GetAllIncomeSourceAsync();
		Task<List<IncomeDebtItemModel>> GetAllDebtSourceAsync();
		Task<IncomeDebtItemModel> GetByName(string name);
		Task<IncomeDebtItemModel?> GetWithChildByIdAsync(int id);
	}
}
