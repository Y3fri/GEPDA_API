﻿namespace GEPDA_API.Models.Services
{
    public interface IAspiranteEntrevista
    {
        public IQueryable<AspiranteEntrevistum> Get(int id, int est);
        public IQueryable<AspiranteEntrevistum> Gets(int idAspirante);
    }
}
