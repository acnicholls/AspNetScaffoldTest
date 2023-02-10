using System.ComponentModel.DataAnnotations;

namespace AspNetScaffoldTest.Data.Models
{
	public class Vehicle
	{
		[Key]
		public string fldVIN { get; set; }
		public int? fldModelID { get; set; }
		public int? fldTypeID { get; set; }
		public int? fldColourID { get; set; }
		public short? fldYear { get; set; }
		public int? fldOdometer { get; set; }
		public bool? fldPreviousLease { get; set; }
		public decimal? fldBookValue { get; set; }
		public bool? fldAutomatic { get; set; }
		public bool? fldAir { get; set; }
		public bool? fldPowerLocks { get; set; }
		public bool? fldINLot { get; set; }
		public bool? fldINGarage { get; set; }
	}
}
