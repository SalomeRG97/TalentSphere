﻿using Admin.Entities.Models;
using Admin.Interfaces.Base;


namespace Admin.Interfaces.Repositories
{
   public interface IContratoLaboralRepository : IRepository<ContratosLaborale>
    {
        Task<ContratosLaborale> GetByDocument(string numeroDocumento);
    }
}
