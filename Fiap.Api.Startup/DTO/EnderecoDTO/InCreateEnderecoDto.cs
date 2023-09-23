using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Fiap.Api.Startup.Models;

namespace Fiap.Api.Startup.DTO.EnderecoDTO;

public class InCreateEnderecoDto
{
    [Column("LOGRADOURO")]
    public string Logradouro { get; set; }

    [Column("BAIRRO")]
    public string Bairro { get; set; }

    [Column("CIDADE")]
    public string Cidade { get; set; }

    [Column("ESTADO")]
    public string Estado { get; set; }

    [Column("COMPLEMENTO")]
    public string? Complemento { get; set; }

    [Column("NUMERO")]
    public string Numero { get; set; }

    [Column("CEP")]
    public string Cep { get; set; }

    public Usuario? Usuario { get; set; }
}
