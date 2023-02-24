using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using VentasSofttek.DAL.DBContext;
using VentasSofttek.Models.Common;
using VentasSofttek.Models.Login;
using VentasSofttek.Models.Response;

namespace VentasSofttek.DTO.Service
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private VentasSofttekDBContext _context;

        public UserService(IOptions<AppSettings> options, VentasSofttekDBContext context)
        {
            _appSettings = options.Value;
            _context = context;
        }
        


        public MUserResponse Autch(AuthRequest request)
        {
            MUserResponse response = new MUserResponse();
            using (var db=_context)
            {
                string Password=request.Password;
                var usuario = db.MUsers.Where(d=>d.Email==request.Email &&
           
                d.Password==request.Password).FirstOrDefault();
                if (usuario==null)
                {
                    return null;
                }
                response.Email =usuario.Email;
                response.token = getToken(request);
            }
            return response;
        }
        private string getToken(AuthRequest auth)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, auth.ID.ToString()),
                        new Claim(ClaimTypes.Email, auth.Email),
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(llave),SecurityAlgorithms.HmacSha256
                    )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
