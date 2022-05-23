using System.Collections.Generic;

namespace SGBenefic.API.Data.Interfaces
{
    public interface IBeneficitRepository : IRepository
    {
        List<Models.Beneficit> GetAllBeneficit();
        Models.Beneficit GetBeneficitById(int id);
    }

}
