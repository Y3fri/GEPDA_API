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
            return _context.ProgramaCriterios.Include(c => c.CriProgramaNavigation)
                  .Include(c => c.CriSedeNavigation).OrderByDescending(a => a.CriId);
        }
        public IQueryable<ProgramaCriterio> get(int id)
        {
            return _context.ProgramaCriterios.Include(c => c.CriProgramaNavigation)
                .Include(c=>c.CriSedeNavigation).Where(c => c.CriPrograma == id).OrderByDescending(a => a.CriId);

        }
        public IQueryable<ProgramaCriterio> gets(int id)
        {
            return _context.ProgramaCriterios.Include(c => c.CriProgramaNavigation)
                  .Include(c => c.CriSedeNavigation).Where(c => c.CriSede == id).OrderByDescending(a => a.CriId);
        }
    }
}
