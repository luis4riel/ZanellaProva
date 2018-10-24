using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using Zanella.ORM.Domain.Funcionalidades.Cargos;
using Zanella.ORM.Domain.Funcionalidades.Departamentos;
using Zanella.ORM.Domain.Funcionalidades.Dependentes;
using Zanella.ORM.Domain.Funcionalidades.Funcionarios;
using Zanella.ORM.Domain.Funcionalidades.Projetos;

namespace Zanella.ORM.Infra.Data.Contexto
{
    public class ORMContexto : DbContext
    {
        public ORMContexto() : base("MF_ORM_Zanella")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
                        
        public DbSet<Cargo> Cargos { get; set; }

        public DbSet<Departamento> Departamentos  { get; set; }

        public DbSet<Dependente> Dependentes{ get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Projeto> Projetos { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(250));

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try { return base.SaveChanges(); }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                }
                throw;
            }
        }

    }
}
