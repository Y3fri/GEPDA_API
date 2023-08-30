namespace GEPDA_API.Models.Services
{
    public interface ISsoUsuarioAgregarService
    {
        public IQueryable<SsoUsuario> get();
        public IQueryable<SsoUsuario> get(int id);
        public IQueryable<SsoUsuario> gets(int id,int est);
        public IQueryable<SsoUsuario> getis(int id, int est);

    }
}
