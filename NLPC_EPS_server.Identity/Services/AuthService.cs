using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLPC_EPS_server.Application.Contracts.Identity;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Models.Identity;
using NLPC_EPS_server.Identity.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NLPC_EPS_server.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JWTSettings _jwtSettings;
        private readonly IPasswordHasher<AppUser> _hasher;

        public AuthService(
            UserManager<AppUser> userManager,
            IOptions<JWTSettings> jwtSettings,
            IPasswordHasher<AppUser> hasher,
            SignInManager<AppUser> signInManager
        )
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _hasher = hasher;
        }

        public async Task<AuthenticationResponse> Login(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new NotFoundExceptions($"Employee with {request.Email} not found.", request.Email);
            }

            //var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (user.PasswordHash is not null)
            {
                if (_hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) != PasswordVerificationResult.Success)
                {
                    throw new BadRequestExceptions($"Credentials for '{request.Email} aren't valid'.");
                }
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthenticationResponse
            {
                FullName = user.FullName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
            };

            return response;
        }


        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var profile = await _userManager.FindByNameAsync(request.Email);
            if (profile is not null) throw new BadRequestExceptions($"'{request.Email} already exist.'.");

            if (!await IsPasswordValid(request.Password))
                throw new BadRequestExceptions("Invalid password. Must be at least 6 characters, must have at least: one uppercase ('A'-'Z'), one digit ('0'-'9') and one non alphanumeric character..");

            var user = new AppUser
            {
                Email = request.Email,
                FullName = request.FullName,
                CompanyId = request.CompanyId
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Employee");
                return new RegistrationResponse() { EmployeeProfileEmail = user.Email };
            }
            else
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("•{0}\n", err.Description);
                }

                throw new BadRequestExceptions($"{str}");
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.CompanyId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("email", user.Email),
                new Claim("fullname", user.FullName)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
               signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        protected async Task<bool> IsPasswordValid(string password)
        {
            foreach (var passValidtor in _userManager.PasswordValidators)
                if (!(await passValidtor.ValidateAsync(_userManager, null, password)).Succeeded)
                    return false;

            return true;
        }

    }
}
