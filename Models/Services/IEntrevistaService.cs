using GEPDA_API.Models.Request;

namespace GEPDA_API.Models.Services
{
    public interface IEntrevistaService
    {
        public IQueryable<Entrevistum> get(int id,int est);
        public IQueryable<Entrevistum> gets(int id, int est);
        public void Add(EntrevistaRequest oModel);
        public void Edit(EntrevistaRequest oModel);
    }
}
