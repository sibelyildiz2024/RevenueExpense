using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MauiAppBlazor3.Models
{
	[Table("Incomes")]
	public class IncomeModel
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[ForeignKey(typeof(IncomeDebtItemModel))]
        public int IncomeDebtItemId { get; set; }

		[ManyToOne]
		public IncomeDebtItemModel? IncomeDebtItemModel { get; set; }

		public decimal InComeAmount { get; set; }
        public DateTime InComeDate { get; set; }

        public string? Desctiption { get; set; }
        public bool IsActive { get; set; }
        
    }
}
