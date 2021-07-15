using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoEFCore.Migrations
{
    public partial class correcaoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                schema: "Sistema",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "Sistema",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                schema: "Sistema",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                schema: "Sistema",
                table: "Pedido",
                column: "ClienteId",
                principalSchema: "Sistema",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                schema: "Sistema",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                schema: "Sistema",
                table: "Pedido",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                schema: "Sistema",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                schema: "Sistema",
                table: "Pedido",
                column: "ClienteId",
                principalSchema: "Sistema",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
