namespace WcfServiceHumanCycle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.Humen",
                c => new
                    {
                        HumanId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Gender_GenderId = c.Int(),
                        Slice_SliceId = c.Int(),
                        Statut_StatutId = c.Int(),
                        Town_TownId = c.Int(),
                    })
                .PrimaryKey(t => t.HumanId)
                .ForeignKey("dbo.Genders", t => t.Gender_GenderId)
                .ForeignKey("dbo.Slice", t => t.Slice_SliceId)
                .ForeignKey("dbo.Statuts", t => t.Statut_StatutId)
                .ForeignKey("dbo.Towns", t => t.Town_TownId)
                .Index(t => t.Gender_GenderId)
                .Index(t => t.Slice_SliceId)
                .Index(t => t.Statut_StatutId)
                .Index(t => t.Town_TownId);
            
            CreateTable(
                "dbo.Slice",
                c => new
                    {
                        SliceId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SliceId);
            
            CreateTable(
                "dbo.Statuts",
                c => new
                    {
                        StatutId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StatutId);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        TownId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TownId);
            
            CreateTable(
                "dbo.HumanHumen",
                c => new
                    {
                        Human_HumanId = c.Int(nullable: false),
                        Human_HumanId1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Human_HumanId, t.Human_HumanId1 })
                .ForeignKey("dbo.Humen", t => t.Human_HumanId)
                .ForeignKey("dbo.Humen", t => t.Human_HumanId1)
                .Index(t => t.Human_HumanId)
                .Index(t => t.Human_HumanId1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Humen", "Town_TownId", "dbo.Towns");
            DropForeignKey("dbo.Humen", "Statut_StatutId", "dbo.Statuts");
            DropForeignKey("dbo.Humen", "Slice_SliceId", "dbo.Slice");
            DropForeignKey("dbo.Humen", "Gender_GenderId", "dbo.Genders");
            DropForeignKey("dbo.HumanHumen", "Human_HumanId1", "dbo.Humen");
            DropForeignKey("dbo.HumanHumen", "Human_HumanId", "dbo.Humen");
            DropIndex("dbo.HumanHumen", new[] { "Human_HumanId1" });
            DropIndex("dbo.HumanHumen", new[] { "Human_HumanId" });
            DropIndex("dbo.Humen", new[] { "Town_TownId" });
            DropIndex("dbo.Humen", new[] { "Statut_StatutId" });
            DropIndex("dbo.Humen", new[] { "Slice_SliceId" });
            DropIndex("dbo.Humen", new[] { "Gender_GenderId" });
            DropTable("dbo.HumanHumen");
            DropTable("dbo.Towns");
            DropTable("dbo.Statuts");
            DropTable("dbo.Slice");
            DropTable("dbo.Humen");
            DropTable("dbo.Genders");
        }
    }
}
