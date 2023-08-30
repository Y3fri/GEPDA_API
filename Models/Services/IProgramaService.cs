namespace GEPDA_API.Models.Services
{
    public interface IProgramaService
    {
        public IQueryable<SedePrograma> get();
        public IQueryable<SedePrograma> get(int id, int est);
        public IQueryable<SedePrograma> gets(int id, int est);
        public IQueryable<SedePrograma> getis(int id, int est);
    }
}
