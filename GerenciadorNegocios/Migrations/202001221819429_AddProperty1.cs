namespace GerenciadorNegocios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProperty1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Negocios", "Descricao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Negocios", "Descricao");
        }
    }
}
