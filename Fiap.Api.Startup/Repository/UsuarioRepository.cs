using Fiap.Api.Startup.Models;
using Fiap.Api.Startup.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Startup.Repository;

public class UsuarioRepository
{
    private readonly DatabaseContext context;

    public UsuarioRepository(DatabaseContext ctx)
    {
        context = ctx;
    }


    public IList<Usuario> Listar()
    {
        var lista = new List<Usuario>();

        lista = context.Usuario
            .Include(u => u.Endereco)
            .Include(u => u.Veiculos)
            .OrderBy(u => u.Id)
            .ToList<Usuario>();

        return lista;
    }

    public Usuario Consultar(int id)
    {
        var usuario = context.Usuario
            .Include(e => e.Endereco)
            .FirstOrDefault(user => user.Id == id);

        return usuario;
    }

    public void Excluir(Usuario usuario)
    {
        context.Usuario.Remove(usuario);
        context.SaveChanges();
    }

    public void Update(Usuario usuario)
    {
        context.Usuario.Update(usuario);
        context.SaveChanges();
    }

    public void Inserir(Usuario usuario)
    {
        context.Usuario.Add(usuario);
        context.SaveChanges();
    }
}
