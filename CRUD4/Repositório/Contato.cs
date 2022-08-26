using CRUD4.Data;
using CRUD4.Models;

namespace CRUD4.Repositório
{
    public class Contato : IContato
    {

        private readonly AppDbContext _dbContext;
        public Contato(AppDbContext appDb)
        {
            _dbContext = appDb;
        }

        public ContatoModel Listar(Guid Id)
        {
            return _dbContext.Contatos.FirstOrDefault(x => x.Id == Id);
        }

        public List<ContatoModel> ListarTodos()
        {
            return _dbContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar no DB
            _dbContext.Contatos.Add(contato);
            _dbContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = Listar(contato.Id);

            if (contatoDB == null) throw new Exception("Houve um erro na atualização do contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _dbContext.Contatos.Update(contatoDB);
            _dbContext.SaveChanges();

            return contatoDB;
            
        }

        public bool Apagar(Guid Id)
        {
            ContatoModel contatoDB = Listar(Id);

            if (contatoDB == null) throw new Exception("Houve um erro na deleção do contato");
            _dbContext.Contatos.Remove(contatoDB);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
