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
            },
        IdEntrevistaNavigation = new Entrevistum
        {
                EntNombre = c.IdEntrevistaNavigation.EntNombre,
                EntDescripcion=c.IdEntrevistaNavigation.EntDescripcion,
                
            }
    });

        }

        public IQueryable<AspiranteEntrevistum> Gets(int idAspirante)
        {
            return _context.AspiranteEntrevista
    .Where(c => c.IdAspirante == idAspirante)    
    .OrderByDescending(c => c.Id)
    .Select(c => new AspiranteEntrevistum
    {
        Id =c.Id,
        IdAspirante = c.IdAspirante,
        IdEntrevista = c.IdEntrevista,
        Nota = c.Nota,
        FechaEntre=c.FechaEntre,
        IdAspiranteNavigation = new SedeProgramaAspirante
        {
        },
        IdEntrevistaNavigation = new Entrevistum
        {
            EntNombre = c.IdEntrevistaNavigation.EntNombre,
            EntDescripcion = c.IdEntrevistaNavigation.EntDescripcion,

        }
    });

        }
    }
}
