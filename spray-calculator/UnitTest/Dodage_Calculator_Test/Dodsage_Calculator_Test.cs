using Agrovision.Spray_Calculator.Data;
using BusinessLogic.Dosage_Calculator.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace Dodage_Calculator_Test
{
    public class Dodsage_CalculatorTest
    {
        private readonly Dosage_Calculator _dosage_Calculator;
        public List<(double agentReq, double fieldSize, double waterRate, double agentOutcome, double waterOutcome)> TestData =
            new List<(double agentReq, double fieldSize, double waterRate, double agentOutcome, double waterOutcome)> {
        (1.6, 5.03 , 250, 8.048, 1249.452),
        (1.6, 4.62 , 250, 7.392, 1147.608),
        (1.6, 4.38 , 250, 7.008, 1087.992),
        (1.6, 7.91 , 250, 12.656, 1964.844)

        };
        public Dodsage_CalculatorTest()
        {
            _dosage_Calculator = new Dosage_Calculator();
        }
        [Fact, Description("Test Dosage Calculator")]
        public async Task TestDosageCalculator()
        {
            TestData.ForEach(async z  => 
            {
                var fieldRes = await _dosage_Calculator.CalculateAgent(z.agentReq, z.fieldSize, z.waterRate);
                Assert.True(fieldRes.agent == z.agentOutcome && fieldRes.water == z.waterOutcome);
            });
            await Task.CompletedTask;
        }
        [Fact, Description("Test Spray Calculator DB")]
        public async Task TestSprayCalculatorDB()
        {
            using var _context = new SprayCalculatorContext();
             Assert.True(await _context.Database.CanConnectAsync());
          
        }
    }
}
