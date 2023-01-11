using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfAppDemoCPCBhathi.Repos
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase() 
        {
            //how to implement to deploy whith the dtabase???
            _connectionString = "@Data Source=BHATHIYABANDARA;Initial Catalog=CPC;Integrated Security=True";
            //@"Data Source=BHATHIYABANDARA;Initial Catalog=CPC;Integrated Security=True"
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
