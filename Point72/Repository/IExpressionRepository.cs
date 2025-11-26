using Point72.Models;

namespace Point72.Repository
{
    public interface IExpressionRepository
    {
        Task<Expressions?> AddEpressionResultAsync(Expressions record);
        Task<List<Expressions>> GetExpressionsByResultAsync(double result);
        
    }
}
