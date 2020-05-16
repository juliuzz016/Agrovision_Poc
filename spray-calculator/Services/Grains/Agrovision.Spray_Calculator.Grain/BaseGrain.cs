using ISpray_Calculator.Interfaces;
using Orleans;
using System.Threading.Tasks;

namespace Spray_Calculator
{
    public class BaseGrain : Grain, IGrain, IBaseGrain
    {
        public async Task<bool> IsAlive()
        {
            return await Task.FromResult(true);
        }
    }
}
