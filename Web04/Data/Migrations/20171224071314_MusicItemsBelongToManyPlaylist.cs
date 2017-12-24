using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Web04.Data.Migrations
{
    public partial class MusicItemsBelongToManyPlaylist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicItem_Playlists_PlaylistId",
                table: "MusicItem");

            migrationBuilder.DropIndex(
                name: "IX_MusicItem_PlaylistId",
                table: "MusicItem");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "MusicItem");

            migrationBuilder.CreateTable(
                name: "PlaylistMusicItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MusicItemId = table.Column<int>(nullable: true),
                    PlaylistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistMusicItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistMusicItem_MusicItem_MusicItemId",
                        column: x => x.MusicItemId,
                        principalTable: "MusicItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaylistMusicItem_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistMusicItem_MusicItemId",
                table: "PlaylistMusicItem",
                column: "MusicItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistMusicItem_PlaylistId",
                table: "PlaylistMusicItem",
                column: "PlaylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistMusicItem");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistId",
                table: "MusicItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicItem_PlaylistId",
                table: "MusicItem",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicItem_Playlists_PlaylistId",
                table: "MusicItem",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
