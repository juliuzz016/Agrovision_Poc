using BusinessLogic.Dosage_Calculator.Interfaces;
using System.Threading.Tasks;

namespace BusinessLogic.Dosage_Calculator.Services
{
    public class Dosage_Calculator : IDosage_CalculatorBL
    {
        public async Task<(double agent, double water)> CalculateAgent(double requiredAgentVolume, double requiredHectare, double minimumSprayRate)
        {
            return await Task.FromResult((
                await CalculateAgentAmount(requiredAgentVolume, requiredHectare),
                await CalculateWaterAmount(requiredAgentVolume, requiredHectare, minimumSprayRate)
                ));
        }
        private async Task<double> CalculateAgentAmount(double requiredAgentVolume, double requiredHectare)
        {
            return await Task.FromResult(requiredAgentVolume * requiredHectare);
        }
        private async Task<double> CalculateWaterAmount(double requiredAgentVolume, double requiredHectare, double minimumSprayRate)
        {
            return await Task.FromResult((minimumSprayRate - requiredAgentVolume) * requiredHectare);
        }
    }
}
