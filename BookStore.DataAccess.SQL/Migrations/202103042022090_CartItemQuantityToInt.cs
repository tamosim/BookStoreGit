namespace BookStore.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartItemQuantityToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CartItems", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CartItems", "Quantity", c => c.String());
        }
    }
}
