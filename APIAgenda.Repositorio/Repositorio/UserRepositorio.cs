using APIAgenda.Dominio.Contratos;
using APIAgenda.Dominio.Entidades;
using APIAgenda.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAgenda.Repositorio.Repositorio
{
    public class UserRepositorio : IUserRepositorio
    {
        protected readonly AgendaContexto AgendaContexto;
        public UserRepositorio(AgendaContexto agendaContexto)
        {
            AgendaContexto = agendaContexto;
        }

        public User FindUser(int id)
        {
            return AgendaContexto.User.Find(id);
        }

        public User GetName(string nome)
        {
            return AgendaContexto.User.FirstOrDefault(u => u.Nome == nome);
        }

        public User GetUser(string email, string senha)
        {
            return AgendaContexto.User.FirstOrDefault(u => u.Email == email && u.Senha == senha);

        }

        public User GetUser(string email)
        {
            return AgendaContexto.User.FirstOrDefault(u => u.Email == email);
        }

        public int? GetUserId(string email)
        {
            return AgendaContexto.User.FirstOrDefault(u => u.Email == email)?.Id;
        }

        public async Task PostUser(User user)
        {
            AgendaContexto.Add(user);
            await AgendaContexto.SaveChangesAsync();
        }

        public User Validar(User user)
        {
            return AgendaContexto.User.Where(u => u.Email == user.Email).FirstOrDefault();
        }
    }
}
