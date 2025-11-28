using System.ComponentModel.DataAnnotations;

namespace Point72.Models
{
    public class ExpressionRequest
    {
        [Required]
        [StringLength(512, ErrorMessage ="Character limit exceeded")]
        [RegularExpression(@"^[0-9\+\-\*/\(\)\.\s]+$",
        ErrorMessage = "Expression contains invalid characters.")]

        public String Expression { get; set; }= String.Empty;
    }
}
