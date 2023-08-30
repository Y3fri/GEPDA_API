using Microsoft.EntityFrameworkCore;

namespace GEPDA_API.Models.Services
{
    public class SsoUsuarioAgregarService : ISsoUsuarioAgregarService
    {
        private readonly GEPDA_BDContext _context;

        public SsoUsuarioAgregarService(GEPDA_BDContext context)
        {
            _context = context;
        }
        public IQueryable<SsoUsuario> get()
        {

            return _context.SsoUsuarios.Include(c => c.UsuRolNavigation)
                .Include(c => c.UsuUniversidadNavigation)
                .Include(c => c.UsuSedeNavigation).OrderByDescending(a => a.UsuId);
        }
        public IQueryable<SsoUsuario> get(int id)
        {

            return _context.SsoUsuarios.Include(c => c.UsuRolNavigation)
                .Include(c => c.UsuUniversidadNavigation)
                .Include(c => c.UsuSedeNavigation).Where(c => c.UsuUniversidad == id).OrderByDescending(a => a.UsuId);
        }
        public IQueryable<SsoUsuario> gets(int id,int est)
        {

            return _context.SsoUsuarios
                .Include(c => c.UsuSedeNavigation)
                .Include(c => c.UsuProgramaNavigation).Where(c => c.UsuUniversidad == id).Where(c => c.UsuEstado== est).OrderByDescending(a => a.UsuId);
        }

        public IQueryable<SsoUsuario> getis(int id, int est)
        {

            return _context.SsoUsuarios                
                .Include(c => c.UsuProgramaNavigation).Where(c => c.UsuPrograma == id).Where(c => c.UsuEstado == est).OrderByDescending(a => a.UsuId);
        }
    }
}

