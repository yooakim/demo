using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogicalDisks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Compressed = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DriveType = table.Column<int>(nullable: false),
                    FileSystem = table.Column<string>(nullable: true),
                    FreeSpace = table.Column<long>(nullable: false),
                    MaximumComponentLength = table.Column<int>(nullable: false),
                    MediaType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<long>(nullable: false),
                    SupportsDiskQuotas = table.Column<bool>(nullable: false),
                    SupportsFileBasedCompression = table.Column<bool>(nullable: false),
                    SystemName = table.Column<string>(nullable: true),
                    VolumeDirty = table.Column<bool>(nullable: false),
                    VolumeName = table.Column<string>(nullable: true),
                    VolumeSerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogicalDisks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PSDrives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Free = table.Column<long>(nullable: false),
                    HostName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Root = table.Column<string>(nullable: true),
                    Used = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSDrives", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogicalDisks");

            migrationBuilder.DropTable(
                name: "PSDrives");
        }
    }
}
