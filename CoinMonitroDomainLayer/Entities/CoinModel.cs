using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinMonitroDomainLayer.Entities
{
	public class CoinModel
	{
		[Key]
		public int CoinModelID { get; set; }
		public string PairFrom { get; set; }
		public string PairTo { get; set; }
		public decimal Price { get; set; }
		public decimal Amount { get; set; }
		public int UserId { get; set; }

		public User User { get; set; }
	}
}
