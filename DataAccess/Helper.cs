using System.Configuration;

namespace DataAccess
{
    public class Helper
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            }
        }
    }
}
