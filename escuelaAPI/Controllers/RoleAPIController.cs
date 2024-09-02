using AutoMapper;
using escuelaAPI.Models;
using escuelaAPI.Models.DTO.Empleado;
using escuelaAPI.Models.DTO.Role;
using escuelaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace escuelaAPI.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleAPIController : ControllerBase
    {
        private readonly IRoleRepository _db;
        protected APIResponse _response;
        private readonly IMapper _mapper;

        public RoleAPIController(IRoleRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetRoles([FromQuery] string? search, int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                IEnumerable<Role> value = await _db.GetAllAsync(pageSize: pageSize,
                pageNumber: pageNumber);

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
        [HttpGet("{id:int}", Name = "GetRole")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetRole(int id)
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
        public async Task<ActionResult<APIResponse>> CreateRole([FromBody] RoleCreateDTO value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest();
                }
                Role model = _mapper.Map<Role>(value);

                await _db.CreateAsync(model);

                _response.Result = model;
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetRole", new { id = model.Id }, _response);
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
