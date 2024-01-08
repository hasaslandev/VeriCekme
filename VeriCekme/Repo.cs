using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
