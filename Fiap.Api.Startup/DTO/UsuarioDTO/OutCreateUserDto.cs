using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Api.Startup.DTO.UsuarioDTO;

public class OutCreateUserDto
{
    public string Nome { get; set; }

    public string Sobrenome { get; set; }

    public string Email { get; set; }

    public DateTime DataNascimento { get; set; }

    public string Celular { get; set; }

    public string Documento { get; set; }
}
