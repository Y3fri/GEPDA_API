namespace GEPDA_API.Models.Services
{
    public interface ISsoUsuarioAgregarService
    {
        public IQueryable<SsoUsuario> get();
        public IQueryable<SsoUsuario> get(int id);


    }
}
