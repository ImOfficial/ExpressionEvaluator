using Microsoft.AspNetCore.Mvc;
using Point72.Models;
using Point72.Repository;
using Point72.Service;

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

        [HttpPost]
        [Route("Evaluate")]
        public async Task<IActionResult> Evaluate([FromBody] ExpressionRequest request)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(new { Error = "Invalid request data." });
                }   
                var expression = request.Expression;
                var result = await ExpressionEvaluatorService.EvaluateExpressionAsync(expression);
                var record = new Expressions
                {
                    Expression = expression,
                    Result = result,
                    CreatedAt = DateTime.UtcNow
                };
                await _expressionRepository.AddExpressionResultAsync(record);

                return Ok(record);
            }

            catch (Exception ex) 
            {
                return BadRequest(new { Error = ex.Message });
            }
        }


        [HttpGet]
        [Route("GetByResult/{result}")]
        public async Task<IActionResult> GetByResult(string result)
        {
            // Model validation is pending here
            try
            {
                if (!double.TryParse(result, out double parsedResult))
                {
                    return BadRequest(new { Error = "Invalid result format. Please provide a valid number." });
                }

                var expressionList = await _expressionRepository.GetExpressionsByResultAsync(parsedResult);
                var record =  new ExpressionList { ExprssionList = expressionList, Result = result };
                return Ok(expressionList);
            }
            catch (Exception ex)
            {
                // I would like to use any logger service to log exception result while returning custome ecetion message for client in future
                return BadRequest(new { Error = ex.Message });
            }
        }







    }
}
