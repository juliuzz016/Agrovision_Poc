using Orleans;
using System.Threading.Tasks;

namespace ISpray_Calculator.Interfaces
{
    public interface IDosage_CalculatorGrain : IGrainWithGuidKey
    {
        Task<(double agent, double water )> CalculateDosage(double agentReq, double fieldSize, double waterRate);
    }
}
