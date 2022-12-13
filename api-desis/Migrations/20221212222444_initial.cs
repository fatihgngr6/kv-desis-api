using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace apidesis.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "desisEntry",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desisEntry", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "desisUser",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    university = table.Column<string>(type: "text", nullable: false),
                    studentNumber = table.Column<int>(type: "integer", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desisUser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "desisComment",
                columns: table => new
                {
                    commentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comment = table.Column<string>(type: "text", nullable: false),
                    dateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DesisEntryid = table.Column<int>(type: "integer", nullable: true),
                    DesisUserid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desisComment", x => x.commentId);
                    table.ForeignKey(
                        name: "FK_desisComment_desisEntry_DesisEntryid",
                        column: x => x.DesisEntryid,
                        principalTable: "desisEntry",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_desisComment_desisUser_DesisUserid",
                        column: x => x.DesisUserid,
                        principalTable: "desisUser",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "desisRating",
                columns: table => new
                {
                    rateId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    DesisEntryid = table.Column<int>(type: "integer", nullable: true),
                    DesisUserid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desisRating", x => x.rateId);
                    table.ForeignKey(
                        name: "FK_desisRating_desisEntry_DesisEntryid",
                        column: x => x.DesisEntryid,
                        principalTable: "desisEntry",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_desisRating_desisUser_DesisUserid",
                        column: x => x.DesisUserid,
                        principalTable: "desisUser",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_desisComment_DesisEntryid",
                table: "desisComment",
                column: "DesisEntryid");

            migrationBuilder.CreateIndex(
                name: "IX_desisComment_DesisUserid",
                table: "desisComment",
                column: "DesisUserid");

            migrationBuilder.CreateIndex(
                name: "IX_desisRating_DesisEntryid",
                table: "desisRating",
                column: "DesisEntryid");

            migrationBuilder.CreateIndex(
                name: "IX_desisRating_DesisUserid",
                table: "desisRating",
                column: "DesisUserid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "desisComment");

            migrationBuilder.DropTable(
                name: "desisRating");

            migrationBuilder.DropTable(
                name: "desisEntry");

            migrationBuilder.DropTable(
                name: "desisUser");
        }
    }
}
