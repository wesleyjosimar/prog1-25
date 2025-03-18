using System.ComponentModel.DataAnnotations;

namespace numtowords.Models
{
    public class NumberModel
    {
        [Required]
        public int Number { get; set; }

        public string NumberInWords { get; set; } = string.Empty; 
        public string Category { get; set; } = string.Empty; 
    }
}
