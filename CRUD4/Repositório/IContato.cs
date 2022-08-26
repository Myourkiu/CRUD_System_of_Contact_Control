using CRUD4.Models;

namespace CRUD4.Repositório
{
    public interface IContato
    {
        ContatoModel Listar(Guid Id);
        List<ContatoModel> ListarTodos(); 
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(Guid Id);
    }
}
