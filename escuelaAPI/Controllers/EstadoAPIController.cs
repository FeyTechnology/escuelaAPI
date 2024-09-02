using AutoMapper;
using escuelaAPI.Models.DTO.Role;
using escuelaAPI.Models;
using escuelaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using escuelaAPI.Models.DTO.Estado;

namespace escuelaAPI.Controllers
{
    [Route("api/estado")]
    [ApiController]
    public class EstadoAPIController : ControllerBase
    {
        private readonly IEstadoRepository _db;
        protected APIResponse _response;
        private readonly IMapper _mapper;

        public EstadoAPIController(IEstadoRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetRoles()
        {
            try
            {
                IEnumerable<Estado> value = await _db.GetAllAsync();

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
        [HttpGet("{id:int}", Name = "GetEstado")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetEstado(int id)
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateEstado([FromBody] EstadoCreateDTO value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest();
                }
                Estado model = _mapper.Map<Estado>(value);

                await _db.CreateAsync(model);

                _response.Result = model;
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetEstado", new { id = model.Id }, _response);
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
