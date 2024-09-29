using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTécnica.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_clients_id_cuenta",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "fk_motions_account_cuenta_id",
                table: "motions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_motions",
                table: "motions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_clients",
                table: "clients");

            migrationBuilder.DropPrimaryKey(
                name: "pk_account",
                table: "account");

            migrationBuilder.DropIndex(
                name: "ix_account_id_cuenta",
                table: "account");

            migrationBuilder.DropColumn(
                name: "saldo_currency",
                table: "motions");

            migrationBuilder.DropColumn(
                name: "valor_currency",
                table: "motions");

            migrationBuilder.DropColumn(
                name: "saldo_currency",
                table: "account");

            migrationBuilder.AddPrimaryKey(
                name: "pk_motions",
                table: "motions",
                column: "id_movimiento");

            migrationBuilder.AddPrimaryKey(
                name: "pk_clients",
                table: "clients",
                column: "id_cliente");

            migrationBuilder.AddPrimaryKey(
                name: "pk_account",
                table: "account",
                column: "id_cuenta");

            migrationBuilder.AddForeignKey(
                name: "fk_account_clients_id_cuenta",
                table: "account",
                column: "id_cuenta",
                principalTable: "clients",
                principalColumn: "id_cliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_motions_account_cuenta_id",
                table: "motions",
                column: "cuenta_id",
                principalTable: "account",
                principalColumn: "id_cuenta",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_clients_id_cuenta",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "fk_motions_account_cuenta_id",
                table: "motions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_motions",
                table: "motions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_clients",
                table: "clients");

            migrationBuilder.DropPrimaryKey(
                name: "pk_account",
                table: "account");

            migrationBuilder.AddColumn<string>(
                name: "saldo_currency",
                table: "motions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "valor_currency",
                table: "motions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "saldo_currency",
                table: "account",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_motions",
                table: "motions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_clients",
                table: "clients",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_account",
                table: "account",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_account_id_cuenta",
                table: "account",
                column: "id_cuenta");

            migrationBuilder.AddForeignKey(
                name: "fk_account_clients_id_cuenta",
                table: "account",
                column: "id_cuenta",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_motions_account_cuenta_id",
                table: "motions",
                column: "cuenta_id",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
