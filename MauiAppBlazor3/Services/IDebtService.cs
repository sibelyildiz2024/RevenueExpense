using MauiAppBlazor3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppBlazor3.Services
{
	public interface IDebtService : IGenericService<DebtModel>
	{
		public Task<List<DebtModel>> GetAllDebtByDateAsync(
			DateTime startDate, 
			DateTime finishDate);

		public Task<List<DebtModel>> GetAllDebtByDateCategoryAsync(
			DateTime startDate,
			DateTime finishDate,
			int? CategoryId);
	}
}
