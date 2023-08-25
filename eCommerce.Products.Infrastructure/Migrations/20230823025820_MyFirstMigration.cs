using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details_Brand = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Details_Model = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Details_Color = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Details_Maker = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.CheckConstraint("Ck_Product_BillingType", "BillingType IN ('Recurring', 'OneTime')");
                    table.CheckConstraint("Ck_Product_Category", "Category IN ('VoicePlanProduct', 'DeviceMobile', 'DeviceTable','Other')");
                    table.CheckConstraint("Ck_Product_Status", "Status IN ('Active', 'Inactive')");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
