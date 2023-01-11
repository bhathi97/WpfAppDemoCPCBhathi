using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

//model belongs to domain layer and repository belongs to  data access layer

namespace WpfAppDemoCPCBhathi.Model
{
    internal interface IUserLoginRepo
    {
        bool AuthUser(NetworkCredential credential);
    }
}
