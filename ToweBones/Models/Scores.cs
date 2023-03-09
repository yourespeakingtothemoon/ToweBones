using System.ComponentModel.DataAnnotations;

namespace ToweBones.Models
{
	public class Scores
	{
		[Key]
		public int ScoreId { get; set; }

		[Required]
		public float Debt { get; set; }
		[Required]
		public int Level { get; set; }

		public string? UserID { get; set; }

		public Scores() { }

	}
}
