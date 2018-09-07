using MD.Identity;

namespace MD.Migrations.Context
{
    public class IdentityContext : AppIdentityDbContext
    {
        public IdentityContext() 
            : base("identity")
        {
        }
    }
}