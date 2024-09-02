using AutoMapper;
using escuelaAPI.Models;
using escuelaAPI.Models.DTO.Alumno;
using escuelaAPI.Models.DTO.Empleado;
using escuelaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace escuelaAPI.Controllers
{
    [Route("api/empleado")]
    [ApiController]
    public class EmpleadoAPIController : ControllerBase
    {
        private readonly IEmpleadoRepository _db;
        protected APIResponse _response;
        private readonly IMapper _mapper;

        public EmpleadoAPIController(IEmpleadoRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetEmpleados()
        {
            try
            {
                IEnumerable<Empleado> value = await _db.GetAllAsync();


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
        [HttpGet("{id:int}", Name = "GetEmpleado")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetEmpleado(int id)
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
        [HttpGet("director/{id:int}", Name = "GetDirector")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetDirector(int id)
        {
            try
            {

                var value = await _db.GetAsync(u => u.EscuelaId == id);
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

        [HttpGet("profesor/{id:int}", Name = "GetProfesor")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetProfesor(int id)
        {
            try
            {

                IEnumerable<Empleado> value = await _db.GetAllAsync();
                value = value.Where(u => u.GrupoId == id).Where(u => u.RoleId == 2);


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
        public async Task<ActionResult<APIResponse>> CreateEmpleado([FromBody] EmpleadoCreateDTO value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest();
                }
                Empleado model = _mapper.Map<Empleado>(value);

                await _db.CreateAsync(model);

                _response.Result = model;
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetEmpleado", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteEmpleado")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteEmpleado(int id)
        {
            try
            {
                var value = await _db.GetAsync(u => u.Id == id);
                if (value == null)
                {
                    return NotFound();
                }
                await _db.RemoveAsync(value);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
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
