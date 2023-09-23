using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Api.Startup.Models;

[Table("T_VEICULO")]
public class Veiculo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("MARCA")]
    public string? Marca { get; set; }

    [Column("MODELO")]
    public string? Modelo { get; set; }

    [Column("PLACA")]
    public string? Placa { get; set; }

    [Column("QUILOMETRAGEM")]
    public int Quilometragem { get; set; }

    [Column("ANO_MODELO")]
    public int AnoModelo { get; set; }

    [Column("ANO_FABRICACAO")]
    public int AnoFabricacao { get; set; }

}
