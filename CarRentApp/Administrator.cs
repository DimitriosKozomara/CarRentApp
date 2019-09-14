using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvpProj
{
    public class Administrator : User
    {
        public Administrator(string username, string password) : base(username, password) { }
    }
}
