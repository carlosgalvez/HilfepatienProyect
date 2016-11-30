namespace HilfepatienAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuarios", "Medico_Id1", "dbo.Medico");
            DropIndex("dbo.Usuarios", new[] { "Medico_Id1" });
            DropIndex("dbo.Usuarios", new[] { "Paciente_Id1" });
            DropColumn("dbo.Usuarios", "Paciente_Id");
            RenameColumn(table: "dbo.Usuarios", name: "Paciente_Id1", newName: "Paciente_Id");
            AddColumn("dbo.Usuarios", "Usuario", c => c.String());
            AlterColumn("dbo.Usuarios", "Paciente_Id", c => c.Int());
            CreateIndex("dbo.Usuarios", "Paciente_Id");
            DropColumn("dbo.Usuarios", "Medico_Id");
            DropColumn("dbo.Usuarios", "Medico_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Medico_Id1", c => c.Int());
            AddColumn("dbo.Usuarios", "Medico_Id", c => c.Int(nullable: false));
            DropIndex("dbo.Usuarios", new[] { "Paciente_Id" });
            AlterColumn("dbo.Usuarios", "Paciente_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Usuarios", "Usuario");
            RenameColumn(table: "dbo.Usuarios", name: "Paciente_Id", newName: "Paciente_Id1");
            AddColumn("dbo.Usuarios", "Paciente_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuarios", "Paciente_Id1");
            CreateIndex("dbo.Usuarios", "Medico_Id1");
            AddForeignKey("dbo.Usuarios", "Medico_Id1", "dbo.Medico", "Id");
        }
    }
}
