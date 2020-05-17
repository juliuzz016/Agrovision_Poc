using Orleans;
using System.Threading.Tasks;

namespace FieldsMaintanceGrain
{
    public class BaseGrain : Grain, IGrain
    {
        public async Task<bool> IsAlive()
        {
            return await Task.FromResult(true);
        }
    }
}
