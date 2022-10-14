using Microsoft.EntityFrameworkCore;

namespace GEPDA_API.Models.Services
{
    public class SsoUsuProfeAgregarService : ISsoUsuProfeAgregarService
    {
        private readonly GEPDA_BDContext _context;

        public SsoUsuProfeAgregarService(GEPDA_BDContext context)
        {
            _context = context;
        }
        public IQueryable<SsoUsuProfe> get()
        {

            return _context.SsoUsuProves
                .Include(c => c.UsuPProgramaNavigation)
                .Include(c => c.UsuPSedeNavigation).OrderByDescending(a => a.UsuPId);
        }
        public IQueryable<SsoUsuProfe> get(int id)
        {

            return _context.SsoUsuProves.Include(c => c.UsuPProgramaNavigation)
                .Include(c => c.UsuPSedeNavigation).Where(c => c.UsuPSede == id).OrderByDescending(a => a.UsuPId);
        }

    }
}
