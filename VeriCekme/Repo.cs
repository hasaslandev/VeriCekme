using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VeriCekme
{
    public class Repo
    {
        DatabaseRel _context;

        public Repo()
        {
            _context = new DatabaseRel();
        }

        public void AddEntity<T>(T entity) where T : class
        {
            var dbSet = _context.Set<T>();
            dbSet.Add(entity);
            _context.SaveChanges();
        }
        public List<AirCrash> GetAll(Expression<Func<AirCrash, bool>>? filter)
        {
                return filter == null
                    ? _context.Set<AirCrash>().ToList()
                    : _context.Set<AirCrash>().Where(filter).ToList();
            
        }
        public void UpdateAsync(AirCrash p)
        {
                var modifiedEntity = _context.Entry(p);
                modifiedEntity.State = EntityState.Modified;
                 _context.SaveChangesAsync(); 
        }
        public void Delete(AirCrash p)
        {
            var modifiedEntity = _context.Entry(p);
            modifiedEntity.State = EntityState.Deleted;
            _context.SaveChangesAsync();
        }

    }
}
