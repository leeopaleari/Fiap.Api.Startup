using AutoMapper;
using Fiap.Api.Startup.Models;
using Fiap.Api.Startup.Repository;
using Fiap.Api.Startup.Repository.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Startup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoRepository _repository;
        private IMapper _mapper;

        public VeiculoController(DatabaseContext dbContext, IMapper mapper)
        {
            _repository = new VeiculoRepository(dbContext);
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<Veiculo> Get()
        {
            try
            {
                var veiculos = _repository.Listar();

                if (veiculos == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<Veiculo>>(veiculos));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Veiculo> Get([FromRoute] int id)
        {
            try
            {
                var veiculo = _repository.Consultar(id);

                if (veiculo == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<Veiculo>(veiculo));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<Veiculo> Post([FromBody] Veiculo veiculoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                _repository.Inserir(veiculoModel);

                var location = new Uri(Request.GetEncodedUrl() + "/" + veiculoModel.Id);

                //return Created(location, usuarioModel);
                return Created(location, _mapper.Map<Veiculo>(veiculoModel));
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível cadastrar o Usuario. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Veiculo> Post([FromRoute] int id)
        {
            try
            {
                var veiculo = _repository.Consultar(id);

                if (veiculo != null)
                {
                    _repository.Excluir(veiculo);

                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível cadastrar o Usuario. Detalhes: {error.Message}" });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Veiculo> Post([FromRoute] int id, [FromBody] Veiculo veiculoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var veiculo = _repository.Consultar(id);

                if (id != veiculoModel.Id || veiculo == null)
                {
                    return NotFound();
                }

                _mapper.Map(veiculoModel, veiculo);
                _repository.Update(veiculo);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível cadastrar o Usuario. Detalhes: {error.Message}" });
            }


        }
    }
}
