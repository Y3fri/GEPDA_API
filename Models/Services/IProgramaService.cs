namespace GEPDA_API.Models.Services
{
    public interface IProgramaService
    {
        public IQueryable<SedePrograma> get();
        public IQueryable<SedePrograma> get(int id);
        public IQueryable<SedePrograma> gets(int id);
    }
}
