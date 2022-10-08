namespace GEPDA_API.Models.Services
{
    public interface IAspiranteService
    {
        public IQueryable<SedeProgramaAspirante> get();
        public IQueryable<SedeProgramaAspirante> get(int id);
        public IQueryable<SedeProgramaAspirante> gets(int id);
    }
}
