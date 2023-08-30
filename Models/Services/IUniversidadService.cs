using GEPDA_API.Models.Request;

namespace GEPDA_API.Models.Services
{
    public interface IUniversidadService
    {
        public IQueryable<InformacionUniversidad> get();
        public IQueryable<InformacionUniversidad> get(int id,int est);
        public void Add(UniversidadRequest Model);
        public void Edit(UniversidadRequest Model);
    }
}
