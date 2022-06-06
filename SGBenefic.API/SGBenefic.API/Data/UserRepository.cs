using Microsoft.EntityFrameworkCore;
using SGBenefic.API.Data.Interfaces;
using SGBenefic.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SGBenefic.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
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
        public List<User> GetAllUser()
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking();

            query.OrderBy(a => a.Name);

            return query.ToList();
        }
        public User GetUserById(int id)
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking()
                         .OrderBy(a => a.Name)
                         .Where(a => a.Id == id);

            return query.FirstOrDefault();
        }
        public User GetUserPerEmail(string email)
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking()
                         .OrderBy(a => a.Name)
                         .Where(a => a.Email.ToLower().Trim() == email.ToLower().Trim());

            return query.FirstOrDefault();
        }

    }
}
