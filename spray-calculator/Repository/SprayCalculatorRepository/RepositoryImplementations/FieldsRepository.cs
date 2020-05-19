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
    public sealed class FieldsRepository : RepositoryBase<Fields>
    {
        public static Guid HardcodedUserKey = Guid.Parse("42A6FEB2-69AF-44AE-823B-5A260E4FF050");
        private readonly SprayCalculatorContext _sprayCalculatorContext;
        public FieldsRepository(SprayCalculatorContext sprayCalculatorContext)
        {
            _sprayCalculatorContext = sprayCalculatorContext;
        }
        public override async Task<(long RecordsAffected, Fields Entity)> Create(Fields entity)
        {
            entity.FieldKey = Guid.NewGuid();
            entity.UserKey = HardcodedUserKey;
            entity.IsActive = true;
            await _sprayCalculatorContext.Fields.AddAsync(entity);
            return (await _sprayCalculatorContext.SaveChangesAsync(), entity);
        }

        public override async Task<long> Delete(Fields entity)
        {
            entity.IsActive = false;
            _sprayCalculatorContext.Update(entity);
            return await _sprayCalculatorContext.SaveChangesAsync();
        }

        public override async Task<long> Delete(Guid Key)
        {
            var entity = await _sprayCalculatorContext.Fields.FirstAsync(z => z.FieldKey == Key);
            entity.IsActive = false;
            _sprayCalculatorContext.Update(entity);
            return await _sprayCalculatorContext.SaveChangesAsync();
        }

        public override async Task<IEnumerable<Fields>> Lookup(Expression<Func<Fields, bool>> queryData, int skip, int take)
        {
            return await Task.FromResult(_sprayCalculatorContext.Fields.Where(queryData)
                .Skip(skip)
                .Take(take));
        }

        public override async Task<IEnumerable<Fields>> Lookup(Expression<Func<Fields, bool>> queryData)
        {
            return await Task.FromResult(_sprayCalculatorContext.Fields.Where(queryData));              
        }

        public override async Task<long> Update(Fields entity)
        {
            _sprayCalculatorContext.Update(entity);
            return await _sprayCalculatorContext.SaveChangesAsync();
        }
    }
}
