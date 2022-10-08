using Microsoft.EntityFrameworkCore;

namespace GEPDA_API.Models.Services
{
    public class CriterioService : ICriterioService
    {
        private readonly GEPDA_BDContext _context;

        public CriterioService(GEPDA_BDContext context)
        {
            _context = context;
        }
        public IQueryable<ProgramaCriterio> get()
        {
            return _context.ProgramaCriterios.Include(c => c.CriProgramaNavigation).OrderByDescending(a => a.CriId);
        }
        public IQueryable<ProgramaCriterio> get(int id)
        {
            return _context.ProgramaCriterios.Include(c => c.CriProgramaNavigation).Where(c=>c.CriPrograma==id).OrderByDescending(a => a.CriId);
        }
    }
}
