using Dapper;
using GTLCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class MaterialRepository : IMaterialRepository
    {
        public bool Delete(int MaterialId)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("DELETE FROM material WHERE id = @id", new { id = MaterialId }, commandType: CommandType.Text);
                return result != 0;
            }
        }

        public List<Material> GetAll()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<Material>("SELECT * FROM material", commandType: CommandType.Text).ToList();
            }
        }

        public Material GetById(int id)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.QueryFirst<Material>("SELECT id FROM dbo.material WHERE id = id", new { id = id }, commandType: CommandType.Text);

            }
        }

        public int Insert(Material material)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                DynamicParameters p = new DynamicParameters();
                p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new { isbn = material.isbn, language = material.language, title = material.title, subject_area = material.subject_area, description = material.description, no_of_copies = material.no_of_copies, total_loans = material.total_loans, loanable_acquire = material.loanable_acquire });
                db.Execute("sp_material_insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@id");
            }
        }

        public bool Update(Material material)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                int result = db.Execute("sp_material_update", new { id = material.id, isbn = material.isbn, language = material.language, title = material.title, subject_area = material.subject_area, description = material.description, no_of_copies = material.no_of_copies, total_loans = material.total_loans, loanable_acquire = material.loanable_acquire }, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
