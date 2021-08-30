using APIAgenda.Dominio.Contratos;
using APIAgenda.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIAgenda.Web.Controllers
{
    [Route("api/[controller]")]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly IUserRepositorio _userRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio, IUserRepositorio userRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
            _userRepositorio = userRepositorio;
        }

        [HttpGet]
        [Authorize]
        public  JsonResult ListaContatos()
        {
            int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            User user = _userRepositorio.FindUser(userID);

            ICollection<Contato> contatos = user.Contatos;
            
            //var retorno = Json(await _contatoRepositorio.List());
            return Json(contatos.Select(x => new ContatoModel { Id = x.Id, Nome = x.Nome, Telefone = x.Telefone }));
        }
       


        [HttpGet("Obter/{id}")]
        [Authorize]
        public async Task<JsonResult> GetId(int id)
        {
            Contato contato = await _contatoRepositorio.GetEntityById(id);
            ContatoModel model = new ContatoModel
                                    {
                                        Id = contato.Id,
                                        Nome = contato.Nome,
                                        Telefone = contato.Telefone,                                        
                                    };
            return Json(model);
        }

        [HttpPost]
        [Authorize]
        public async Task Post([FromBody] Contato contato)
        {
            if (contato.Id > 0)
            {
                await _contatoRepositorio.Update(contato);
            }
            else
            {
                await _contatoRepositorio.Add(contato);
            }
        }


        [HttpPost("Deletar")]
        [Authorize]
        public async Task Deletar([FromBody] Contato contato)
        {
             await _contatoRepositorio.Delete(contato);
        }
    }
}
