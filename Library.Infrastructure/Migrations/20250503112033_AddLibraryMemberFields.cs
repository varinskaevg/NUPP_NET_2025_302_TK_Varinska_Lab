using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLibraryMemberFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "LibraryMembers");

            migrationBuilder.RenameColumn(
                name: "JoinDate",
                table: "LibraryMembers",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LibraryMembers",
                newName: "JoinDate");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "LibraryMembers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
