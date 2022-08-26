using CRUD4.Data;
using CRUD4.Models;

namespace CRUD4.Repositório
{
    public class UsuarioRep : IUsuario
    {

        private readonly AppDbContext _dbContext;
        public UsuarioRep(AppDbContext appDb)
        {
            _dbContext = appDb;
        }

        public UsuarioModel Listar(Guid Id)
        {
            return _dbContext.Usuarios.FirstOrDefault(x => x.Id == Id);
        }

        public List<UsuarioModel> ListarTodos()
        {
            return _dbContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //gravar no DB
            usuario.DataCadastro = DateTime.Now;
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = Listar(usuario.Id);

            if (usuarioDB == null) 
                throw new Exception("Houve um erro na atualização do usuário");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _dbContext.Usuarios.Update(usuarioDB);
            _dbContext.SaveChanges();

            return usuarioDB;
            
        }

        public bool Apagar(Guid Id)
        {
            UsuarioModel usuarioDB = Listar(Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na deleção do usuário");
            _dbContext.Usuarios.Remove(usuarioDB);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
