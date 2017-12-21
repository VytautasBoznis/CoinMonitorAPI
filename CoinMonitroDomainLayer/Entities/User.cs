using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinMonitroDomainLayer.Entities
{
	public class User
	{
		public User()
		{
			KeysAndSecrets = new List<KeyAndSecret>();
			CoinModel = new List<CoinModel>();
		}
	
		[Key]
		public int UserId { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public ICollection<KeyAndSecret> KeysAndSecrets { get; set; }
		public ICollection<CoinModel> CoinModel { get; set; }
	}
}
