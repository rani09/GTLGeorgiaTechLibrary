using Dapper;
using GTLCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class LoanRepository : ILoanRepository
    {

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Loan> GetAll()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<Loan>("SELECT * FROM loan", commandType: CommandType.Text).ToList();
            }
        }

        public int Insert(Loan loan)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                DynamicParameters p = new DynamicParameters();
                p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new { start_date = loan.start_date, return_date = loan.return_date, m_ssn = loan.m_ssn, member_loan_no = loan.member_loan_no });
                db.Execute("sp_loan_insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@id");
            }
        }

        public bool Update(Loan loan)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("sp_loan_update", new { id = loan.id, start_date = loan.start_date, return_date = loan.return_date, m_ssn = loan.m_ssn, member_loan_no = loan.member_loan_no }, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
