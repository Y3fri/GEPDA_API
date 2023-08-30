namespace GEPDA_API.Models.Services
{
    public interface ISedeService
    {

        public IQueryable<UniversidadSede> get();
        public IQueryable<UniversidadSede> get(int id,int est);
        public IQueryable<UniversidadSede> gets(int id,int est);
    }
}
