using Dapper;
using GTLCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class PersonRepository : IPersonRepository
    {
        public bool Delete(int PersonId)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("DELETE FROM person WHERE id = @id", new { id = PersonId }, commandType: CommandType.Text);
                return result != 0;
            }
        }

        public List<Person> GetAll()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<Person>("SELECT * FROM person", commandType: CommandType.Text).ToList();
            }
        }

        public int Insert(Person person)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                DynamicParameters p = new DynamicParameters();
                p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new { first_name = person.first_name, middle_name = person.middle_name, last_name = person.last_name });
                db.Execute("sp_person_insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@id");
            }
        }

        public bool Update(Person person)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("sp_person_update", new { id = person.id, first_name = person.first_name, middle_name = person.middle_name, last_name = person.last_name }, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
