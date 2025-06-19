using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetoLoja.Models;

public class Categoria
{
    [Key]
    public int IdCategoria { get; set; }
    
    [Required]
    [DisplayName("Categoria:")]
    public string NomeCategoria { get; set; }
    
    [Required]
    [DisplayName("Descrição")]
    [MaxLength(200)]
    public string DescricaoCategoria { get; set; }
    
    public string ImagemUrl { get; set; }
    
    public ICollection<Produto> Produto { get; set; } = new List<Produto>();
}