using Dapper;
using GTLCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class MemberRepository : IMemberRepository
    {
        public bool Delete(int ssn)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("DELETE FROM member WHERE ssn = @ssn", new { ssn = ssn }, commandType: CommandType.Text);
                return result != 0;
            }
        }

        public List<Member> GetAll()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<Member>("SELECT * FROM member where person = person", commandType: CommandType.Text).ToList();
            }
        }

        public int Insert(Member member)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                DynamicParameters p = new DynamicParameters();
                //p.Add("@ssn", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //p.Add("@ssn", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new { ssn = member.ssn, is_professor = member.is_professor, campus_address = member.campus_address, person = member.person });
                db.Execute("sp_member_insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@ssn");
            }
        }

        public bool Update(Member member)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("sp_member_update", new { ssn = member.ssn, is_professor = member.is_professor, campus_address = member.campus_address, person = member.person }, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
