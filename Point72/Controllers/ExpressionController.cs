using Microsoft.AspNetCore.Mvc;
using Point72.Repository;

namespace Point72.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpressionController : ControllerBase
    {
        

        private readonly ILogger<ExpressionController> _logger;
        private readonly IExpressionRepository _expressionRepository;

        public ExpressionController(ILogger<ExpressionController> logger, IExpressionRepository expressionRepository)
        {
            _logger = logger;
            _expressionRepository = expressionRepository;
        }



        
    }
}
