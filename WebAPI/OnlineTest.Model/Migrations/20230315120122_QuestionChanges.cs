using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTest.Model.Migrations
{
    /// <inheritdoc />
    public partial class QuestionChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technology_Users_ModifiedBy",
                table: "Technology");

            migrationBuilder.DropColumn(
                name: "Que",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionName",
                table: "Questions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireOn",
                table: "Tests",
                type: "DateTime",   
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Tests",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Technology",
                type: "DateTime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Technology",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Technology",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
               name: "Question",
               table: "Questions",
               type: "nvarchar(300)",
               maxLength: 300,
               nullable: false,
               defaultValue: "");

            migrationBuilder.AddColumn<int>(
              name: "SortOrder",
              table: "Questions",
              type: "int",
              nullable: false,
              defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
              name: "IsActive",
              table: "Questions",
              type: "bit",
              nullable: false,
              defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Questions",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedBy",
                table: "Questions",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_CreatedBy",
                table: "Questions",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technology_Users_ModifiedBy",
                table: "Technology",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_CreatedBy",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Technology_Users_ModifiedBy",
                table: "Technology");   

            migrationBuilder.DropIndex(
                name: "IX_Questions_CreatedBy",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Questions");

            migrationBuilder.DropColumn(
               name: "IsActive",
               table: "Questions");

            migrationBuilder.DropColumn(
               name: "CreatedBy",
               table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Questions");


            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireOn",
                table: "Tests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Tests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Technology",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "DataTime",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Technology",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Technology",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<string>(
                name: "Que",
                table: "Questions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuestionName",
                table: "Questions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Technology_Users_ModifiedBy",
                table: "Technology",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
