using System.Collections.Generic;

namespace GTLCore
{
    public interface ILoanRepository
    {
        List<Loan> GetAll();
        int Insert(Loan loan);
        bool Update(Loan loan);
        bool Delete(int id);
    }
}
