using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class CriarBancodeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_avaliacao",
                columns: table => new
                {
                    id_avaliacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vl_feedback = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_avaliacao);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tb_cambio",
                columns: table => new
                {
                    id_cambio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_cambio = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_cambio);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tb_combustivel",
                columns: table => new
                {
                    id_combustivel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_combustivel = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_combustivel);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tb_fabricante",
                columns: table => new
                {
                    id_fabricante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_fabricante = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_fabricante);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tb_modelo",
                columns: table => new
                {
                    id_modelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_modelo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_modelo);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tb_nivel_acesso",
                columns: table => new
                {
                    id_nivel_acesso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_nivel = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_nivel_acesso);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tb_carros",
                columns: table => new
                {
                    id_carro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nm_carro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dt_ano_fabricacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    dt_ano_modelo = table.Column<DateTime>(type: "datetime", nullable: false),
                    ds_potencia = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    vl_preco = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    id_modelo = table.Column<int>(type: "int", nullable: false),
                    id_fabricante = table.Column<int>(type: "int", nullable: true),
                    id_cambio = table.Column<int>(type: "int", nullable: true),
                    id_combustivel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_carro);
                    table.ForeignKey(
                        name: "tb_carros_ibfk_1",
                        column: x => x.id_modelo,
                        principalTable: "tb_modelo",
                        principalColumn: "id_modelo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tb_carros_ibfk_2",
                        column: x => x.id_fabricante,
                        principalTable: "tb_fabricante",
                        principalColumn: "id_fabricante");
                    table.ForeignKey(
                        name: "tb_carros_ibfk_3",
                        column: x => x.id_cambio,
                        principalTable: "tb_cambio",
                        principalColumn: "id_cambio");
                    table.ForeignKey(
                        name: "tb_carros_ibfk_4",
                        column: x => x.id_combustivel,
                        principalTable: "tb_combustivel",
                        principalColumn: "id_combustivel");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nm_usuario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ds_email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ds_senha = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dt_nascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    dt_ultimo_login = table.Column<DateTime>(type: "datetime", nullable: false),
                    dt_conta_criada = table.Column<DateTime>(type: "datetime", nullable: false),
                    dt_conta_atualizada = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_nivel_acesso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_usuario);
                    table.ForeignKey(
                        name: "tb_usuario_ibfk_1",
                        column: x => x.id_nivel_acesso,
                        principalTable: "tb_nivel_acesso",
                        principalColumn: "id_nivel_acesso",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tb_clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nm_cliente = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ds_endereco = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nr_rg = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nr_cpf = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nr_cnh = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nr_telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nr_celular = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_cliente);
                    table.ForeignKey(
                        name: "tb_clientes_ibfk_1",
                        column: x => x.id_usuario,
                        principalTable: "tb_usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tb_feedback",
                columns: table => new
                {
                    id_feedback = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_feedback = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dt_feedback = table.Column<DateTime>(type: "datetime", nullable: false),
                    dt_ultima_alteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_avaliacao = table.Column<int>(type: "int", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_feedback);
                    table.ForeignKey(
                        name: "tb_feedback_ibfk_1",
                        column: x => x.id_avaliacao,
                        principalTable: "tb_avaliacao",
                        principalColumn: "id_avaliacao");
                    table.ForeignKey(
                        name: "tb_feedback_ibfk_2",
                        column: x => x.id_usuario,
                        principalTable: "tb_usuario",
                        principalColumn: "id_usuario");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tb_test_drive",
                columns: table => new
                {
                    id_test_drive = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dt_test_drive = table.Column<DateTime>(type: "datetime", nullable: false),
                    bl_desmarcado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    bl_realizado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    id_carro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_test_drive);
                    table.ForeignKey(
                        name: "tb_test_drive_ibfk_1",
                        column: x => x.id_cliente,
                        principalTable: "tb_clientes",
                        principalColumn: "id_cliente");
                    table.ForeignKey(
                        name: "tb_test_drive_ibfk_2",
                        column: x => x.id_carro,
                        principalTable: "tb_carros",
                        principalColumn: "id_carro",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "id_cambio",
                table: "tb_carros",
                column: "id_cambio");

            migrationBuilder.CreateIndex(
                name: "id_combustivel",
                table: "tb_carros",
                column: "id_combustivel");

            migrationBuilder.CreateIndex(
                name: "id_fabricante",
                table: "tb_carros",
                column: "id_fabricante");

            migrationBuilder.CreateIndex(
                name: "id_modelo",
                table: "tb_carros",
                column: "id_modelo");

            migrationBuilder.CreateIndex(
                name: "id_usuario",
                table: "tb_clientes",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "id_avaliacao",
                table: "tb_feedback",
                column: "id_avaliacao");

            migrationBuilder.CreateIndex(
                name: "id_usuario1",
                table: "tb_feedback",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "id_carro",
                table: "tb_test_drive",
                column: "id_carro");

            migrationBuilder.CreateIndex(
                name: "id_cliente",
                table: "tb_test_drive",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "id_nivel_acesso",
                table: "tb_usuario",
                column: "id_nivel_acesso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_feedback");

            migrationBuilder.DropTable(
                name: "tb_test_drive");

            migrationBuilder.DropTable(
                name: "tb_avaliacao");

            migrationBuilder.DropTable(
                name: "tb_clientes");

            migrationBuilder.DropTable(
                name: "tb_carros");

            migrationBuilder.DropTable(
                name: "tb_usuario");

            migrationBuilder.DropTable(
                name: "tb_modelo");

            migrationBuilder.DropTable(
                name: "tb_fabricante");

            migrationBuilder.DropTable(
                name: "tb_cambio");

            migrationBuilder.DropTable(
                name: "tb_combustivel");

            migrationBuilder.DropTable(
                name: "tb_nivel_acesso");
        }
    }
}
