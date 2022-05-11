using SGBenefic.API.Models;

namespace SGBenefic.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T:class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Benefícios
        Beneficit[] GetAllBeneficit();
        Beneficit GetAllBeneficitById(int id);
    }
}
