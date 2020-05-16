using Orleans;
using System.Threading.Tasks;

namespace ISpray_Calculator.Interfaces
{
    public interface IDosage_CalculatorGrain : IGrainWithGuidKey
    {
        Task<(double water, double agent)> CalculateDosage(double agentReq, double fieldSize, double waterRate);
    }
}
