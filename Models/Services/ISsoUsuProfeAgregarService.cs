namespace GEPDA_API.Models.Services
{
    public interface ISsoUsuProfeAgregarService
    {
        public IQueryable<SsoUsuProfe> get();
        public IQueryable<SsoUsuProfe> get(int id);

    }
}
