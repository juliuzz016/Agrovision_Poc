using Agrovision.Spray_Calculator.Data;
using Agrovision.Spray_Calculator.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SprayCalculatorRepository.RepositoryImplementations
{
    public class SprayingAgentsRepository : RepositoryBase<SprayingAgents>
    {
        private readonly SprayCalculatorContext _sprayCalculatorContext;
        public SprayingAgentsRepository(SprayCalculatorContext sprayCalculatorContext)
        {
            _sprayCalculatorContext = sprayCalculatorContext;
        }
        public override async Task<(long RecordsAffected, SprayingAgents Entity)> Create(SprayingAgents entity)
        {
            entity.AgentKey = Guid.NewGuid();
            entity.IsActive = true;
            await _sprayCalculatorContext.SprayingAgents.AddAsync(entity);
            return (await _sprayCalculatorContext.SaveChangesAsync(), entity);
        }

        public override async Task<long> Delete(SprayingAgents entity)
        {
            entity.IsActive = false;
            _sprayCalculatorContext.Update(entity);
            return await _sprayCalculatorContext.SaveChangesAsync();
        }

        public override async Task<long> Delete(Guid Key)
        {
            var entity = await _sprayCalculatorContext.SprayingAgents.FirstAsync(z => z.AgentKey == Key);
            entity.IsActive = false;
            _sprayCalculatorContext.Update(entity);
            return await _sprayCalculatorContext.SaveChangesAsync();
        }

        public override async Task<IEnumerable<SprayingAgents>> Lookup(Expression<Func<SprayingAgents, bool>> queryData, int skip, int take)
        {
            return await Task.FromResult(_sprayCalculatorContext.SprayingAgents.Where(queryData)
          .Skip(skip)
          .Take(take));
        }

        public override async Task<IEnumerable<SprayingAgents>> Lookup(Expression<Func<SprayingAgents, bool>> queryData)
        {
            return await Task.FromResult(_sprayCalculatorContext.SprayingAgents.Where(queryData));
        }

        public override async Task<long> Update(SprayingAgents entity)
        {
            _sprayCalculatorContext.Update(entity);
            return await _sprayCalculatorContext.SaveChangesAsync();
        }
    }
}
