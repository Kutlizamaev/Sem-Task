using CarFleet.BLL.DTO;
using CarFleet.BLL.Requests;
using CarFleet.BLL.Responses;
using CarFleet.BLL.Services;
using CarFleet.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarFleet.API.Controllers
{
    [Route("api/account/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtService _jwtService;
        private readonly OrdersService _ordersService;
        private readonly EmailService _emailService;

        public UserController(UserManager<User> userManager, JwtService jwtService, OrdersService ordersService, EmailService emailService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _ordersService = ordersService;
            _emailService = emailService;
        }

        //GET: api/account/get
        [Authorize]
        [HttpGet("get")]
        public async Task<IActionResult> GetUserById(string id)
        {
            if(id == null)
            {
                return BadRequest("User not found");
            }
            User user = await _userManager.FindByIdAsync(id);
            return Ok(user);
        }

        //GET: api/account/orders/{id}
        [Authorize]
        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders(string id)
        {
            if(id == null)
            {
                return BadRequest("User not found");
            }

            List<BookingOrderDTO> orders = await _ordersService.GetOrdersByUserId(id);
            return Ok(orders);
        }

        [HttpGet("confirmemail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            if (user.EmailConfirmed == true)
            {
                return BadRequest("Email is already confirmed");
            }

            user.EmailConfirmed = true;

            await _userManager.UpdateAsync(user);

            return Ok("Email is confirmed");
        }

        //POST: api/account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data is invalid");
            }

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return BadRequest("Email is invalid");
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                return BadRequest("Email is not confirmed");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Password is invalid");
            }

            var token = await _jwtService.Createtoken(user);

            return Ok(token);
        }

        //POST: api/account/register
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromForm] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data is invalid");
            }

            var userExists = await _userManager.FindByNameAsync(request.Username);

            if (userExists != null)
                return BadRequest("User already exists!");

            User user = new User()
            {
                FullName = request.FullName,
                UserName = request.Username,
                Email = request.Email,
                Address = request.Address,
                BirthDate = TimeZoneInfo.ConvertTimeToUtc(request.BirthDate),
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return BadRequest("Failed to register");
            }

            await _emailService.SendEmailAsync(request.Email, user.Id);

            return Ok("To complete your registration, check your email and follow the link to confirm your account");
        }

        
    }
}
