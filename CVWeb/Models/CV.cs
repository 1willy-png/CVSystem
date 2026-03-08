using System.ComponentModel.DataAnnotations;

namespace CVSystem.Models
{
    public class CV
    {
        public int Id { get; set; }

        [Required]
        public string?
            FullName { get; set; }

        [Required]
        public string?
            Phone { get; set; }

        [Required]
        public string?
            Education { get; set; }

        [Required]
        public string?
            Experience { get; set; }

        [Required]
        public string?
            Skills { get; set; }

        public int UserId { get; set; }
        public User?
            User { get; set; }
    }
}