using Microsoft.EntityFrameworkCore;
using SGBenefic.API.Data.Interfaces;
using SGBenefic.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SGBenefic.API.Data
{
    public class BeneficitRepository : IBeneficitRepository
    {
        private readonly DataContext _context;
        public BeneficitRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }       

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
        public List<Beneficit> GetAllBeneficit()
        {
            IQueryable<Beneficit> query = _context.Beneficities;

            query = query.AsNoTracking();

            query.OrderBy(a => a.Beneficio);

            return query.ToList();
        }
        public Beneficit GetBeneficitById(int id)
        {
            IQueryable<Beneficit> query = _context.Beneficities;

            query = query.AsNoTracking()
                         .OrderBy(a => a.Beneficio)
                         .Where(a => a.Id == id);

            return query.FirstOrDefault();
        }
    }
}
