using GEPDA_API.Models.Request;
using GEPDA_API.Models.Response;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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
        public IQueryable<InformacionUniversidad> get(int id,int est)
        {
            return _context.InformacionUniversidads.Include(c => c.UniMunicipioNavigation).Where(c=>c.UniId==id).Where(c=>c.UniEstado==est).OrderByDescending(a => a.UniId);
        }
        public void Add(UniversidadRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    InformacionUniversidad oIU = new InformacionUniversidad();
                    oIU.UniMunicipio = oModel.UniMunicipio;
                    oIU.UniNombre = oModel.UniNombre;
                    oIU.UniEmailPrincipal = oModel.UniEmailPrincipal;
                    oIU.UniDireccionPrincipal = oModel.UniDireccionPrincipal;
                    oIU.UniTelefonoPrincipal = oModel.UniTelefonoPrincipal;
                    db.SaveChanges();
                    if (!string.IsNullOrEmpty(oModel.UniLogo))
                    {
                        string base64String = oModel.UniLogo;
                        base64String = Regex.Replace(base64String, @"[^A-Za-z0-9\+\/=]", "");
                        byte[] bytes = Convert.FromBase64String(base64String);
                        var fileName = Guid.NewGuid().ToString() + ".jpeg";
                        var universidadFolderPath = Path.Combine("Images", oModel.UniNombre.ToString());
                        var LogoFolderPath = Path.Combine(universidadFolderPath, "Logo");
                        Directory.CreateDirectory(LogoFolderPath);
                        var filePath = Path.Combine(LogoFolderPath, fileName);
                        File.WriteAllBytes(filePath, bytes);
                        oIU.UniLogo = Path.Combine(oModel.UniNombre.ToString(), "Logo", fileName);
                    };
                    oIU.UniEstado = oModel.UniEstado;
                    db.InformacionUniversidads.Add(oIU);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
        
        
    }
        public void Edit(UniversidadRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (GEPDA_BDContext db = new GEPDA_BDContext())
                {
                    InformacionUniversidad oIU = db.InformacionUniversidads.Find(oModel.UniId);
                    oIU.UniMunicipio = oModel.UniMunicipio;
                    oIU.UniNombre = oModel.UniNombre;
                    oIU.UniEmailPrincipal = oModel.UniEmailPrincipal;
                    oIU.UniDireccionPrincipal = oModel.UniDireccionPrincipal;
                    oIU.UniTelefonoPrincipal = oModel.UniTelefonoPrincipal;
                    var universidad = db.InformacionUniversidads.FirstOrDefault(r => r.UniId == oIU.UniId);
                    string uniId = universidad.UniNombre;
                    if (!string.IsNullOrEmpty(oModel.UniLogo) && oModel.UniLogo != oIU.UniLogo) // Verificar si se ha seleccionado una nueva imagen
                    {
                        string base64String = oModel.UniLogo;
                        base64String = Regex.Replace(base64String, @"[^A-Za-z0-9\+\/=]", "");
                        byte[] bytes = Convert.FromBase64String(base64String);
                        var fileName = Guid.NewGuid().ToString() + ".jpeg";
                        var universidadFolderPath = Path.Combine("Images", uniId.ToString());
                        var LogoFolderPath = Path.Combine(universidadFolderPath, "Logo");
                        Directory.CreateDirectory(LogoFolderPath);
                        var existingFiles = Directory.GetFiles(LogoFolderPath);
                        foreach (var file in existingFiles)
                        {
                            File.Delete(file);
                        }
                        var filePath = Path.Combine(LogoFolderPath, fileName);
                        File.WriteAllBytes(filePath, bytes);
                        oIU.UniLogo = Path.Combine(uniId.ToString(), "Logo", fileName);
                    }
                    oIU.UniEstado = oModel.UniEstado;
                    db.Entry(oIU).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }         
        
    }
        }
}
