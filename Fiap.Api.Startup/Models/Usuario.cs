using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fiap.Api.Startup.Models;

[Table("T_USUARIO")]
public class Usuario
{
    [Key]
    [Column("ID")]

    public int Id { get; set; }

    [Column("NOME")]
    public string Nome { get; set; }

    [Column("SOBRENOME")]
    public string? Sobrenome { get; set; }

    [Column("EMAIL")]
    public string? Email { get; set; }

    [Column("DATA_NASCIMENTO")]
    public DateTime DataNascimento { get; set; }

    [Column("CELULAR")]
    public string? Celular { get; set; }

    [Column("SENHA")]
    public string? Senha { get; set; }

    [Column("DOCUMENTO")]
    public string? Documento { get; set; }

    //[JsonIgnore]
    [Required(ErrorMessage = "Necessário informar endereço")]
    public virtual Endereco? Endereco { get; set; }

    //[JsonIgnore]
    public virtual IEnumerable<Veiculo>? Veiculos { get; set; }

    //[JsonIgnore]
    public virtual IEnumerable<Proposta>? Proposta { get; set; }
}