using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Controllers.Base;
using NewsWebsiteAPI.DataAccess.Services;
using NewsWebsiteAPI.Models.Dto.Accounts;
using NewsWebsiteAPI.Shared.Consts;
using NewsWebsiteAPI.Shared.Extensions;

namespace NewsWebsiteAPI.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController : BaseController
    {
        private IAccountService AccountService { get; }

        public AccountController(IAccountService accountService)
        {
            AccountService = accountService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn([FromBody] AuthenticationModel model)
            => await ExecuteAction(() => AccountService.LogInAsync(model));

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
            => await ExecuteAction(() => AccountService.RegisterAsync(model));

        [HttpGet]
        [Route("get_account")]
        [Authorize]
        public ActionResult<Guid> GetAccountData()
        {
            var id = Guid.Parse(User.GetClaim(AppClaimTypes.UserId).Value);

            return Ok(id);
        }
    }
}