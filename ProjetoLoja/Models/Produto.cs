using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProjetoLoja.Models;

public class Produto
{
    [Key]
    public int IdProduto { get; set; }
    
    [Required]
    [DisplayName("Nome")]
    public string NomeProduto { get; set; }
    
    [Required]
    [DisplayName("Preço")]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }
    
    [Required]
    [DisplayName("Descrição")]
    [MinLength(20, ErrorMessage = "Descrição deve ter no minimo {1} caracteres}")]
    [MaxLength(200, ErrorMessage = "Descrição deve ter no máximo {1} caracteres}")]
    public string Descricao { get; set; }
    
    
    public string UrlImagem { get; set; }
    
    
    public string ThumbnailImagem { get; set; }
    
    [Required]
    public int Estoque { get; set; }
    
    
    public bool Favorito { get; set; }
    
    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; }
}