using System.ComponentModel.DataAnnotations;

namespace MyEStoreProject.Models
{
	public class LoginVM
	{
		[MaxLength(20, ErrorMessage ="*")]
		public string UserName { get; set;}

		[DataType(DataType.Password)]
		[MaxLength(20, ErrorMessage = "*")]
		public string Password { get; set;}
	}
}
