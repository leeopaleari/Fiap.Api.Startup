using AutoMapper;
using Fiap.Api.Startup.DTO.UsuarioDTO;
using Fiap.Api.Startup.Models;
using Fiap.Api.Startup.Repository;
using Fiap.Api.Startup.Repository.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Startup.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioRepository usuarioRepository;
    private IMapper _mapper;

    public UsuarioController(DatabaseContext dbContext, IMapper mapper)
    {
        usuarioRepository = new UsuarioRepository(dbContext);
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<Usuario> Get()
    {
        try
        {
            var usuarios = usuarioRepository.Listar();

            if (usuarios == null)
            {
                return NotFound();
            }

            var lista = _mapper.Map<List<OutListUserDto>>(usuarios);

            return Ok(lista);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<Usuario> Get([FromRoute] int id)
    {
        try
        {
            var usuario = usuarioRepository.Consultar(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OutCreateUserDto>(usuario));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    public ActionResult<Usuario> Post([FromBody] Usuario usuarioModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            usuarioRepository.Inserir(usuarioModel);

            var location = new Uri(Request.GetEncodedUrl() + "/" + usuarioModel.Id);

            return Created(location, _mapper.Map<OutCreateUserDto>(usuarioModel));
        }
        catch (Exception error)
        {
            return BadRequest(new { message = $"Não foi possível cadastrar o Usuario. Detalhes: {error.Message}" });
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<Usuario> Post([FromRoute] int id)
    {
        try
        {
            var usuario = usuarioRepository.Consultar(id);

            if (usuario != null)
            {
                usuarioRepository.Excluir(usuario);

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
    public ActionResult<Usuario> Post([FromRoute] int id, [FromBody] InUpdateUserDto usuarioModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var usuario = usuarioRepository.Consultar(id);

            if (id != usuarioModel.Id || usuario == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(usuarioModel.Senha))
            {
                usuarioModel.Senha = usuario.Senha;
            }

            _mapper.Map(usuarioModel, usuario);
            usuarioRepository.Update(usuario);
            return NoContent();
        }
        catch (Exception error)
        {
            return BadRequest(new { message = $"Não foi possível cadastrar o Usuario. Detalhes: {error.Message}" });
        }
    }

}
