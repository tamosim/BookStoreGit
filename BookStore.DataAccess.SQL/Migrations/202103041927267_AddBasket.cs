namespace BookStore.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        CreationTime = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        CartID = c.String(maxLength: 128),
                        ProductID = c.String(),
                        Quantity = c.String(),
                        CreationTime = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Carts", t => t.CartID)
                .Index(t => t.CartID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "CartID", "dbo.Carts");
            DropIndex("dbo.CartItems", new[] { "CartID" });
            DropTable("dbo.CartItems");
            DropTable("dbo.Carts");
        }
    }
}
