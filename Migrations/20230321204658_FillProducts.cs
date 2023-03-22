using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalog.Migrations
{
    /// <inheritdoc />
    public partial class FillProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, DateRegistration, CategoryId) Values('Dell','notebook',2100.00,'dell.jpg',8,now(),1)");
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, DateRegistration, CategoryId) Values('Nike','casual',429.00,'nike.jpg',10,now(),2)");
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, DateRegistration, CategoryId) Values('GodofWar','action',95.00,'gdw.jpg',2,now(),3)");
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, DateRegistration, CategoryId) Values('Sony','notebook',3000.00,'sony.jpg',4,now(),1)");
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, DateRegistration, CategoryId) Values('Crash Bandicoot','adventure',120.00,'crash.jpg',5,now(),3)");
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, DateRegistration, CategoryId) Values('Puma','sport',250.00,'puma.jpg',2,now(),2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Products");
        }
    }
}
