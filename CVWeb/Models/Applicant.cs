using System.ComponentModel.DataAnnotations;

namespace CVSystem.Models
{
    public class Applicant
    {
        public int Id { get; set; }

        [Required]
        public string?
            FullName { get; set; }

        [Required]
        public string?  Email { get; set; }

        public string?
            CvFilePath { get; set; }
    }
}