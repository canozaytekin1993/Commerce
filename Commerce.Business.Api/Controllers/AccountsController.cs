using System.Security.Claims;
using System.Threading.Tasks;
using Commerce.Business.Api.Extensions;
using Commerce.Business.Api.Models;
using Commerce.Contracts.Factories;
using Commerce.Domain.Configurations.Auth;
using Commerce.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Commerce.Business.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly JwtIssuerOptions _options;
        private readonly ITokenFactory _tokenFactory;
        private readonly UserManager<Person> _userManager;

        public AccountsController(UserManager<Person> userManager, ITokenFactory tokenFactory, JwtIssuerOptions options)
        {
            _userManager = userManager;
            _tokenFactory = tokenFactory;
            _options = options;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await GetClaimsIdentity(model.Username, model.Password);
            if (user == null)
                return BadRequest(ResponseExtensions.Errors.AddErrorModelState("login_failure",
                    "Invalid password or username", ModelState));

            var token = await TokenExtensions.GenerateJwtTokenAsync(user, _tokenFactory, model.Username, _options,
                new JsonSerializerSettings {Formatting = Formatting.Indented});
            return new ObjectResult(token);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid && model.Password != model.ConfirmPassword) return BadRequest(ModelState);
            var userIdentity = new Person
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                SurName = model.SurName
            };
            var result = await _userManager.CreateAsync(userIdentity, model.Password);
            if (!result.Succeeded)
                return new BadRequestObjectResult(ResponseExtensions.Errors.AddErrorModelState(result, ModelState));
            return new OkObjectResult("New person added successfully");
        }

        public async Task<ClaimsIdentity> GetClaimsIdentity(string username, string password)
        {
            if (!(string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password)))
                return await Task.FromResult<ClaimsIdentity>(null);

            var user = await _userManager.FindByEmailAsync(username);
            if (user == null) return await Task.FromResult<ClaimsIdentity>(null);

            if (await _userManager.CheckPasswordAsync(user, password))
                return await Task.FromResult(_tokenFactory.GenerateuserIdentity(username, user.Id));

            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}