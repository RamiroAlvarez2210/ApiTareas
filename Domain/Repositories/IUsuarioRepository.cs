namespace Domain.Repositories
{
    public interface IUsuarioRepository<Usuario> : IGenericRepository<Usuario>
    {
        public int GetByNombreUsuario(string nombreUsuario);
    }
}