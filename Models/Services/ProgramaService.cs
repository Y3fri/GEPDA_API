using Microsoft.EntityFrameworkCore;

namespace GEPDA_API.Models.Services
{
    public class ProgramaService :IProgramaService
    {
        private readonly GEPDA_BDContext _context;

        public ProgramaService(GEPDA_BDContext context)
        {
            _context = context;
        }
        public IQueryable<SedePrograma> get()
        {
            return _context.SedeProgramas.Include(c => c.ProSedeNavigation).OrderByDescending(a => a.ProId);
        }
        public IQueryable<SedePrograma> get(int id)
        {
            return _context.SedeProgramas.Include(c => c.ProSedeNavigation).Where(c => c.ProId == id).OrderByDescending(a => a.ProId);
        }
        public IQueryable<SedePrograma> gets(int id)
        {
            return _context.SedeProgramas.Include(c => c.ProSedeNavigation).Where(c => c.ProSede == id).OrderByDescending(a => a.ProId);
        }
    }
}
