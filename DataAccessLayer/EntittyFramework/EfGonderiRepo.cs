using DataAccessLayer.Interface;
using DataAccessLayer.Repostory;
using EFLayer.Class;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntittyFramework
{
    public class EfGonderiRepo : DataGonderiRepostory, IGonderiData<Gonderiler>
    {
        public Gonderiler getWithLastPost(int id)
        {
            throw new NotImplementedException();
        }
    }
}
