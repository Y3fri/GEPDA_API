using Microsoft.EntityFrameworkCore;

namespace GEPDA_API.Models.Services
{
    public class AspiranteEntrevista:IAspiranteEntrevista
    {
        private readonly GEPDA_BDContext _context;

        public AspiranteEntrevista(GEPDA_BDContext context)
        {
            _context = context;
        }
        public IQueryable<AspiranteEntrevistum> Get(int id,int est)
        {
            return _context.AspiranteEntrevista
    .Where(c => c.IdEntrevistaNavigation.EntPrograma == id)
    .Where(c => c.IdEntrevistaNavigation.EntEstado == est)
    .OrderByDescending(c => c.Id)
    .Select(c => new AspiranteEntrevistum
    {
        IdAspirante = c.IdAspirante,
        IdEntrevista = c.IdEntrevista,
        Nota = c.Nota,
        IdAspiranteNavigation = new SedeProgramaAspirante
        {
                AspNombres = c.IdAspiranteNavigation.AspNombres,
                AspApellidos = c.IdAspiranteNavigation.AspApellidos,
                AspTelefono = c.IdAspiranteNavigation.AspTelefono,
                AspFecha=c.IdAspiranteNavigation.AspFecha,
                AspPromedioEntrevista=c.IdAspiranteNavigation.AspPromedioEntrevista
            },
        IdEntrevistaNavigation = new Entrevistum
        {
                EntNombre = c.IdEntrevistaNavigation.EntNombre,
                EntDescripcion=c.IdEntrevistaNavigation.EntDescripcion,
                
            }
    });

        }

    
    }
}
