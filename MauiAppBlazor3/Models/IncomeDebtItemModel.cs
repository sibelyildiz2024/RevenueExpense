using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MauiAppBlazor3.Models
{
	[Table("IncomeDebtItems")]
	public class IncomeDebtItemModel
	{
		public IncomeDebtItemModel()
		{
			IsDebt = true;
			IsIncome = true;
			CreationDate = DateTime.Now;
			IsActive = true;
		}

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[MaxLength(250), Unique]
		public string? Name { get; set; }

		public string? Description { get; set; }
		public bool IsDebt { get; set; } 
		public bool IsIncome { get; set; } 
		public DateTime CreationDate { get; set; }
		public DateTime? UptdatedDateTime { get; set; }
		public bool IsActive { get; set; } 

		[OneToMany]
		public List<IncomeModel>? Incomes { get; set; }


		[OneToMany]
		public List<DebtModel>? Debts { get; set; }
	}
}
