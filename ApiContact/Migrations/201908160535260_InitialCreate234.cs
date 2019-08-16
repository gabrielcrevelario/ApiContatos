namespace ApiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate234 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contatoes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Canal = c.String(nullable: false, maxLength: 50),
                        Valor = c.String(nullable: false, maxLength: 50),
                        Obs = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contatoes");
        }
    }
}
