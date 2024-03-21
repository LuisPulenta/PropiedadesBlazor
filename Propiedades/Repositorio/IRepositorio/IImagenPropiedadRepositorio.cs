using Propiedades.Modelos.DTO;

namespace Propiedades.Repositorio.IRepositorio
{
    public interface IImagenPropiedadRepositorio
    {
        public Task<int> CrearPropiedadimagen(ImagenPropiedadDTO imagenDTO);
        public Task<int> BorrarPropiedadimagenPorIdImagen(int imagenId);
        public Task<int> BorrarPropiedadimagenPorIdPropiedad(int propiedadId);
        public Task<int> BorrarPropiedadimagenPorUrlImagen(string imagenUrl);
        public Task<IEnumerable<ImagenPropiedadDTO>> GetImagenesPropiedad(int propiedadId);
    }
}
