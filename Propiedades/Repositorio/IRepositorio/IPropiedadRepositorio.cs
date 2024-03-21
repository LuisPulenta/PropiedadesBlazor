using Propiedades.Modelos.DTO;

namespace Propiedades.Repositorio.IRepositorio
{
    public interface IPropiedadRepositorio
    {
        public Task<IEnumerable<PropiedadDTO>> GetAllPropiedades();
        public Task<PropiedadDTO> GetPropiedad(int propiedadId);
        public Task<PropiedadDTO> CrearPropiedad(PropiedadDTO propiedadDTO);
        public Task<PropiedadDTO> ActualizarPropiedad(int propiedadId, PropiedadDTO propiedadDTO);
        public Task<PropiedadDTO> NombrePropiedadExiste(string nombre);
        public Task<int> BorrarPropiedad(int propiedadId);
    }
}
