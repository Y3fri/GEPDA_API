using Microsoft.EntityFrameworkCore;

namespace GEPDA_API.Models.Services
{
    public class MunicipioService : IMunicipioService
    {
        private readonly GEPDA_BDContext _context;

        public MunicipioService(GEPDA_BDContext context)
        {
            _context = context;
        }
        public IQueryable<DepartamentoMunicipio> get()
        {
            return _context.DepartamentoMunicipios.Include(c => c.MunDepNavigation).OrderByDescending(a => a.MunId);
        }
    }
}
