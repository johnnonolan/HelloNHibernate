using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACME.Repository
{
    public interface IRepository<TD, TK> where TD : class
    {
        TD GetById(TK id);
        void Save(TD saveObj);
        void Delete(TD delObj);
    }
}
