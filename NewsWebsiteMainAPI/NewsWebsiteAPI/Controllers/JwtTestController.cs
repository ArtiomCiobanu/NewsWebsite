﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteAPI.Infrastructure.Enums;
using NewsWebsiteAPI.Infrastructure.Generators;
using NewsWebsiteAPI.Infrastructure.Handlers;
using NewsWebsiteAPI.Shared.Consts;
using NewsWebsiteAPI.Shared.Extensions;
using PolicyNames = NewsWebsiteAPI.Consts.PolicyNames;

namespace NewsWebsiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class JwtTestController : ControllerBase
    {
        private IJwtHandler JwtHandler { get; }
        private IJwtGenerator JwtGenerator { get; }

        public JwtTestController(IJwtHandler jwtHandler, IJwtGenerator jwtGenerator)
        {
            JwtHandler = jwtHandler;
            JwtGenerator = jwtGenerator;
        }

        [HttpGet]
        [Authorize(Policy = PolicyNames.RequireAdministratorRole)]
        public IActionResult AdminTest()
        {
            return Ok("You're an admin!");
        }

        [HttpGet]
        [Authorize]
        public IActionResult AuthorizeTest()
        {
            return Ok("You are authorized!");
        }

        [HttpGet]
        public IActionResult AnonymousTest()
        {
            return Ok("Hi!");
        }

        [HttpGet]
        public IActionResult GetUserToken()
        {
            return Ok(JwtGenerator.GenerateToken(Guid.NewGuid(), UserRole.User));
        }

        [HttpGet]
        public IActionResult GetAdminToken()
        {
            return Ok(JwtGenerator.GenerateToken(Guid.NewGuid(), UserRole.Admin));
        }

        [HttpGet]
        public IActionResult GetTokenData(string token)
        {
            var id = JwtHandler.GetUserIdFromToken(token);
            var role = JwtHandler.GetUserRoleFromToken(token);

            var result = $"ID: {id}\nRole: {role}";
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetUserId()
        {
            var user = User;
            var id = User.GetClaim(AppClaimTypes.UserId);

            return Ok();
        }
    }
}