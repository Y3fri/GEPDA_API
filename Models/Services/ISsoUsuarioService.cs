﻿using GEPDA_API.Models.Request;
using GEPDA_API.Models.Response;

namespace GEPDA_API.Models.Services
{
    public interface ISsoUsuarioService
    {
        UserResponse Auth(SsoUsuarioRequest usuario);
    }
}
