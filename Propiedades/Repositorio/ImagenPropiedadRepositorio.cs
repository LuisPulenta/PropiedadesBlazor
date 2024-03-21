using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Propiedades.Data;
using Propiedades.Modelos;
using Propiedades.Modelos.DTO;
using Propiedades.Repositorio.IRepositorio;

namespace Propiedades.Repositorio
{
    public class ImagenPropiedadRepositorio : IImagenPropiedadRepositorio
    {
        private readonly ApplicationDbContext _bd;
        private readonly IMapper _mapper;

        public ImagenPropiedadRepositorio(ApplicationDbContext bd, IMapper mapper)
        {
            _bd = bd;
            _mapper = mapper;
        }

        //------------------------------------------------------------------------------------------------------------
        public async Task<int> BorrarPropiedadimagenPorIdImagen(int imagenId)
        {
            var imagen = await _bd.ImagenesPropiedad.FindAsync(imagenId);
            if (imagen != null)
            {
                _bd.ImagenesPropiedad.Remove(imagen);
                return await _bd.SaveChangesAsync();
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------
        public async Task<int> BorrarPropiedadimagenPorIdPropiedad(int propiedadId)
        {
            var imagenes = await _bd.ImagenesPropiedad.Where(x=>x.PropiedadId== propiedadId).ToListAsync();
                
            if (imagenes != null)
            {
                _bd.ImagenesPropiedad.RemoveRange(imagenes);
                return await _bd.SaveChangesAsync();
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------
        public async Task<int> BorrarPropiedadimagenPorUrlImagen(string imagenUrl)
        {
            var imagen = await _bd.ImagenesPropiedad.FirstOrDefaultAsync(x=>x.UrlImagenPropiedad.ToLower()==imagenUrl.ToLower()) ;
            if (imagen != null)
            {
                _bd.ImagenesPropiedad.Remove(imagen);
                return await _bd.SaveChangesAsync();
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------
        public async Task<int> CrearPropiedadimagen(ImagenPropiedadDTO imagenDTO)
        {
            var imagen = _mapper.Map<ImagenPropiedadDTO, ImagenPropiedad>(imagenDTO);
            await _bd.ImagenesPropiedad.AddAsync(imagen);
            return await _bd.SaveChangesAsync();
        }
        
        //------------------------------------------------------------------------------------------------------------
        public async Task<IEnumerable<ImagenPropiedadDTO>> GetImagenesPropiedad(int propiedadId)
        {
            var imagenes = await _bd.ImagenesPropiedad.Where(x => x.PropiedadId == propiedadId).ToListAsync();
            return _mapper.Map<IEnumerable<ImagenPropiedad>,IEnumerable<ImagenPropiedadDTO>>(imagenes);
        }
    }
}
