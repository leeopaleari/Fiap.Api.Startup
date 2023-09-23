using Fiap.Api.Startup.Models;

namespace Fiap.Api.Startup.DTO.UsuarioDTO;

public class OutListUserDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }

    public string? Sobrenome { get; set; }

    public string? Email { get; set; }

    public DateTime DataNascimento { get; set; }

    public string? Celular { get; set; }

    public string? Documento { get; set; }

    public Endereco? Endereco { get; set; }
    public IEnumerable<Veiculo>? Veiculo { get; set; }

}
