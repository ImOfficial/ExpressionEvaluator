namespace Point72.Models
{
    public class ExpressionList
    {
        public String Result { get; set; }
        public List<String> ExprssionList { get; set; } = String.Empty.Split(',').ToList();
    }
}
