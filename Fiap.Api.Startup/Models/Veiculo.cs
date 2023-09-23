using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fiap.Api.Startup.Models;

[Table("T_VEICULO")]
public class Veiculo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("MARCA")]
    [Required(ErrorMessage = "Campo Marca Obrigatório")]
    public string? Marca { get; set; }

    [Column("MODELO")]
    [Required(ErrorMessage = "Campo Modelo Obrigatório")]
    public string? Modelo { get; set; }

    [Column("PLACA")]
    [Required(ErrorMessage = "Campo Placa Obrigatório")]
    [StringLength(8, ErrorMessage = "Tamanho máximo de 8 caracteres")]
    public string? Placa { get; set; }

    [Column("QUILOMETRAGEM")]
    [Required(ErrorMessage = "Campo Quilometragem Obrigatório")]
    public int Quilometragem { get; set; }

    [Column("ANO_MODELO")]
    [Required(ErrorMessage = "Campo Ano Modelo Obrigatório")]
    public int AnoModelo { get; set; }

    [Column("ANO_FABRICACAO")]
    [Required(ErrorMessage = "Campo Ano Fabricação Obrigatório")]
    public int AnoFabricacao { get; set; }

    [Column("T_USUARIO_ID")]
    [Required(ErrorMessage = "Obrigatório informar um usuário")]
    public int UsuarioId { get; set; }

    [JsonIgnore]
    [Required(ErrorMessage = "Obrigatório informar um usuário")]
    public Usuario? Usuario { get; set; }

}
