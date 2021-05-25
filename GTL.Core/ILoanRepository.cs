using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
