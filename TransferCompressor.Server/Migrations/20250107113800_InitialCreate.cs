using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransferCompressor.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fileNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompressedFilePad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalFilePad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalFileSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompressedFileSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uploadDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeelbaarLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmbedVideos",
                columns: table => new
                {
                    embedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmbedUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmbedCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmbedVideos", x => x.embedId);
                    table.ForeignKey(
                        name: "FK_EmbedVideos_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmbedVideos_VideoId",
                table: "EmbedVideos",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_userId",
                table: "Videos",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmbedVideos");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
