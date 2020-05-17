using BusinessLogic.Dosage_Calculator.Interfaces;
using ISpray_Calculator.Interfaces;
using Orleans;
using System.Threading.Tasks;

namespace Spray_Calculator
{
    public class Dosage_CalculatorGrain : Grain, IDosage_CalculatorGrain
    {
        private readonly IDosage_CalculatorBL _dosage_Calculator;
        public Dosage_CalculatorGrain(IDosage_CalculatorBL dosage_Calculator)
        {
            _dosage_Calculator = dosage_Calculator;
        }
        public async Task<(double agent , double water)> CalculateDosage(double agentReq, double fieldSize, double waterRate)
        {
            return await _dosage_Calculator.CalculateAgent(agentReq, fieldSize, waterRate);
        }

    }
}
