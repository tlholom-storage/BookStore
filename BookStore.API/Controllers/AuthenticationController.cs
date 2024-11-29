using BookStore.Models.DataTransferObjects;
using BookStore.Models.Interfaces;
using BookStore.Utility;
using BookStore.Utility.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthenticationController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userRepository.GetUserByUsernameAsync(model.Username);

            if (user != null && PasswordHasher.VerifyPassword(model.Password, user.password_hash, user.password_salt))
            {
                var token = TokenService.GenerateToken(user);
                var userdto = _mapper.MapUserToUserDto(user);
                userdto.PasswordHash = userdto.PasswordSalt = new byte[64];
                return Ok(new { User = userdto, Token = token });
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {

            model.PasswordHash = PasswordHasher.HashPasword(model.Password, out var salt);
            model.PasswordSalt = salt;
            var user = _mapper.MapUserDtoToUser(model);
            var result = await _userRepository.CreateUserAsync(user);

            if (result > 0)
            {
                var token = TokenService.GenerateToken(user);
                model.PasswordHash = model.PasswordSalt = new byte[64];
                return Ok(new { User = model, Token = token });
            }

            return BadRequest(new { message = "Failed to register" });

        }
    }
}
