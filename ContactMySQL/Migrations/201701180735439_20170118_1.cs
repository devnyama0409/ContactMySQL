namespace ContactMySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170118_1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("ToiawaseRirekis");
            AlterColumn("ToiawaseRirekis", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("ToiawaseRirekis", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("ToiawaseRirekis");
            AlterColumn("ToiawaseRirekis", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("ToiawaseRirekis", "Id");
        }
    }
}
