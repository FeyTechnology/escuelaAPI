using AutoMapper;
using escuelaAPI.Models;
using escuelaAPI.Models.DTO.Alumno;
using escuelaAPI.Models.DTO.Grupo;
using escuelaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace escuelaAPI.Controllers
{
    [Route("api/grupo")]
    [ApiController]
    public class GrupoAPIController : ControllerBase
    {
        private readonly IGrupoRepository _db;
        protected APIResponse _response;
        private readonly IMapper _mapper;
        public GrupoAPIController(IGrupoRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetGrupos([FromQuery] int? escuelaId)
        {
            try
            {
                IEnumerable<Grupo> value = await _db.GetAllAsync();
                if (escuelaId != null)
                {
                    value = value.Where(u => u.EscuelaId == escuelaId);
                }
                _response.Result = value;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetGrupo")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGrupo(int id)
        {
            try
            {

                var value = await _db.GetAsync(u => u.Id == id);
                if (value == null)
                {
                    return NotFound();
                }

                _response.Result = value;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("escuela/{id:int}", Name = "GetGrupoEscuela")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetGruposEscuela(int id)
        {
            try
            {
                IEnumerable<Grupo> value = await _db.GetAllAsync();          
                value = value.Where(u => u.EscuelaId == id);

                _response.Result = value;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateGrupo([FromBody] GrupoCreateDTO value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest();
                }
                Grupo model = _mapper.Map<Grupo>(value);

                await _db.CreateAsync(model);

                _response.Result = model;
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetGrupo", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
