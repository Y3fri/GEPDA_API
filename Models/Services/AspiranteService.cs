using Microsoft.EntityFrameworkCore;

namespace GEPDA_API.Models.Services
{
    public class AspiranteService :IAspiranteService
    {
        private readonly GEPDA_BDContext _context;

        public AspiranteService(GEPDA_BDContext context)
        {
            _context = context;
        }
        public IQueryable<SedeProgramaAspirante> get()
        {
            return _context.SedeProgramaAspirantes.Include(c => c.AspMunicipioNavigation)
                .Include(c=>c.AspDniNavigation)
                .Include(c=>c.AspSedeNavigation)
                .Include(c=>c.AspProgramaNavigation)
                .OrderByDescending(a => a.AspId);
        }
        public IQueryable<SedeProgramaAspirante> get(int id)
        {
            return _context.SedeProgramaAspirantes.Include(c => c.AspMunicipioNavigation)
                 .Include(c => c.AspDniNavigation)
                 .Include(c => c.AspSedeNavigation)
                 .Include(c => c.AspProgramaNavigation)
                 .Where(c=>c.AspSede==id)
                 .OrderByDescending(a => a.AspId);
        }
        public IQueryable<SedeProgramaAspirante> gets(int id)
        {
            return _context.SedeProgramaAspirantes.Include(c => c.AspMunicipioNavigation)
                 .Include(c => c.AspDniNavigation)
                 .Include(c => c.AspSedeNavigation)
                 .Include(c => c.AspProgramaNavigation)
                 .Where(c => c.AspPrograma == id)
                 .OrderByDescending(a => a.AspId);
        }
    }
}
