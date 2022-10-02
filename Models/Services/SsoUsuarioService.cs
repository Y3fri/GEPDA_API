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
        public class SsoUsuarioService : ISsoUsuarioService
        {

            private readonly AppSettings _appSettings;

            public SsoUsuarioService(IOptions<AppSettings> appSettings)
            {
                _appSettings = appSettings.Value;
            }

            public UserResponse Auth(SsoUsuarioRequest model)
            {
                UserResponse userresponse = new UserResponse();
                using (var db = new GEPDA_BDContext())
                {
                    string spassword = Encrypt.GetSHA256(model.UsuClave);
                    var usuario = db.SsoUsuarios.Where(d => d.UsuNickname == model.UsuNickname &&
                                                   d.UsuClave == spassword).FirstOrDefault();
                    if (usuario == null) return null;

                    userresponse.UsuNickname = usuario.UsuNickname;
                    userresponse.Token = GetToken(usuario);
                    userresponse.UsuRol = usuario.UsuRol;
                    userresponse.UsuUniversidad = usuario.UsuUniversidad;
                    userresponse.UsuSede = usuario.UsuSede;

                }
                return userresponse;

            }

            private string GetToken(SsoUsuario usuario)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                        new Claim(ClaimTypes.NameIdentifier,usuario.UsuId.ToString()),
                         new Claim(ClaimTypes.Email,usuario.UsuNickname),
                         new Claim(ClaimTypes.Role,usuario.UsuRol.ToString()),
                         new Claim(ClaimTypes.Role,usuario.UsuUniversidad.ToString()),
                          new Claim(ClaimTypes.Country,usuario.UsuSede.ToString())

                        }
                        ),
                    Expires = DateTime.UtcNow.AddDays(60),
                    SigningCredentials =
                        new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
        }
}
