using Fiap.Api.Startup.Models;
using Fiap.Api.Startup.Repository.Context;

namespace Fiap.Api.Startup.Repository
{
    public class VeiculoRepository
    {
        private readonly DatabaseContext _context;

        public VeiculoRepository(DatabaseContext ctx)
        {
            _context = ctx;
        }

        public IList<Veiculo> Listar()
        {
            var lista = new List<Veiculo>();

            lista = _context.Veiculo
                .OrderBy(e => e.Id)
                .ToList<Veiculo>();

            return lista;
        }

        public Veiculo Consultar(int id)
        {
            var veiculo = _context.Veiculo
                .FirstOrDefault(user => user.Id == id);

            return veiculo;
        }

        public void Excluir(Veiculo veiculo)
        {
            _context.Veiculo.Remove(veiculo);
            _context.SaveChanges();
        }

        public void Update(Veiculo veiculo)
        {
            _context.Veiculo.Update(veiculo);
            _context.SaveChanges();
        }

        public void Inserir(Veiculo veiculo)
        {
            _context.Veiculo.Add(veiculo);
            _context.SaveChanges();
        }
    }
}
