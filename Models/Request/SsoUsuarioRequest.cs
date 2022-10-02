using System.ComponentModel.DataAnnotations;

namespace GEPDA_API.Models.Request
{
    public class SsoUsuarioRequest
    {
        [Required]
        public string UsuNickname { get; set; }

        [Required]
        public string UsuClave { get; set; }
       
    }
}
