using Propiedades.Modelos.DTO;

namespace Propiedades.Repositorio.IRepositorio
{
    public interface ICategoriaRepositorio
    {
        public Task<IEnumerable<CategoriaDTO>> GetAllCategorias();
        public Task<CategoriaDTO> GetCategoria(int categoriaId);
        public Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO);
        public Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO);
        public Task<CategoriaDTO> NombreCategoriaExiste(string nombre);
        public Task<int> BorrarCategoria(int categoriaId);
        public Task<IEnumerable<DropDownCategoriaDTO>> GetDropDownCategorias();
    }
}
