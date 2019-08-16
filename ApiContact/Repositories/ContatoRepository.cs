using ApiContact.Context;
using ApiContact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiContact.Repositories
{
    public class ContatoRepository
    {



        ContatoContext context = new ContatoContext();

        public IList<Contato> List()
        {
            return context.Contatos.ToList();
        }

        public Contato GetById(Guid idContato)
        {
            return context.Contatos.Single(x => x.Id == idContato);
        }

        public void Create(Contato contato)
        {
            contato.Id = Guid.NewGuid();
            context.Contatos.Add(contato);
            context.SaveChanges();
        }

        public void Update(Guid idContato, Contato contato)
        {
            try
            {
                
                var resp = context.Contatos.Where(x => x.Id == idContato).First();
                if (resp != null)
                {
                    contato.Id = idContato;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Não existe esse Id");
                }
            } catch(Exception ex)
            {
               throw ex;
            }

        }

        public void Delete(Guid idContato)
        {
            var contato = context.Contatos.Single(x => x.Id == idContato);
            context.Contatos.Remove(contato);
            context.SaveChanges();         
        }
    }
}