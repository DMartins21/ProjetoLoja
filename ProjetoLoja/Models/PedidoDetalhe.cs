using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjetoLoja.Models;
namespace ProjetoLoja.Models;

public class PedidoDetalhe
{
    [Key]
    public int IdPedidoDetalhe { get; set; }
    public int PedidoId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    [Column(TypeName = "decimal (18,2)")]
    public decimal Preco { get; set; }
    public virtual Produto Produto { get; set; }
    public virtual Pedido Pedido { get; set; }
}