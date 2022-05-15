using Microsoft.EntityFrameworkCore;
using SGBenefic.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SGBenefic.API.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
        public List<Beneficit> GetAllBeneficit()
        {
            IQueryable<Beneficit> query = _context.Beneficities;

            query = query.AsNoTracking();

            query.OrderBy(a => a.Beneficio);

            return query.ToList();
        }
        public Beneficit GetAllBeneficitById(int id)
        {
            IQueryable<Beneficit> query = _context.Beneficities;

            query = query.AsNoTracking()
                         .OrderBy(a => a.Beneficio)
                         .Where(a => a.Id == id);

            return query.FirstOrDefault();
        }
    }
}
