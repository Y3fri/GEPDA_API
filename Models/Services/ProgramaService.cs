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
        public IQueryable<SedePrograma> get(int id,int est)
        {
            return _context.SedeProgramas.Include(c => c.ProSedeNavigation).Where(c => c.ProId == id).Where(c => c.ProEstado == est).OrderByDescending(a => a.ProId);
        }
        public IQueryable<SedePrograma> gets(int id,int est)
        {
            return _context.SedeProgramas.Include(c => c.ProSedeNavigation).Where(c => c.ProSede == id).Where(c => c.ProEstado == est).OrderByDescending(a => a.ProId);
        }
        public IQueryable<SedePrograma> getis(int id, int est)
        {
            return _context.SedeProgramas.Include(c => c.ProSedeNavigation).Where(c => c.ProUniversidad == id).Where(c => c.ProEstado == est).OrderByDescending(a => a.ProId);
        }
    }
}
