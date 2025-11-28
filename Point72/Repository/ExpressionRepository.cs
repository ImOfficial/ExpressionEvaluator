using Microsoft.EntityFrameworkCore;
using Point72.Data;
using Point72.Models;

namespace Point72.Repository
{
    public class ExpressionRepository : IExpressionRepository
    {
        private readonly ApplicationDbContext _context;
        public ExpressionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Expressions?> AddExpressionResultAsync(Expressions record)
        {
            try
            {
                await _context.Expressions.AddAsync(record);
                await _context.SaveChangesAsync();
                return record;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding result for expression :{record.Expression}. Error message : {ex.Message}", ex);
            }

        }

        public Task<List<Expressions>> GetExpressionsByResultAsync(double result)
        {
            try
            {
                return _context.Expressions
                    .Where(e => e.Result == result)
                    .OrderByDescending(e => e.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving expressions by result: {ex.Message}", ex);

            }
        }
    }
}
