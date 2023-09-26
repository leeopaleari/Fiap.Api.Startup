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
    public class PropostaController : ControllerBase
    {
        private readonly PropostaRepository _repository;
        private IMapper _mapper;

        public PropostaController(DatabaseContext dbContext, IMapper mapper)
        {
            _repository = new PropostaRepository(dbContext);
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<Proposta> Get()
        {
            try
            {
                var proposta = _repository.Listar();

                if (proposta == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<Proposta>>(proposta));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Proposta> Get([FromRoute] int id)
        {
            try
            {
                var proposta = _repository.Consultar(id);

                if (proposta == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<Proposta>(proposta));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<Proposta> Post([FromBody] Proposta propostaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                _repository.Inserir(propostaModel);

                var location = new Uri(Request.GetEncodedUrl() + "/" + propostaModel.Id);

                return Created(location, propostaModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível cadastrar a Proposta. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Proposta> Post([FromRoute] int id)
        {
            try
            {
                var proposta = _repository.Consultar(id);

                if (proposta != null)
                {
                    _repository.Excluir(proposta);

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
        public ActionResult<Proposta> Post([FromRoute] int id, [FromBody] Proposta propostaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var proposta = _repository.Consultar(id);

                if (id != propostaModel.Id || proposta == null)
                {
                    return NotFound();
                }

                _mapper.Map(propostaModel, proposta);
                _repository.Update(proposta);

                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível cadastrar o Usuario. Detalhes: {error.Message}" });
            }


        }
    }
}

