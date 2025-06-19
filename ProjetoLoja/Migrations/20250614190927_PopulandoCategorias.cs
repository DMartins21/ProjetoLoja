using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLoja.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(NomeCategoria, DescricaoCategoria, ImagemUrl)" +
                      "VALUES('Eletrônicos', 'Dispositivos e acessórios eletrônicos', 'https://exemplo.com/imagens/eletronicos.jpg')");
            migrationBuilder.Sql("INSERT INTO Categorias(NomeCategoria, DescricaoCategoria, ImagemUrl)" +
                "VALUES('Roupas', 'Moda masculina e feminina', 'https://exemplo.com/imagens/roupas.jpg')");
            migrationBuilder.Sql("INSERT INTO Categorias(NomeCategoria, DescricaoCategoria, ImagemUrl)" +
                                 "VALUES('Livros', 'Literatura e educação', 'https://exemplo.com/imagens/livros.jpg')");
            migrationBuilder.Sql("INSERT INTO Categorias(NomeCategoria, DescricaoCategoria, ImagemUrl)" +
                                 "VALUES('Alimentos', 'Comidas e bebidas diversas', 'https://exemplo.com/imagens/alimentos.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
