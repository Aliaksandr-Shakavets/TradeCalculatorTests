namespace Tests_Core.Data_access_layer.Calculations
{
    public class ExceptionResult : ICalculationResult
    {
        public string ExceptionMessage { get; set; } = "Exception was thrown.";
    }
}
