using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Web04.Data.Migrations {
  public partial class Playlist2 : Migration {
    protected override void Up(MigrationBuilder migrationBuilder) {
      migrationBuilder.DropForeignKey(
          name: "FK_Songs_Albums_AlbumId",
          table: "Songs");

      migrationBuilder.Sql("SELECT * INTO AlbumsBackup FROM Albums");
      migrationBuilder.Sql("SELECT * INTO SongsBackup  FROM Songs ");
      migrationBuilder.Sql("DELETE Songs");


      migrationBuilder.DropTable(
          name: "Albums");

      migrationBuilder.DropPrimaryKey(
          name: "PK_Songs",
          table: "Songs");

      migrationBuilder.RenameTable(
          name: "Songs",
          newName: "MusicItem");

      migrationBuilder.RenameIndex(
          name: "IX_Songs_AlbumId",
          table: "MusicItem",
          newName: "IX_MusicItem_AlbumId");

      migrationBuilder.AlterColumn<TimeSpan>(
          name: "Length",
          table: "MusicItem",
          nullable: true,
          oldClrType: typeof(TimeSpan));

      migrationBuilder.AddColumn<string>(
          name: "Artist",
          table: "MusicItem",
          nullable: true);

      migrationBuilder.AddColumn<string>(
          name: "CoverImageUrl",
          table: "MusicItem",
          nullable: true);

      migrationBuilder.AddColumn<string>(
          name: "Discriminator",
          table: "MusicItem",
          nullable: false,
          defaultValue: "");

      migrationBuilder.AddColumn<int>(
          name: "PlaylistId",
          table: "MusicItem",
          nullable: true);

      migrationBuilder.AddPrimaryKey(
          name: "PK_MusicItem",
          table: "MusicItem",
          column: "Id");

      migrationBuilder.CreateTable(
          name: "Playlists",
          columns: table => new {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(nullable: true),
            OwnerId = table.Column<string>(nullable: true)
          },
          constraints: table => {
            table.PrimaryKey("PK_Playlists", x => x.Id);
            table.ForeignKey(
                      name: "FK_Playlists_AspNetUsers_OwnerId",
                      column: x => x.OwnerId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateIndex(
          name: "IX_MusicItem_PlaylistId",
          table: "MusicItem",
          column: "PlaylistId");

      migrationBuilder.CreateIndex(
          name: "IX_Playlists_OwnerId",
          table: "Playlists",
          column: "OwnerId");

      migrationBuilder.AddForeignKey(
          name: "FK_MusicItem_Playlists_PlaylistId",
          table: "MusicItem",
          column: "PlaylistId",
          principalTable: "Playlists",
          principalColumn: "Id",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_MusicItem_MusicItem_AlbumId",
          table: "MusicItem",
          column: "AlbumId",
          principalTable: "MusicItem",
          principalColumn: "Id",
          onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder) {
      migrationBuilder.DropForeignKey(
          name: "FK_MusicItem_Playlists_PlaylistId",
          table: "MusicItem");

      migrationBuilder.DropForeignKey(
          name: "FK_MusicItem_MusicItem_AlbumId",
          table: "MusicItem");

      migrationBuilder.DropTable(
          name: "Playlists");

      migrationBuilder.DropPrimaryKey(
          name: "PK_MusicItem",
          table: "MusicItem");

      migrationBuilder.DropIndex(
          name: "IX_MusicItem_PlaylistId",
          table: "MusicItem");

      migrationBuilder.DropColumn(
          name: "Artist",
          table: "MusicItem");

      migrationBuilder.DropColumn(
          name: "CoverImageUrl",
          table: "MusicItem");

      migrationBuilder.DropColumn(
          name: "Discriminator",
          table: "MusicItem");

      migrationBuilder.DropColumn(
          name: "PlaylistId",
          table: "MusicItem");

      migrationBuilder.RenameTable(
          name: "MusicItem",
          newName: "Songs");

      migrationBuilder.RenameIndex(
          name: "IX_MusicItem_AlbumId",
          table: "Songs",
          newName: "IX_Songs_AlbumId");

      migrationBuilder.AlterColumn<TimeSpan>(
          name: "Length",
          table: "Songs",
          nullable: false,
          oldClrType: typeof(TimeSpan),
          oldNullable: true);

      migrationBuilder.AddPrimaryKey(
          name: "PK_Songs",
          table: "Songs",
          column: "Id");

      migrationBuilder.CreateTable(
          name: "Albums",
          columns: table => new {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Artist = table.Column<string>(nullable: true),
            CoverImageUrl = table.Column<string>(nullable: true),
            Title = table.Column<string>(maxLength: 50, nullable: false)
          },
          constraints: table => {
            table.PrimaryKey("PK_Albums", x => x.Id);
          });

      migrationBuilder.AddForeignKey(
          name: "FK_Songs_Albums_AlbumId",
          table: "Songs",
          column: "AlbumId",
          principalTable: "Albums",
          principalColumn: "Id",
          onDelete: ReferentialAction.Restrict);
    }
  }
}
