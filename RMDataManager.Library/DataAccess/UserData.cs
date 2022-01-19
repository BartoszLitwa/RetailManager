using RMDataManager.Library.Internal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class UserData
    {
        public async Task<List<UserModel>> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id };

            var output =  await sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "RMData");

            return output;
        }
    }
}
