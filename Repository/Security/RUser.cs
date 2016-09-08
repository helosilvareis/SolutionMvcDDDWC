using Context;
using Model.Security;
using Repository.General;

namespace Repository.Security
{
    public class RUser : RDefault<User>
    {
        public RUser(SolutionContext context) : base(context)
        {

        }
    }
}
