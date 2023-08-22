using GEPDA_API.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace GEPDA_API.Models.Services
{
    public class EntrevistaService :IEntrevistaService
    {
        private readonly GEPDA_BDContext _context;

        public EntrevistaService(GEPDA_BDContext context)
        {
            _context = context;
        }

        public IQueryable<Entrevistum> get(int id,int est)
        {
            return _context.Entrevista.Include(c => c.EntProgramaNavigation)                
                 .Where(c => c.EntSede == id).Where(c => c.EntEstado == est)
                 .OrderByDescending(a => a.EntId);
        }
        public IQueryable<Entrevistum> gets(int id,int est)
        {
            return _context.Entrevista.Include(c => c.EntProgramaNavigation)
          .Where(c => c.EntPrograma == id).Where(c=>c.EntEstado==est)
          .OrderByDescending(a => a.EntId);
        }

        public void Add(EntrevistaRequest oModel)
        {

            using (GEPDA_BDContext db = new GEPDA_BDContext())
            {

                try
                    {
                        var Ent = new Entrevistum();
                        Ent.EntUniversidad = oModel.EntUniversidad;
                        Ent.EntSede = oModel.EntSede;
                        Ent.EntPrograma = oModel.EntPrograma;
                        Ent.EntNombre=oModel.EntNombre;
                        Ent.EntDescripcion = oModel.EntDescripcion;
                        Ent.EntEstado = oModel.EntEstado;
                        db.Entrevista.Add(Ent);
                        db.SaveChanges();                                        
                    }
                    catch (Exception)
                    {

                    
                        throw new Exception("Ocurrio un error en la insercion");
                    }

                
            }

        }
        public void Edit(EntrevistaRequest oModel)
        {

            using (GEPDA_BDContext db = new GEPDA_BDContext())
            {

               
                    try
                    {
                        var Ent = new Entrevistum();
                        Ent.EntUniversidad = oModel.EntUniversidad;
                        Ent.EntSede = oModel.EntSede;
                        Ent.EntPrograma = oModel.EntPrograma;
                        Ent.EntNombre = oModel.EntNombre;
                        Ent.EntDescripcion = oModel.EntDescripcion;
                        Ent.EntEstado = oModel.EntEstado;
                        db.Entry(Ent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();                    
                    }
                    catch (Exception)
                    {

                     
                        throw new Exception("Ocurrio un error en la insercion");
                    

                }
            }

        }

    }
}
