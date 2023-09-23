using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fiap.Api.Startup.Models;

[Table("T_ENDERECO")]
public class Endereco
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("LOGRADOURO")]
    public string? Logradouro { get; set; }

    [Column("BAIRRO")]
    public string? Bairro { get; set; }

    [Column("CIDADE")]
    public string? Cidade { get; set; }

    [Column("ESTADO")]
    public string? Estado { get; set; }

    [Column("COMPLEMENTO")]
    public string? Complemento { get; set; }

    [Column("NUMERO")]
    public string? Numero { get; set; }

    [Column("CEP")]
    public string? Cep { get; set; }

    [Column("T_USUARIO_ID")]
    public int UsuarioId { get; set; }

    [JsonIgnore]
    public Usuario? Usuario { get; set; }
}
