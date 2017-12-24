using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Web04.Data.Migrations
{
    public partial class MusicItemsToDbCOntext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicItem_MusicItem_AlbumId",
                table: "MusicItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistMusicItem_MusicItem_MusicItemId",
                table: "PlaylistMusicItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicItem",
                table: "MusicItem");

            migrationBuilder.RenameTable(
                name: "MusicItem",
                newName: "MusicItems");

            migrationBuilder.RenameIndex(
                name: "IX_MusicItem_AlbumId",
                table: "MusicItems",
                newName: "IX_MusicItems_AlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicItems",
                table: "MusicItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicItems_MusicItems_AlbumId",
                table: "MusicItems",
                column: "AlbumId",
                principalTable: "MusicItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistMusicItem_MusicItems_MusicItemId",
                table: "PlaylistMusicItem",
                column: "MusicItemId",
                principalTable: "MusicItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicItems_MusicItems_AlbumId",
                table: "MusicItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistMusicItem_MusicItems_MusicItemId",
                table: "PlaylistMusicItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicItems",
                table: "MusicItems");

            migrationBuilder.RenameTable(
                name: "MusicItems",
                newName: "MusicItem");

            migrationBuilder.RenameIndex(
                name: "IX_MusicItems_AlbumId",
                table: "MusicItem",
                newName: "IX_MusicItem_AlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicItem",
                table: "MusicItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicItem_MusicItem_AlbumId",
                table: "MusicItem",
                column: "AlbumId",
                principalTable: "MusicItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistMusicItem_MusicItem_MusicItemId",
                table: "PlaylistMusicItem",
                column: "MusicItemId",
                principalTable: "MusicItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
