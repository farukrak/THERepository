using Microsoft.EntityFrameworkCore.Migrations;

namespace AloeExpress.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Recipients_RecipientId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeName",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipients",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_LastName",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTypeName",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Recipients",
                newName: "SecurityCode");

            migrationBuilder.RenameColumn(
                name: "Tariff",
                table: "ProductTypeViewModel",
                newName: "TariffContainer");

            migrationBuilder.RenameColumn(
                name: "Tariff",
                table: "ProductTypes",
                newName: "TariffContainer");

            migrationBuilder.RenameColumn(
                name: "RecipientId1",
                table: "Orders",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RecipientId1",
                table: "Orders",
                newName: "IX_Orders_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "SecurityCode",
                table: "Recipients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Recipients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "TariffAvia",
                table: "ProductTypeViewModel",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TariffAvia",
                table: "ProductTypes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "RecipientId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProductTypeName",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipientFullName",
                table: "Orders",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipients",
                table: "Recipients",
                column: "FullName");

            migrationBuilder.CreateTable(
                name: "ProductAddViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAddViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypeAddViewModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAdded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypeAddViewModel", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "RecipientViewModel",
                columns: table => new
                {
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecurityCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipientViewModel", x => x.FullName);
                });

            migrationBuilder.CreateTable(
                name: "OrderViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ProductTypeName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderViewModel_ProductAddViewModel_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductAddViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderViewModel_ProductTypeAddViewModel_ProductTypeName",
                        column: x => x.ProductTypeName,
                        principalTable: "ProductTypeAddViewModel",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_FullName",
                table: "Recipients",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductTypeName",
                table: "Orders",
                column: "ProductTypeName");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RecipientFullName",
                table: "Orders",
                column: "RecipientFullName");

            migrationBuilder.CreateIndex(
                name: "IX_OrderViewModel_ProductId",
                table: "OrderViewModel",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderViewModel_ProductTypeName",
                table: "OrderViewModel",
                column: "ProductTypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductTypes_ProductTypeName",
                table: "Orders",
                column: "ProductTypeName",
                principalTable: "ProductTypes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Recipients_RecipientFullName",
                table: "Orders",
                column: "RecipientFullName",
                principalTable: "Recipients",
                principalColumn: "FullName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ProductTypes_ProductTypeName",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Recipients_RecipientFullName",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderViewModel");

            migrationBuilder.DropTable(
                name: "RecipientViewModel");

            migrationBuilder.DropTable(
                name: "ProductAddViewModel");

            migrationBuilder.DropTable(
                name: "ProductTypeAddViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipients",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_FullName",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductTypeName",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RecipientFullName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "TariffAvia",
                table: "ProductTypeViewModel");

            migrationBuilder.DropColumn(
                name: "TariffAvia",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductTypeName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RecipientFullName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "SecurityCode",
                table: "Recipients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TariffContainer",
                table: "ProductTypeViewModel",
                newName: "Tariff");

            migrationBuilder.RenameColumn(
                name: "TariffContainer",
                table: "ProductTypes",
                newName: "Tariff");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Orders",
                newName: "RecipientId1");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                newName: "IX_Orders_RecipientId1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Recipients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Recipients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Recipients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductTypeName",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipientId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipients",
                table: "Recipients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_LastName",
                table: "Recipients",
                column: "LastName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeName",
                table: "Products",
                column: "ProductTypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Recipients_RecipientId1",
                table: "Orders",
                column: "RecipientId1",
                principalTable: "Recipients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeName",
                table: "Products",
                column: "ProductTypeName",
                principalTable: "ProductTypes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
