using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.Arch.Data.Migrations
{
    /// <inheritdoc />
    public partial class rename_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IndividualEntities",
                table: "IndividualEntities");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "IndividualEntities");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "IndividualEntities");

            migrationBuilder.RenameTable(
                name: "IndividualEntities",
                newName: "INDIVIDUAL_ENTITIES");

            migrationBuilder.AddPrimaryKey(
                name: "PK_INDIVIDUAL_ENTITIES",
                table: "INDIVIDUAL_ENTITIES",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_INDIVIDUAL_ENTITIES",
                table: "INDIVIDUAL_ENTITIES");

            migrationBuilder.RenameTable(
                name: "INDIVIDUAL_ENTITIES",
                newName: "IndividualEntities");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "IndividualEntities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "IndividualEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndividualEntities",
                table: "IndividualEntities",
                column: "Id");
        }
    }
}
