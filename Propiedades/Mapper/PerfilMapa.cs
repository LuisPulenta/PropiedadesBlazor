using AutoMapper;
using Propiedades.Modelos;
using Propiedades.Modelos.DTO;

namespace Propiedades.Mapper
{
    public class PerfilMapa: Profile
    {
        public PerfilMapa()
        {
            CreateMap<CategoriaDTO, Categoria>();
            CreateMap<Categoria,CategoriaDTO>();

            CreateMap<Propiedad, PropiedadDTO>().ReverseMap();
            CreateMap<Categoria, DropDownCategoriaDTO>().ReverseMap();
            CreateMap<ImagenPropiedad, ImagenPropiedadDTO>().ReverseMap();
        }
    }
}
