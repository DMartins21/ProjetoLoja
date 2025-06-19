using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLoja.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                "VALUES('Smartphone X', 2499.99, 'Celular de última geração', 'https://exemplo.com/imagens/smartphone.jpg', 'https://exemplo.com/thumbs/smartphone.jpg', 10, 1, 2)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Notebook Ultra', 4599.50, 'Notebook leve e potente', 'https://exemplo.com/imagens/notebook.jpg', 'https://exemplo.com/thumbs/notebook.jpg', 5, 0, 2)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Fone Bluetooth', 299.90, 'Fones sem fio com cancelamento de ruído', 'https://exemplo.com/imagens/fone.jpg', 'https://exemplo.com/thumbs/fone.jpg', 20, 1, 2)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Camiseta Preta', 49.90, 'Camiseta básica preta de algodão', 'https://exemplo.com/imagens/camiseta.jpg', 'https://exemplo.com/thumbs/camiseta.jpg', 30, 0, 3)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Calça Jeans', 119.90, 'Calça jeans slim fit', 'https://exemplo.com/imagens/calca.jpg', 'https://exemplo.com/thumbs/calca.jpg', 15, 1, 3)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Jaqueta Couro', 299.90, 'Jaqueta estilosa de couro sintético', 'https://exemplo.com/imagens/jaqueta.jpg', 'https://exemplo.com/thumbs/jaqueta.jpg', 8, 1, 3)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Vestido Floral', 89.90, 'Vestido casual com estampa floral', 'https://exemplo.com/imagens/vestido.jpg', 'https://exemplo.com/thumbs/vestido.jpg', 12, 0, 3)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Livro de Python', 79.90, 'Aprenda Python do zero ao avançado', 'https://exemplo.com/imagens/python.jpg', 'https://exemplo.com/thumbs/python.jpg', 25, 1, 4)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Romance Moderno', 39.90, 'História envolvente de amor contemporâneo', 'https://exemplo.com/imagens/romance.jpg', 'https://exemplo.com/thumbs/romance.jpg', 10, 0, 4)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Guia de SQL', 59.90, 'Tudo sobre bancos de dados relacionais', 'https://exemplo.com/imagens/sql.jpg', 'https://exemplo.com/thumbs/sql.jpg', 18, 1, 4)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Biografia Inspiradora', 45.00, 'História real e inspiradora de superação', 'https://exemplo.com/imagens/biografia.jpg', 'https://exemplo.com/thumbs/biografia.jpg', 14, 0, 4)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Pacote de Arroz 5kg', 23.90, 'Arroz tipo 1', 'https://exemplo.com/imagens/arroz.jpg', 'https://exemplo.com/thumbs/arroz.jpg', 40, 0, 5)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Feijão Carioca 1kg', 8.99, 'Feijão saboroso e nutritivo', 'https://exemplo.com/imagens/feijao.jpg', 'https://exemplo.com/thumbs/feijao.jpg', 35, 1, 5)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Óleo de Soja 900ml', 6.99, 'Óleo vegetal refinado', 'https://exemplo.com/imagens/oleo.jpg', 'https://exemplo.com/thumbs/oleo.jpg', 25, 0, 5)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Moletom Unissex', 99.90, 'Moletom confortável para o dia a dia', 'https://exemplo.com/imagens/moletom.jpg', 'https://exemplo.com/thumbs/moletom.jpg', 17, 0, 3)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Tênis Esportivo', 149.90, 'Tênis ideal para corrida e academia', 'https://exemplo.com/imagens/tenis.jpg', 'https://exemplo.com/thumbs/tenis.jpg', 10, 1, 3)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Refrigerante Cola 2L', 7.50, 'Bebida gaseificada', 'https://exemplo.com/imagens/refrigerante.jpg', 'https://exemplo.com/thumbs/refrigerante.jpg', 22, 1, 5)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Chocolate 100g', 5.99, 'Chocolate ao leite delicioso', 'https://exemplo.com/imagens/chocolate.jpg', 'https://exemplo.com/thumbs/chocolate.jpg', 50, 0, 5)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Tablet Sans\"', 999.90, 'Tablet com tela grande e ótimo desempenho', 'https://exemplo.com/imagens/tablet.jpg', 'https://exemplo.com/thumbs/tablet.jpg', 7, 1, 2)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Smartwatch Fit', 399.90, 'Relógio inteligente com monitor de saúde', 'https://exemplo.com/imagens/smartwatch.jpg', 'https://exemplo.com/thumbs/smartwatch.jpg', 12, 1, 2)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(NomeProduto, Preco , Descricao, UrlImagem, ThumbnailImagem, Estoque, Favorito, CategoriaId)" + 
                                 "VALUES('Kit Lanche Natural', 15.99, 'Sanduíche + Suco + Fruta', 'https://exemplo.com/imagens/kitlanche.jpg', 'https://exemplo.com/thumbs/kitlanche.jpg', 18, 0, 5)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
