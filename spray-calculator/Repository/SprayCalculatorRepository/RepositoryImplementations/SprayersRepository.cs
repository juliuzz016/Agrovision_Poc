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
    public class SprayersRepository : RepositoryBase<Sprayers>
    {
        public static Guid HardcodedUserKey = Guid.Parse("42A6FEB2-69AF-44AE-823B-5A260E4FF050");
        private readonly SprayCalculatorContext _sprayCalculatorContext;
        public SprayersRepository(SprayCalculatorContext sprayCalculatorContext)
        {
            _sprayCalculatorContext = sprayCalculatorContext;
        }
        public override async Task<(long RecordsAffected, Sprayers Entity)> Create(Sprayers entity)
        {
            entity.SprayerKey = Guid.NewGuid();
            entity.IsActive = true;
            await _sprayCalculatorContext.Sprayers.AddAsync(entity);
            return (await _sprayCalculatorContext.SaveChangesAsync(), entity);
        }

        public override async Task<long> Delete(Sprayers entity)
        {
            entity.IsActive = false;
            _sprayCalculatorContext.Update(entity);
            return await _sprayCalculatorContext.SaveChangesAsync();
        }

        public override async Task<long> Delete(Guid Key)
        {
            var entity = await _sprayCalculatorContext.Sprayers.FirstAsync(z => z.SprayerKey == Key);
            entity.IsActive = false;
            _sprayCalculatorContext.Update(entity);
            return await _sprayCalculatorContext.SaveChangesAsync();
        }

        public override async Task<IEnumerable<Sprayers>> Lookup(Expression<Func<Sprayers, bool>> queryData, int skip, int take)
        {
            return await Task.FromResult(_sprayCalculatorContext.Sprayers.Where(queryData)
              .Skip(skip)
              .Take(take));
        }

        public override async Task<IEnumerable<Sprayers>> Lookup(Expression<Func<Sprayers, bool>> queryData)
        {
            return await Task.FromResult(_sprayCalculatorContext.Sprayers.Where(queryData));
        }

        public override async Task<long> Update(Sprayers entity)
        {
            _sprayCalculatorContext.Update(entity);
            return await _sprayCalculatorContext.SaveChangesAsync();
        }
    }
}
