namespace Point72.Service
{
    public static class ExpressionEvaluatorService
    {
        // Evaluates a mathematical expression represented as a string and returns the result as a double.
        public static Task<double> EvaluateExpressionAsync(string expression)
        {
            try
            {
                var dataTable = new System.Data.DataTable();
                var result = dataTable.Compute(expression, string.Empty);
                return Task.FromResult(Convert.ToDouble(result));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error evaluating expression: {expression}. Error message: {ex.Message}", ex);
            }
        }
    }
}
