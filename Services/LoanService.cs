using Autofac;
using DataAccess;
using GTLCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoanService
    {
        static IContainer _container;
        static LoanService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<LoanRepository>().As<ILoanRepository>();
            _container = builder.Build();
        }
        public static bool Delete(int LoanId)
        {
            return _container.Resolve<ILoanRepository>().Delete(LoanId);
        }
        public static List<Loan> GetAll()
        {
            return _container.Resolve<ILoanRepository>().GetAll();
        }
        public static Loan Save(Loan loan, EntityState state)
        {
            if (state == EntityState.Added)
                loan.id = _container.Resolve<ILoanRepository>().Insert(loan);
            else
                _container.Resolve<ILoanRepository>().Update(loan);
            return loan;
        }
    }
}
