using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovimientosBodegaSensible.Migrations
{
    /// <inheritdoc />
    public partial class AdminRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF NOT EXISTS(Select Id From AspNetRoles where Id = 'd2c0b487-b437-401e-b23c-393de3526fdb')
                                    BEGIN
	                                    INSERT AspNetRoles (Id, [Name], [NormalizedName])
	                                    VALUES ('d2c0b487-b437-401e-b23c-393de3526fdb','admin','ADMIN')
                                    END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles Where Id = 'd2c0b487-b437-401e-b23c-393de3526fdb'");
        }
    }
}