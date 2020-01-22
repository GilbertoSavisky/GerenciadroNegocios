namespace GerenciadorNegocios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CPFCNPJ = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Negocios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Etapas = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Negocios", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Negocios", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Negocios", new[] { "ProdutoId" });
            DropIndex("dbo.Negocios", new[] { "ClienteId" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.Negocios");
            DropTable("dbo.Clientes");
        }
    }
}
