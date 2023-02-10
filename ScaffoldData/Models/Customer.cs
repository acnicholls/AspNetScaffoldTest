using System.ComponentModel.DataAnnotations;

namespace AspNetScaffoldTest.Data.Models
{
	public class Customer
	{
		[Key]
		public int fldCustomerID { get; set; }
		public string? fldFirstName { get; set; }
		public string? fldLastName { get; set; }
		public string? fldApartment { get; set; }
		public string? fldAddress { get; set; }
		public string? fldCity { get; set; }
		public string? fldProvince { get; set; }
		public string? fldPostalCode { get; set; }
		public string? fldPhoneNumber { get; set; }
		public string? fldEmail { get; set; }
	}
}
