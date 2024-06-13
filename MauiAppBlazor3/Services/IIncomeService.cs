using MauiAppBlazor3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppBlazor3.Services
{
	public interface IIncomeService : IGenericService<IncomeModel>
	{
		public Task<List<IncomeModel>> GetAllIncomeByDateAsync(
			DateTime startDate, 
			DateTime finishDate);
		public Task<List<IncomeModel>> GetAllIncomeByDateCategoryAsync(
			DateTime startDate,
			DateTime finishDate,
			int? CategoryId);
	}
}
