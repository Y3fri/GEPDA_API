namespace GEPDA_API.Models.Services
{
    public interface ISedeService
    {

        public IQueryable<UniversidadSede> get();
        public IQueryable<UniversidadSede> get(int id);
        public IQueryable<UniversidadSede> gets(int id);
    }
}
