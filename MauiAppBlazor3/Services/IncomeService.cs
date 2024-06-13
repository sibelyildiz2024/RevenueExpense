using MauiAppBlazor3.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using SQLiteNetExtensionsAsync.Extensions;

namespace MauiAppBlazor3.Services
{
	public class IncomeService : IIncomeService
	{
		string? _dbPath;
		private SQLiteAsyncConnection conn;
		public IncomeService(string? dbPath)
		{
			_dbPath = dbPath;
			InitAsync();
		}

		private async void InitAsync()
		{
			if (conn != null)
			{
				return;
			}
			else
			{
				conn = new SQLiteAsyncConnection(_dbPath);
				await conn.CreateTableAsync<IncomeModel>();
			}
		}

		public async Task<int> Delete(IncomeModel t)
		{

			return await conn.DeleteAsync(t);
		}

		public async Task<List<IncomeModel>> GetAll()
		{
			List<IncomeModel> data = new();
			data = await conn.GetAllWithChildrenAsync<IncomeModel>();

			//return await conn.Table<IncomeModel>().ToListAsync();
			return data;
		}

		public async Task<IncomeModel> GetById(int id)
		{
			return await conn.Table<IncomeModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<int> Insert(IncomeModel t)
		{
			t.IsActive = true;

			return await conn.InsertAsync(t);
		}

		public Task<int> Update(IncomeModel t)
		{
			return conn.UpdateAsync(t);
		}

		public async Task<List<IncomeModel>> GetAllIncomeByDateAsync(DateTime startDate, DateTime finishDate)
		{
			var returnData = await conn.GetAllWithChildrenAsync<IncomeModel>();
			return returnData
				.Where(x => x.InComeDate >= startDate && x.InComeDate <= finishDate)
				.OrderByDescending(x => x.InComeDate)
				.ToList();
		}

		public async Task<List<IncomeModel>> GetAllIncomeByDateCategoryAsync(
			DateTime startDate,
			DateTime finishDate,
			int? CategoryId)
		{
			var returnData = await conn.GetAllWithChildrenAsync<IncomeModel>();
			return returnData
				.Where(
					x => x.InComeDate >= startDate &&
					x.InComeDate <= finishDate &&
					x.IncomeDebtItemModel?.Id == CategoryId)
				.OrderByDescending(x => x.InComeDate)
				.ToList();
		}
	}
}
