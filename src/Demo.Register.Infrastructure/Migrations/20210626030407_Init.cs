using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace Demo.Register.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminsetting",
                columns: table => new
                {
                    idadminsetting = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    logo = table.Column<byte[]>(type: "bytea", nullable: true),
                    primarycolor = table.Column<string>(type: "text", nullable: true),
                    secondarycolor = table.Column<string>(type: "text", nullable: true),
                    idcurrency = table.Column<int>(type: "integer", nullable: true),
                    acronymcurrency = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adminsetting", x => x.idadminsetting);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    cityid = table.Column<Guid>(type: "uuid", nullable: false),
                    namecity = table.Column<string>(type: "varchar(100)", nullable: false),
                    ibgecodecity = table.Column<string>(type: "varchar(14)", nullable: true),
                    intrracodecity = table.Column<string>(type: "varchar(50)", nullable: true),
                    activecity = table.Column<bool>(type: "bool", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city", x => x.cityid);
                });

            migrationBuilder.CreateTable(
                name: "terminal",
                columns: table => new
                {
                    terminalid = table.Column<Guid>(type: "uuid", nullable: false),
                    nameterminal = table.Column<string>(type: "varchar(100)", nullable: false),
                    status = table.Column<string>(type: "varchar(1)", nullable: false),
                    address = table.Column<string>(type: "varchar(100)", nullable: true),
                    district = table.Column<string>(type: "varchar(50)", nullable: true),
                    cnpj = table.Column<string>(type: "varchar(14)", nullable: true),
                    nif = table.Column<string>(type: "varchar(50)", nullable: true),
                    stateregistry = table.Column<string>(type: "varchar(50)", nullable: true),
                    specificinstruction = table.Column<string>(type: "varchar(100)", nullable: false),
                    generalobservation = table.Column<string>(type: "varchar(100)", nullable: false),
                    cityid = table.Column<Guid>(type: "uuid", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_terminal", x => x.terminalid);
                    table.ForeignKey(
                        name: "fk_terminal_city_cityid",
                        column: x => x.cityid,
                        principalTable: "city",
                        principalColumn: "cityid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_terminal_cityid",
                table: "terminal",
                column: "cityid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminsetting");

            migrationBuilder.DropTable(
                name: "terminal");

            migrationBuilder.DropTable(
                name: "city");
        }
    }
}
