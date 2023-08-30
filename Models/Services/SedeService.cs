using Microsoft.EntityFrameworkCore;

namespace GEPDA_API.Models.Services
{
    public class SedeService :ISedeService
    {
        private readonly GEPDA_BDContext _context;

        public SedeService(GEPDA_BDContext context)
        {
            _context = context;
        }
        public IQueryable<UniversidadSede> get()
        {
            return _context.UniversidadSedes.Include(c => c.SedUniversidadNavigation).OrderByDescending(a => a.SedId);
        }
        public IQueryable<UniversidadSede> get(int id,int est)
        {
            return _context.UniversidadSedes.Where(c=>c.SedId==id).Where(c=>c.SedEstado==est).OrderByDescending(a => a.SedId);
        }
        public IQueryable<UniversidadSede> gets(int id,int est)
        {
            return _context.UniversidadSedes.Where(c => c.SedUniversidad == id).Where(c => c.SedEstado == est).OrderByDescending(a => a.SedId);
        }
    }
}
