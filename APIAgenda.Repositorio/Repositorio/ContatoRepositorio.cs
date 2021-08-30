using APIAgenda.Dominio.Contratos;
using APIAgenda.Dominio.Entidades;
using APIAgenda.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace APIAgenda.Repositorio.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio, IDisposable
    {
        //protected readonly AgendaContexto AgendaContexto;
        //public ContatoRepositorio(AgendaContexto agendaContexto)
        //{
        //    AgendaContexto = agendaContexto;
        //}


        private readonly DbContextOptions<AgendaContexto> _OptionsBuider;
        public ContatoRepositorio()
        {
            _OptionsBuider = new DbContextOptions<AgendaContexto>();
        }

        public async Task Add(Contato contato)
        {
            using (var data = new AgendaContexto(_OptionsBuider))
            {
                await data.Set<Contato>().AddAsync(contato);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(Contato contato)
        {
            using (var data = new AgendaContexto(_OptionsBuider))
            {
                data.Set<Contato>().Remove(contato);
                await data.SaveChangesAsync();
            }
        }

        public async Task<Contato> GetEntityById(int Id)
        {
            using (var data = new AgendaContexto(_OptionsBuider))
            {
                return await data.Set<Contato>().FindAsync(Id);
            }
        }

        public async Task<List<ContatoModel>> List()
        {

            using (var data = new AgendaContexto(_OptionsBuider))
            {
                return await data.Set<Contato>().Select(x => new ContatoModel { Id = x.Id, Nome = x.Nome,Telefone = x.Telefone }).AsNoTracking().ToListAsync();
            }
        }

        public async Task Update(Contato contato)
        {
            using (var data = new AgendaContexto(_OptionsBuider))
            {
                data.Set<Contato>().Update(contato);
                await data.SaveChangesAsync();
            }
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
