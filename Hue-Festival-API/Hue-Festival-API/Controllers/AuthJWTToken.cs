using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthJWTTokenController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IUserService userService;
        private readonly IConfiguration configuration;
        private readonly IMemoryCache cache;

        public AuthJWTTokenController(IEmployeeService _employeeService, IUserService _userService, 
                                        IConfiguration _configuration, IMemoryCache _cache)
        {
            employeeService = _employeeService;
            userService = _userService;
            configuration = _configuration;
            cache = _cache;
        }

        [HttpPost("user_login")]
        public async Task<IActionResult> UserLogin(UserVM_Login input)
        {
            var user = await userService.GetByPhone(input.PhoneNumber);

            if (user == null)
                return BadRequest("Số điện thoại không đúng");

            if (user.Password != input.Password)
                return BadRequest("Mật khẩu sai");

            var jwt = GenerateToken(user);

            return Ok(new { Message = "Đăng nhập thành công", JWT = jwt });
        }

        [HttpPost("employee_login")]
        public async Task<IActionResult> EmployeeLogin(EmployeeVM_Login input)
        {
            var employee = await employeeService.LoginAsync(input.PhoneNumber, input.Password);

            if (employee == null)
                return BadRequest("Số điện thoại hoặc mật khẩu sai");

            if (employee.Activate == false)
                return BadRequest("Tài khoản chưa kích hoạt, vui lòng kích hoạt tài khoản trước");

            var jwt = GenerateToken(employee);

            return Ok(new { Message = "Đăng nhập thành công", JWT = jwt });
        }

        [HttpGet("get_otp")]
        public async Task<IActionResult> GetOTP()
            => Ok(new { OTP = GenerateOTP() });

        [HttpPost("employee_activate_account")]
        public async Task<IActionResult> ActivateAccount(EmployeeVM_Activate input)
        {
            if(!CheckOTP(input.OTP))
                return BadRequest("Mã OTP không hợp lệ");

            if (await employeeService.ActivateAsync(input.PhoneNumber))
                return Ok("Kích hoạt tài khoản thành công");

            return BadRequest("Kích hoạt tài khoản thất bại");
        }

        private bool CheckOTP(int otp)
        {
            if (!cache.TryGetValue(otp, out var result))
            {
                return false;
            }

            int cacheOTP = cache.Get<int>(otp);

            if (cacheOTP != otp)
                return false;

            return true;
        }

        private int GenerateOTP()
        {
            Random rd = new Random();

            int otp = rd.Next(10000, 99999);

            var cacheExprityOption = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(1)
            };

            cache.Set<int>(otp, otp, cacheExprityOption);

            return otp;
        }

        private string GenerateToken(dynamic obj)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("SecretKey").Value));

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", obj.Id.ToString()),
                    new Claim(ClaimTypes.Name, obj.Name),
                    new Claim("phone", obj.PhoneNumber),
                    new Claim(ClaimTypes.Role, obj.Role)
                }),

                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = signinCredentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);

            return accessToken;
        }
    }
}
