using System.ComponentModel.DataAnnotations;

namespace Point72.Models
{
    public class Expressions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Expression { get; set; } = String.Empty;
        [Required]
        public double Result { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

}
