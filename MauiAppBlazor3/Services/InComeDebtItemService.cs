using MauiAppBlazor3.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace MauiAppBlazor3.Services
{
	public class InComeDebtItemService : IInComeDebtItemService
	{
		string? _dbPath;
		public string? StatusMessage { get; set; }

		public InComeDebtItemService(string? dbPath)
		{
			_dbPath = dbPath;
			InitAsync();
		}

		private SQLiteAsyncConnection conn;
		private async void InitAsync()
		{
			// Don't Create database if it exists
			if (conn != null)
				return;
			// Create database and  Table
			conn = new SQLiteAsyncConnection(_dbPath);
			await conn.CreateTableAsync<IncomeDebtItemModel>();
		}

		public async Task<int> Delete(IncomeDebtItemModel t)
		{
			return await conn.DeleteAsync(t);
		}

		public async Task<List<IncomeDebtItemModel>> GetAll()
		{
			//return await conn.GetAllWithChildrenAsync<IncomeDebtItemModel>();
			return await conn.Table<IncomeDebtItemModel>().OrderBy(x=>x.Name).ToListAsync();
		}

		public async Task<List<IncomeDebtItemModel>> GetAllIncomeSourceAsync()
		{
			return await conn.Table<IncomeDebtItemModel>()
				.Where(x => x.IsIncome == true && x.IsActive == true)
				.OrderBy(x=>x.Name)
				.ToListAsync();
		}

		public async Task<List<IncomeDebtItemModel>> GetAllDebtSourceAsync()
		{
			return await conn.Table<IncomeDebtItemModel>()
				.Where(x => x.IsDebt == true && x.IsActive == true)
				.OrderBy(x=>x.Name)
				.ToListAsync();
		}
		public async Task<IncomeDebtItemModel> GetById(int id)
		{
			return await conn.Table<IncomeDebtItemModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<int> Insert(IncomeDebtItemModel t)
		{
			return await conn.InsertAsync(t);
		}

		public async Task<int> Update(IncomeDebtItemModel t)
		{
			t.UptdatedDateTime = DateTime.Now;
			return await conn.UpdateAsync(t);
		}

		public async Task<IncomeDebtItemModel> GetByName(string name)
		{
			return await conn
				.Table<IncomeDebtItemModel>()
				.Where(x => x.Name == name && x.IsActive == true)
				.FirstOrDefaultAsync();
		}

		public async Task<IncomeDebtItemModel?> GetWithChildByIdAsync(int id)
		{
			var data = await conn.GetAllWithChildrenAsync<IncomeDebtItemModel>();

			return data.FirstOrDefault<IncomeDebtItemModel>(x => x.Id == id);
		}
	}
}
