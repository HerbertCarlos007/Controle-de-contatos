using ControleDeContatos.Controllers;
using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio {
    public class ContatoRepositorio : IContatoRepositorio {

        private readonly BancoContext _context;
        public ContatoRepositorio(BancoContext bancoContext) {

            this._context = bancoContext;
        }

        public List<ContatoModel> BuscarTodos() {
            return _context.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato) {

            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public ContatoModel ListarPorId(int id) {
            
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Atualizar(ContatoModel contato) {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.email = contato.email;
            contatoDB.celular = contato.celular;

            _context.Contatos.Update(contatoDB);
            _context.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id) {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro ao deltar o contato");
            _context.Contatos.Remove(contatoDB);
            _context.SaveChanges();

            return true;
        }
    }
}
