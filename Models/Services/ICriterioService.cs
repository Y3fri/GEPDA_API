
namespace GEPDA_API.Models.Services
{
    public interface ICriterioService
    {
        public IQueryable<ProgramaCriterio> get();
        public IQueryable<ProgramaCriterio> get(int id);
        public IQueryable<ProgramaCriterio> gets(int id);

    }
}
