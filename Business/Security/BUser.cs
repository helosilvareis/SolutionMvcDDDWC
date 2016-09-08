using Business.General;
using Context;
using Model.Security;
using Repository.General;
using Repository.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security
{
    public class BUser : BDefault<User>, IBUser
    {
        public BUser(SolutionContext context)
            : base(new RUser(context))
        {

        }

    }

    public interface IBUser : IRDefault<User>
    {

    }
}
