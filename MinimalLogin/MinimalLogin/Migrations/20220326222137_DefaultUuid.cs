using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalLogin.Migrations
{
    public partial class DefaultUuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "users",
                type: "text",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "users",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValueSql: "gen_random_uuid()");
        }
    }
}
