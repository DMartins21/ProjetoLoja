using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLoja.Models;

public class Pedido
{
    public int PedidoId { get; set; }
    [Required(ErrorMessage =  "Informe um nome")]
    [StringLength(50)]
    public string Nome {get; set;}
    [Required]
    [StringLength(50)]
    public string Sobrenome { get; set; }
    [Required]
    [StringLength(14, MinimumLength = 11)]
    public string Cpf { get; set; }
    [Required(ErrorMessage = "Informe seu Endereço")]
    [StringLength(100)]
    public string Endereco { get; set; }
    [Required]
    public string Cidade { get; set; }
    [Required]
    public string Estado { get; set; }
    [Required(ErrorMessage = "Informe seu CEP")]
    [StringLength(10, MinimumLength = 8)]
    public string Cep { get; set; }
    [Required]
    [StringLength(25)]
    [DataType(DataType.PhoneNumber)]
    public string Telefone { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"\b[A-Za-z0-9._%-]+@(live\.wcs\.ac\.uk\.com)\b")]
    public string Email { get; set; }
    [Column(TypeName = "Decimal(18,2)")]
    public decimal TotaldoPedido { get; set; }
    public int TotaldeItens { get; set; }
    [DataType(DataType.Text)]
    [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime PedidoCriado { get; set; }
    [DataType(DataType.Text)]
    [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime? PedidoEnviado { get; set; }
    [DataType(DataType.Text)]
    [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime? PedidoEntregue { get; set; }

    public List<PedidoDetalhe> PedidosDetalhe { get; set; } = new();
}