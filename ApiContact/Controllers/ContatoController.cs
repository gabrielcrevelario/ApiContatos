using ApiContact.Models;
using ApiContact.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiContact.Controllers
{   [Route("contatos")]    
    public class ContatoController : ApiController
    {
        ContatoRepository contatoRepository = new ContatoRepository();
        [HttpGet]
        public IHttpActionResult List()
        {
            IList<Contato> contatosList = contatoRepository.List();
            if(!contatosList.Any())
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Json(contatosList);
        }

        [HttpGet]
        public IHttpActionResult GetById( Guid idContato)
        {
            Contato contato = contatoRepository.GetById(idContato);
            if (contato == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Json(contato);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] Contato contato)
        {
            contatoRepository.Create(contato);
            return StatusCode(HttpStatusCode.Created);
        } 

        [HttpPut]
        public IHttpActionResult Update([FromUri] Guid idContato, [FromBody] Contato contato)
        {
            contatoRepository.Update(idContato, contato);
            return StatusCode(HttpStatusCode.Accepted);
        }
        [HttpDelete]
        [Route("{idContato}")]
        public IHttpActionResult Delete([FromUri] Guid idContato)
        {
            contatoRepository.Delete(idContato);
            return StatusCode(HttpStatusCode.Accepted);
        }

    }
}
