using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppBlazor3.Models
{
	public class ReportModel
	{
		public int Id { get; set; }
		public string? Category { get; set; }
		public int? CategoryId { get; set; }
		public DateTime? IncomeDate { get; set; }
		public DateTime? DebtDate { get; set; }
		public decimal? IncomeAmount { get; set; }
		public decimal? DebtAmount { get; set; }
	}
}
