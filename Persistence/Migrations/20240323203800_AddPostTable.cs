using FluentMigrator;

namespace Persistence.Migrations

{
    [Migration(20240323203800)]
    public class AddPostTable : Migration
    {
        public override void Up()
        {
            Create.Table("Post")
                .WithColumn("Id").AsString().PrimaryKey()
                .WithColumn("Title").AsString()
                .WithColumn("Description").AsString();
        }

        public override void Down()
        {
            Delete.Table("Post");
        }
    }
}