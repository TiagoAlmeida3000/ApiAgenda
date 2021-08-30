using APIAgenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAgenda.Dominio.Contratos
{
    public interface IContatoRepositorio
    {
        
        Task Add(Contato contato);
        Task Update(Contato contato);
        Task<Contato> GetEntityById(int Id);
        Task Delete(Contato contato);
        Task<List<ContatoModel>> List();
    }
}
