using Microsoft.EntityFrameworkCore;

namespace GEPDA_API.Models.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly GEPDA_BDContext _context;

        public DepartamentoService(GEPDA_BDContext context)
        {
            _context = context;
        }
        public IQueryable<PaisDepartamento> get()
        {
            return _context.PaisDepartamentos.Include(c => c.DepPaisNavigation).OrderByDescending(a => a.DepId);
        }
    }
}
