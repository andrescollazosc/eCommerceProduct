using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnNameKeepingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("CreatedOn", "Products", "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("CreatedDate", "Products", "CreatedOn");
        }
    }
}
