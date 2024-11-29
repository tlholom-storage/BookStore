using BookStore.Models.DataTransferObjects;
using BookStore.Models.Interfaces;
using BookStore.Utility.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;

        public UserTypesController(IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            _userTypeRepository = userTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTypeDto>>> GetAllUserTypes()
        {
            var userTypes = await _userTypeRepository.GetAllUserTypesAsync();
            return Ok(userTypes.Select(ut => _mapper.MapUserTypeToUserTypeDto(ut)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTypeDto>> GetUserTypeById(int id)
        {
            var userType = await _userTypeRepository.GetUserTypeByIdAsync(id);

            if (userType == null)
            {
                return NotFound();
            }

            return Ok(_mapper.MapUserTypeToUserTypeDto(userType));
        }

        [HttpPost]
        public async Task<ActionResult<UserTypeDto>> CreateUserType(UserTypeDto userTypedto)
        {
            var userType = _mapper.MapUserTypeDtoToUserType(userTypedto);
            await _userTypeRepository.CreateUserTypeAsync(userType);

            return CreatedAtAction("GetUserTypeById", new { id = userType.user_type_id }, _mapper.MapUserTypeToUserTypeDto(userType));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserType(int id, UserTypeDto userTypedto)
        {
            if (id != userTypedto.UserTypeId)
            {
                return BadRequest();
            }

            var userType = _mapper.MapUserTypeDtoToUserType(userTypedto);
            await _userTypeRepository.UpdateUserTypeAsync(userType);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserType(int id)
        {
            await _userTypeRepository.DeleteUserTypeAsync(id);
            return NoContent();
        }
    }
}