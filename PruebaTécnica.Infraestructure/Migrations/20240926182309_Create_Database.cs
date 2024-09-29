using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTécnica.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id_persona = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    genero = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    edad = table.Column<int>(type: "integer", maxLength: 200, nullable: false),
                    identificacion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    dirección = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    teléfono = table.Column<int>(type: "integer", maxLength: 200, nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persons", x => x.id_persona);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_cliente = table.Column<Guid>(type: "uuid", nullable: false),
                    contraseña = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "boolean", maxLength: 200, nullable: false),
                    persona_id = table.Column<Guid>(type: "uuid", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clients", x => x.id);
                    table.ForeignKey(
                        name: "FK_Client_Persona",
                        column: x => x.persona_id,
                        principalTable: "persons",
                        principalColumn: "id_persona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_cuenta = table.Column<Guid>(type: "uuid", nullable: false),
                    id_cliente = table.Column<Guid>(type: "uuid", nullable: false),
                    numero_cuenta = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    saldo_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    saldo_currency = table.Column<string>(type: "text", nullable: false),
                    estado = table.Column<bool>(type: "boolean", maxLength: 50, nullable: false),
                    tipo_de_cuenta = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account", x => x.id);
                    table.ForeignKey(
                        name: "fk_account_clients_id_cuenta",
                        column: x => x.id_cuenta,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "motions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_movimiento = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo_de_movimiento = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    valor_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_currency = table.Column<string>(type: "text", nullable: false),
                    saldo_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    saldo_currency = table.Column<string>(type: "text", nullable: false),
                    fecha_de_movimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cuenta_id = table.Column<Guid>(type: "uuid", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_motions", x => x.id);
                    table.ForeignKey(
                        name: "fk_motions_account_cuenta_id",
                        column: x => x.cuenta_id,
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_account_id_cuenta",
                table: "account",
                column: "id_cuenta");

            migrationBuilder.CreateIndex(
                name: "ix_clients_persona_id",
                table: "clients",
                column: "persona_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_motions_cuenta_id",
                table: "motions",
                column: "cuenta_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "motions");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
