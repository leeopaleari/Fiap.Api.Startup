using Fiap.Api.Startup.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fiap.Api.Startup.DTO.UsuarioDTO;

public class InUpdateUserDto
{
    [Column("ID")]
    [Required(ErrorMessage = "Campo ID é obrigatório")]
    public int Id { get; set; }

    [Column("NOME")]
    [Required(ErrorMessage = "Campo Nome é obrigatório")]
    [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
    public string Nome { get; set; }

    [Column("SOBRENOME")]
    [Required(ErrorMessage = "Campo Sobrenome é obrigatório")]
    [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
    public string Sobrenome { get; set; }

    [Column("EMAIL")]
    [Required(ErrorMessage = "Campo e-mail é obrigatório")]
    [EmailAddress]
    public string Email { get; set; }

    [Column("DATA_NASCIMENTO")]
    [Required(ErrorMessage = "Campo Data de Nascimento é obrigatório")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    [Column("CELULAR")]
    [Required(ErrorMessage = "Campo Celular é obrigatório")]
    [StringLength(15, ErrorMessage = "Máximo 15 caracteres")]
    public string Celular { get; set; }

    [Column("SENHA")]
    public string? Senha { get; set; }

    [Column("DOCUMENTO")]
    [Required(ErrorMessage = "Campo Documento é obrigatório")]
    public string Documento { get; set; }

    //[JsonIgnore]
    public Endereco? Endereco { get; set; }

}
