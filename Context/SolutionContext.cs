using Context.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Security;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using WcWebUi.Infra.Model;

namespace Context
{
    public class SolutionContext : IdentityDbContext<ApplicationUser>
    {
        public SolutionContext() : base("WorkingCode", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Group> Groups { get; set; }

        public static SolutionContext Create()
        {
            return new SolutionContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == "Id" + p.ReflectedType.Name).Configure(p => p.IsKey());
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(config => config.HasMaxLength(150));

            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(18, 2));

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    sb.AppendLine(string.Format("Tipo \"{0}\" estado \"{1}\" possui erros de validação da entidade:",
                                                    eve.Entry.Entity.GetType().Name,
                                                    eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        sb.AppendLine(string.Format("- Propriedade: \"{0}\", Erro: \"{1}\"",
                                                    ve.PropertyName,
                                                    ve.ErrorMessage));
                    }
                }
                throw new DbEntityValidationException(sb.ToString(), e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }       
    }
}
