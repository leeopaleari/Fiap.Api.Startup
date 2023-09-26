using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fiap.Api.Startup.Models;

[Table("T_PROPOSTA_SEGURO")]
public class Proposta
{
    [Key]
    [Column("ID")]
    public int Id { get; set; } // ID único da proposta

    [Column("DATA_CRIACAO")]
    public DateTime DataCriacao { get; set; } // Data de criação da proposta

    [Column("DATA_VALIDADE")]
    public DateTime DataValidade { get; set; } // Data de validade da proposta

    [Column("VLR_SEGURO")]
    public decimal ValorSeguro { get; set; } // Valor do seguro proposto

    [Column("OBSERVACOES")]
    public string? Observacoes { get; set; } // Observações adicionais

    [Column("STATUS")]
    public string Status { get; set; } // Status da proposta (Aceita, Rejeitada, Pendente, etc.)



    // Relacionamento com o Cliente
    [Column("T_USUARIO_ID")]
    [Required(ErrorMessage = "Obrigatório informar o Usuário")]
    public int UsuarioId { get; set; } // Chave estrangeira para o Cliente

    [JsonIgnore]
    public virtual Usuario? Usuario { get; set; }


    [Column("T_VEICULO_ID")]
    [Required(ErrorMessage = "Obrigatório informar ao menos um Veículo")]
    public int VeiculoId { get; set; } 
    
    [JsonIgnore]
    public virtual Veiculo? Veiculo { get; set; }
}

public enum StatusProposta
{
Pendente,
Aceita,
Rejeitada,
Cancelada
}
