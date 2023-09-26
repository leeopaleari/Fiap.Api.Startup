using Fiap.Api.Startup.Models;
using Fiap.Api.Startup.Repository.Context;

namespace Fiap.Api.Startup.Repository;

public class PropostaRepository
{
    private readonly DatabaseContext _context;

    public PropostaRepository(DatabaseContext ctx)
    {
        _context = ctx;
    }

    public IList<Proposta> Listar()
    {
        var lista = new List<Proposta>();

        lista = _context.Proposta
            .OrderBy(e => e.Id)
            .ToList<Proposta>();

        return lista;
    }

    public Proposta Consultar(int id)
    {
        var proposta = _context.Proposta
            .FirstOrDefault(prop => prop.Id == id);

        return proposta;
    }

    public void Excluir(Proposta proposta)
    {
        _context.Proposta.Remove(proposta);
        _context.SaveChanges();
    }

    public void Update(Proposta proposta)
    {
        _context.Proposta.Update(proposta);
        _context.SaveChanges();
    }

    public void Inserir(Proposta proposta)
    {
        _context.Proposta.Add(proposta);
        _context.SaveChanges();
    }
}

