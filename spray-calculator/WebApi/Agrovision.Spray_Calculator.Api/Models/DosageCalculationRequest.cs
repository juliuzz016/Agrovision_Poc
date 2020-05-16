namespace Agrovision.Spray_Calculator.Api.Models
{
    public class DosageCalculationRequest
    {
        public double AgenVolume { get; set; }
        public double FieldSize { get; set; }
        public double WaterRate { get; set; }
    }
}
