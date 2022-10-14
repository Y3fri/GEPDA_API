using GEPDA_API.Models.Common;
using GEPDA_API.Models.Request;
using GEPDA_API.Models.Response;
using GEPDA_API.Models.Tools;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GEPDA_API.Models.Services
{
    public class SsoUsuProfeService :ISsoUsuProfeService
    {
       

            private readonly AppSettings _appSettings;

            public SsoUsuProfeService(IOptions<AppSettings> appSettings)
            {
                _appSettings = appSettings.Value;
            }

            public UserProfeResponse Auth(SsoUsuProfeRequest model)
            {
                UserProfeResponse userresponse = new UserProfeResponse();
                using (var db = new GEPDA_BDContext())
                {
                    string spassword = Encrypt.GetSHA256(model.UsuClave);
                    var usuarios = db.SsoUsuProves.Where(d => d.UsuPNickname == model.UsuNickname &&
                                                   d.UsuPClave == spassword).FirstOrDefault();
                    if (usuarios == null) return null;

                    userresponse.UsuPNickname = usuarios.UsuPNickname;
                    userresponse.Token = GetTokens(usuarios);
                    
                    userresponse.UsuPPrograma = usuarios.UsuPPrograma;
                    userresponse.UsuPSede = usuarios.UsuPSede;

                }
                return userresponse;

            }

            private string GetTokens(SsoUsuProfe usuarios)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                        new Claim(ClaimTypes.NameIdentifier,usuarios.UsuPId.ToString()),
                         new Claim(ClaimTypes.Email,usuarios.UsuPNickname),                         
                         new Claim(ClaimTypes.Role,usuarios.UsuPPrograma.ToString()),
                          new Claim(ClaimTypes.Role,usuarios.UsuPSede.ToString())

                        }
                        ),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials =
                        new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
        }
    }

