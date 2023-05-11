using System.ComponentModel.DataAnnotations;

namespace MVC_Test.Models
{
    public class Todo
    {
        [Display (Name = "User ID")]
        public int userId { get; set; }

        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Completed")]
        public bool Completed { get; set; }

    }
}
