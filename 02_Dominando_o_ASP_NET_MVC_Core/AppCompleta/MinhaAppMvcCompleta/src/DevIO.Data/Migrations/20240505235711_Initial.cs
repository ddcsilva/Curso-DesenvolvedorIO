using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIO.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_FORNECEDORES",
                columns: table => new
                {
                    FOR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador Único do Fornecedor"),
                    FOR_NOME = table.Column<string>(type: "varchar(200)", nullable: false, comment: "Nome do Fornecedor"),
                    FOR_DOCUMENTO = table.Column<string>(type: "varchar(14)", nullable: false, comment: "Documento do Fornecedor"),
                    FOR_TIPO = table.Column<int>(type: "int", nullable: false, comment: "Tipo do Fornecedor"),
                    FOR_ATIVO = table.Column<bool>(type: "bit", nullable: false, comment: "Indica se o Fornecedor está Ativo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORNECEDORES", x => x.FOR_ID);
                },
                comment: "Tabela de Fornecedores");

            migrationBuilder.CreateTable(
                name: "TB_ENDERECOS",
                columns: table => new
                {
                    END_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador Único do Endereço"),
                    END_LOGRADOURO = table.Column<string>(type: "varchar(200)", nullable: false, comment: "Logradouro do Endereço"),
                    END_NUMERO = table.Column<string>(type: "varchar(50)", nullable: false, comment: "Número do Endereço"),
                    END_COMPLEMENTO = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Complemento do Endereço"),
                    END_CEP = table.Column<string>(type: "varchar(8)", nullable: false, comment: "CEP do Endereço"),
                    END_BAIRRO = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Bairro do Endereço"),
                    END_CIDADE = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Cidade do Endereço"),
                    END_ESTADO = table.Column<string>(type: "varchar(50)", nullable: false, comment: "Estado do Endereço"),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECOS", x => x.END_ID);
                    table.ForeignKey(
                        name: "FK_ENDERECO_FORNECEDOR",
                        column: x => x.FornecedorId,
                        principalTable: "TB_FORNECEDORES",
                        principalColumn: "FOR_ID");
                },
                comment: "Tabela de Endereços");

            migrationBuilder.CreateTable(
                name: "TB_PRODUTOS",
                columns: table => new
                {
                    PRO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador Único do Produto"),
                    PRO_NOME = table.Column<string>(type: "varchar(200)", nullable: false, comment: "Nome do Produto"),
                    PRO_DESCRICAO = table.Column<string>(type: "varchar(1000)", nullable: false, comment: "Descrição do Produto"),
                    PRO_IMAGEM = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Nome do Arquivo da Imagem do Produto"),
                    PRO_VALOR = table.Column<decimal>(type: "decimal(10,2)", nullable: false, comment: "Valor do Produto"),
                    PRO_DATA_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de Cadastro do Produto"),
                    PRO_ATIVO = table.Column<bool>(type: "bit", nullable: false, comment: "Indica se o Produto está Ativo"),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.PRO_ID);
                    table.ForeignKey(
                        name: "FK_PRODUTO_FORNECEDOR",
                        column: x => x.FornecedorId,
                        principalTable: "TB_FORNECEDORES",
                        principalColumn: "FOR_ID");
                },
                comment: "Tabela de Produtos");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECOS_FornecedorId",
                table: "TB_ENDERECOS",
                column: "FornecedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FORNECEDORES_DOCUMENTO",
                table: "TB_FORNECEDORES",
                column: "FOR_DOCUMENTO",
                unique: true,
                filter: "[FOR_DOCUMENTO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FORNECEDORES_NOME",
                table: "TB_FORNECEDORES",
                column: "FOR_NOME",
                unique: true,
                filter: "[FOR_NOME] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_NOME",
                table: "TB_PRODUTOS",
                column: "PRO_NOME",
                unique: true,
                filter: "[PRO_NOME] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTOS_FornecedorId",
                table: "TB_PRODUTOS",
                column: "FornecedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ENDERECOS");

            migrationBuilder.DropTable(
                name: "TB_PRODUTOS");

            migrationBuilder.DropTable(
                name: "TB_FORNECEDORES");
        }
    }
}
