namespace Zanella.ORM.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cpf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBCargo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBDepartamento",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBDependente",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NomeDependente = c.String(nullable: false, maxLength: 250, unicode: false),
                        Idade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBFuncionario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Cpf = c.String(maxLength: 250, unicode: false),
                        NomeFuncionario = c.String(nullable: false, maxLength: 250, unicode: false),
                        Endereco_Logradouro = c.String(nullable: false, maxLength: 250, unicode: false),
                        Endereco_Numero = c.String(maxLength: 250, unicode: false),
                        Endereco_Bairro = c.String(nullable: false, maxLength: 250, unicode: false),
                        Endereco_Municipio = c.String(nullable: false, maxLength: 250, unicode: false),
                        Endereco_Estado = c.String(maxLength: 250, unicode: false),
                        Endereco_Complemento = c.String(maxLength: 250, unicode: false),
                        Cargo_Id = c.Long(),
                        Departamento_Id = c.Long(),
                        Dependente_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBCargo", t => t.Cargo_Id)
                .ForeignKey("dbo.TBDepartamento", t => t.Departamento_Id)
                .ForeignKey("dbo.TBDependente", t => t.Dependente_Id)
                .Index(t => t.Cargo_Id)
                .Index(t => t.Departamento_Id)
                .Index(t => t.Dependente_Id);
            
            CreateTable(
                "dbo.TBProjeto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NomeProjeto = c.String(nullable: false, maxLength: 250, unicode: false),
                        DataDeInicio = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjetoFuncionario",
                c => new
                    {
                        Projeto_Id = c.Long(nullable: false),
                        Funcionario_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Projeto_Id, t.Funcionario_Id })
                .ForeignKey("dbo.TBProjeto", t => t.Projeto_Id, cascadeDelete: true)
                .ForeignKey("dbo.TBFuncionario", t => t.Funcionario_Id, cascadeDelete: true)
                .Index(t => t.Projeto_Id)
                .Index(t => t.Funcionario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBFuncionario", "Dependente_Id", "dbo.TBDependente");
            DropForeignKey("dbo.ProjetoFuncionario", "Funcionario_Id", "dbo.TBFuncionario");
            DropForeignKey("dbo.ProjetoFuncionario", "Projeto_Id", "dbo.TBProjeto");
            DropForeignKey("dbo.TBFuncionario", "Departamento_Id", "dbo.TBDepartamento");
            DropForeignKey("dbo.TBFuncionario", "Cargo_Id", "dbo.TBCargo");
            DropIndex("dbo.ProjetoFuncionario", new[] { "Funcionario_Id" });
            DropIndex("dbo.ProjetoFuncionario", new[] { "Projeto_Id" });
            DropIndex("dbo.TBFuncionario", new[] { "Dependente_Id" });
            DropIndex("dbo.TBFuncionario", new[] { "Departamento_Id" });
            DropIndex("dbo.TBFuncionario", new[] { "Cargo_Id" });
            DropTable("dbo.ProjetoFuncionario");
            DropTable("dbo.TBProjeto");
            DropTable("dbo.TBFuncionario");
            DropTable("dbo.TBDependente");
            DropTable("dbo.TBDepartamento");
            DropTable("dbo.TBCargo");
        }
    }
}
