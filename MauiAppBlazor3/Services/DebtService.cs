using MauiAppBlazor3.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;


namespace MauiAppBlazor3.Services
{
	public class DebtService : IDebtService
	{
		string? _dbPath;
		private SQLiteAsyncConnection conn;

		public DebtService(string? dbPath)
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

				await conn.CreateTableAsync<DebtModel>();
			}
		}

		public async Task<int> Delete(DebtModel t)
		{
			return await conn.DeleteAsync(t);
		}

		public async Task<List<DebtModel>> GetAll()
		{
			List<DebtModel> data = new();
			data = await conn.GetAllWithChildrenAsync<DebtModel>();
			

			return data;
		}

		public async Task<DebtModel> GetById(int id)
		{
			return await conn.Table<DebtModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<int> Insert(DebtModel t)
		{
			t.IsActive = true;
			return await conn.InsertAsync(t);
		}

		public async Task<int> Update(DebtModel t)
		{

			return await conn.UpdateAsync(t);
		}

		public async Task<List<DebtModel>> GetAllDebtByDateAsync(DateTime startDate, DateTime finishDate)
		{
			var returnData = await conn.GetAllWithChildrenAsync<DebtModel>();
			return returnData
				.Where(x => x.DebtDate >= startDate && x.DebtDate <= finishDate)
				.OrderByDescending(x => x.DebtDate)
				.ToList();
		}

		public async Task<List<DebtModel>> GetAllDebtByDateCategoryAsync(
			DateTime startDate,
			DateTime finishDate,
			int? CategoryId)
		{
			var returnData = await conn.GetAllWithChildrenAsync<DebtModel>();
			
			return returnData
				.Where(
					x => x.DebtDate >= startDate &&
					x.DebtDate <= finishDate &&
					x.IncomeDebtItemModel?.Id == CategoryId)
				.OrderByDescending(x => x.DebtDate)
				.ToList();
		}
	}
}
