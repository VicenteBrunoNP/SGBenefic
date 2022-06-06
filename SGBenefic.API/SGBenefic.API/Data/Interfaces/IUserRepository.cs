using System.Collections.Generic;

namespace SGBenefic.API.Data.Interfaces
{
    public interface IUserRepository : IRepository
    {
        List<Models.User> GetAllUser();
        Models.User GetUserById(int id);
        Models.User GetUserPerEmail(string email);
    }

}
