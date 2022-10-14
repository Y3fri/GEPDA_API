using System.ComponentModel.DataAnnotations;

namespace GEPDA_API.Models.Request
{
    public class SsoUsuProfeRequest
    {

        [Required]
        public string UsuNickname { get; set; }

        [Required]
        public string UsuClave { get; set; }

    }
}
