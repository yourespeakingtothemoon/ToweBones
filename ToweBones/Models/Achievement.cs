using System.ComponentModel.DataAnnotations;

namespace ToweBones.Models
{
    public class Achievement
    {
        /// <summary>
        /// IN THE BIN FOR NOW, I LOVE THIS FEATURE IDEA, BUT AT THE MOMENT IT IS NOT NECESSARY
        /// </summary>

        [Key]
        [Required]
        public static int AchievementID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public string? Image { get; set; }

        public Achievement(string name, string desc, string img)
        {
            Name = name;
            Description = desc;
            Image = img;

        }
    }
}
