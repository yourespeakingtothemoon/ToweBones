using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using ToweBones.Data;

namespace ToweBones.Models
{
    public class User : IdentityUser
    {
        //[Key]
        //[Required]
        //public static int UserID { get; set; }
        //[Required(ErrorMessage = "You must have a username.")]
        //[MaxLength(50)]
        //public string Username { get; set; }
        //[Required(ErrorMessage = "Your must have a password.")]
        //[MaxLength(255)]
        //[MinLength(8)]
        //public string Password { get; set; }
        ////[ForeignKey("AchievementID")] // i have no clue how foreign keys work in mvc. i think that this is correct but idk

        [Required]
        public int pfpID { get; set; } = 1;

		//public string Bio { get; set; }

        public int HiLevel { get; set; } = 0;
		public int HiDebt { get; set; } = 0;

		//ublic Boolean IsActive { get; set; } = false;

		public User(string name, string email)
		
		{
			UserName = name;
			Email = email;
			
		}

		//each earned achievement will be pushed to front so that the most recent achievement is at the top
		//maybe change this to a list later
		//public List<Achievement> Earned { get; set; }

		//for big ach page only
		// public List<Achievement> Locked { get; set; }
		//will create more robust acheivment system for this later
		// there will probably need to be more things here like preferences and maybe stats or something

		public User( )
		{ 


			//UserID = id;
		
		}

		public string getPfpFile()
        {
			return "pfp" + pfpID + ".png";
		}

		public int getScore()
		{
			int score = HiLevel * HiDebt;
			return score;
		}


	}
}
