namespace GEPDA_API.Models.Services
{
    public interface IUniversidadService
    {
        public IQueryable<InformacionUniversidad> get();
        public IQueryable<InformacionUniversidad> get(int id);
    }
}
