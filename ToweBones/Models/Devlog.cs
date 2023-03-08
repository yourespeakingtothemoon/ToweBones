using System.ComponentModel.DataAnnotations;

namespace ToweBones.Models
{
    public class Devlog
    {
        [Key]
        public int DevlogID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Devlog(string title, string content, string img, DateTime date)
        {
            Title = title;
            Content = content;
            Image = img;
            Date = date;
        }

        public Devlog() { }
    }
}
