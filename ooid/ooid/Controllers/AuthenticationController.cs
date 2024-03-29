﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ooid.Models;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ooid.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("~/connect/token")]
        [Consumes("application/x-www-form-urlencoded")]
        [Produces("application/json")]
        public async Task<IActionResult> Exchange()
        {
            var oidcRequest = HttpContext.GetOpenIddictServerRequest();
            if (oidcRequest.IsPasswordGrantType())
                return await TokensForPasswordGrantType(oidcRequest); 

            if (oidcRequest.IsRefreshTokenGrantType())
            {
                // return tokens for refresh token flow
            }

            if (oidcRequest.GrantType == "custom_flow_name")
            {
                // return tokens for custom flow
            }

            return BadRequest(new OpenIddictResponse
            {
                Error = OpenIddictConstants.Errors.UnsupportedGrantType
            });
        }


        [HttpGet("~/connect/logout")]
        public IActionResult Logout(OpenIddictRequest openIddictRequest)
        {
              _signInManager.SignOutAsync(); 
            return Ok();

        }
        private async Task<IActionResult> TokensForPasswordGrantType(OpenIddictRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
                return Unauthorized();

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (signInResult.Succeeded)
            {
                var identity = new ClaimsIdentity(
                    TokenValidationParameters.DefaultAuthenticationType,
                    OpenIddictConstants.Claims.Name,
                    OpenIddictConstants.Claims.Role);

                identity.AddClaim(OpenIddictConstants.Claims.Subject, user.Id.ToString(), OpenIddictConstants.Destinations.AccessToken);
                identity.AddClaim(OpenIddictConstants.Claims.Username, user.Username, OpenIddictConstants.Destinations.AccessToken);
                // Add more claims if necessary

                foreach (var userRole in user.UserRoles)
                {
                    identity.AddClaim(OpenIddictConstants.Claims.Role, userRole.Role.NormalizedName, OpenIddictConstants.Destinations.AccessToken);
                }

                var claimsPrincipal = new ClaimsPrincipal(identity);
                claimsPrincipal.SetScopes(new string[]
                {
                    OpenIddictConstants.Scopes.Roles,
                    OpenIddictConstants.Scopes.OfflineAccess,
                    OpenIddictConstants.Scopes.Email,
                    OpenIddictConstants.Scopes.Profile,
                });

                return SignIn(claimsPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }
            else
                return Unauthorized();
        }
    }
}
