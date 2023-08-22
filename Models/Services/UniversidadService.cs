using Microsoft.EntityFrameworkCore;

namespace GEPDA_API.Models.Services
{
    public class UniversidadService : IUniversidadService
    {
        private readonly GEPDA_BDContext _context;

        public UniversidadService(GEPDA_BDContext context)
        {
            _context = context;
        }
        public IQueryable<InformacionUniversidad> get()
        {
            return _context.InformacionUniversidads.Include(c => c.UniMunicipioNavigation).OrderByDescending(a => a.UniId);
        }
        public IQueryable<InformacionUniversidad> get(int id)
        {
            return _context.InformacionUniversidads.Include(c => c.UniMunicipioNavigation).Where(c=>c.UniId==id).OrderByDescending(a => a.UniId);
        }
    }
}
