using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MauiAppBlazor3.Models
{
	[Table("Debts")]
	public class DebtModel
	{
		[PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(IncomeDebtItemModel))]
        public int IncomeDeptId { get; set; }

		[ManyToOne]
		public IncomeDebtItemModel? IncomeDebtItemModel { get; set; }

		[Required(ErrorMessage ="Lütfen tutar bilgisi giriniz.")]
		public decimal DebtAmount { get; set; }
        public DateTime DebtDate { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
