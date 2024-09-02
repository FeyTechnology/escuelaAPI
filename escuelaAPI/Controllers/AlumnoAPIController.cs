using AutoMapper;
using escuelaAPI.Models;
using escuelaAPI.Models.DTO.Alumno;
using escuelaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace escuelaAPI.Controllers
{
    [Route("api/alumno")]
    [ApiController]
    public class AlumnoAPIController : ControllerBase
    {
        private readonly IAlumnoRepository _db;
        protected APIResponse _response;
        private readonly IMapper _mapper;
        public AlumnoAPIController(IAlumnoRepository db, IMapper mapper) 
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet("grupo/{id:int}", Name = "GetGrupoAlumnos")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetGrupoAlumnos(int id)
        {
            try
            {
                IEnumerable<Alumno> value = await _db.GetAlumnoDetails();

                value = value.Where(u => u.GrupoId == id);

                _response.Result = _mapper.Map<List<AlumnoDetailDTO>>(value);
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
        [HttpGet("{id:int}", Name = "GetAlumno")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAlumno(int id)
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
        public async Task<ActionResult<APIResponse>> CreateNotification([FromBody] AlumnoCreateDTO value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest();
                }
                Alumno model = _mapper.Map<Alumno>(value);

                await _db.CreateAsync(model);

                _response.Result = model;
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetAlumno", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteAlumno")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteAlumno(int id)
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
        [HttpPut("{id:int}", Name = "UpdateAlumno")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateAlumno(int id, [FromBody] AlumnoUpdateDTO value)
        {
            try
            {
                if (value == null || id != value.Id)
                {
                    return BadRequest();
                }

                Alumno valueEditar = await _db.GetAsync(u => u.Id == id);

                if (valueEditar == null)
                {
                    return NotFound();
                }

                valueEditar = _mapper.Map(value, valueEditar);

                await _db.UpdateAsync(valueEditar);

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
