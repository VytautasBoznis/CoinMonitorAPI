using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinMonitroDomainLayer.Entities
{
	public class KeyAndSecret
	{
		[Key]
		public int PairId { get; set; }
		public int UserId { get; set; }
		public string Key { get; set; }
		public string Secret { get; set; }

		public User User { get; set; }
	}
}
