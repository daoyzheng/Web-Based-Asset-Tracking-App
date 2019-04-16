using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPRG214.Assets.Data.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TagNumber = table.Column<string>(nullable: false),
                    AssetTypeId = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AssetTypes_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AssetTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Computer" });

            migrationBuilder.InsertData(
                table: "AssetTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Monitors" });

            migrationBuilder.InsertData(
                table: "AssetTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Phone" });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetTypeId", "Description", "Manufacturer", "Model", "SerialNumber", "TagNumber" },
                values: new object[,]
                {
                    { 1, 1, "Out of Stock", "Dell", null, "xbi-2938-1029", "A100" },
                    { 4, 1, "Shipped", "Acer", "Aspire E 17", "bnx-4823-9857", "A132" },
                    { 6, 1, "Order Paid", "HP", "Pavillion", "aie-1235-4987", "A435" },
                    { 2, 2, "On Sale", "LG", "UltraSharp", "nlw-8439-4839", "A101" },
                    { 3, 2, "On Sale", "Acer", "V256HQL", "ixn-4938-2785", "A103" },
                    { 5, 3, "Refurbished", "Cisco", "CP-7841-K9", "osn-3928-9201", "A423" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetTypeId",
                table: "Assets",
                column: "AssetTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "AssetTypes");
        }
    }
}
