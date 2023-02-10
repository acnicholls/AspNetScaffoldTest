using System.ComponentModel.DataAnnotations;

namespace AspNetScaffoldTest.Data.Models
{
	public class Lease
	{
		[Key]
		public int fldLeaseID { get; set; }
		public int? fldCustomerID { get; set; }
		public string? fldVIN { get; set; }
		public int? fldLeaseTermsID { get; set; }
		public int? fldBeginOdometer { get; set; }
		public DateTime? fldContractStartDate { get; set; }
		public DateTime? fldPaymentStartDate { get; set; }
		public decimal? fldMonthlyPayment { get; set; }
		public byte? fldNumberOfPayments { get; set; }
		public int? fldEndOdometer { get; set; }
		public bool? fldLTRThankYou { get; set; }
		public bool? fldLTRExpiry { get; set; }
		public bool? fldLTRTermination { get; set; }
		public DateTime? fldTerminationDate { get; set; }
	}
}
