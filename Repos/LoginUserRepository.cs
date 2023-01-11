using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfAppDemoCPCBhathi.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WpfAppDemoCPCBhathi.Repos

    //must be implemented
{
    public class LoginUserRepository : RepositoryBase, IUserLoginRepo
    {
        public bool AuthUser(NetworkCredential credential)
        {
            bool validUser;
            using(var connection= GetConnection())
             using(var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "selecct * from [Login] where userID=@userID and [userPW] = userPW";
                command.Parameters.Add("@userID", SqlDbType.VarChar).Value = credential.UserName;
                command.Parameters.Add("@userPW", SqlDbType.VarChar).Value = credential.Password;
                validUser= command.ExecuteScalar() == null? false:true;
            }


            



            return validUser;
        }
    }
}
