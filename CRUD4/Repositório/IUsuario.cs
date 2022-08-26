using CRUD4.Models;

namespace CRUD4.Repositório
{
    public interface IUsuario
    {
        UsuarioModel Listar(Guid Id);
        List<UsuarioModel> ListarTodos(); 
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(Guid Id);
    }
}
