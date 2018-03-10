using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InternetBanking.Data.Migrations
{
    public partial class changeuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<int>(nullable: false),
                    ReceiverAccoutId = table.Column<string>(nullable: true),
                    ReceiverName = table.Column<string>(nullable: true),
                    SenderAccountId = table.Column<string>(nullable: true),
                    SenderName = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionOrder_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionOrder_UserId",
                table: "TransactionOrder",
                column: "UserId");
        }
    }
}
