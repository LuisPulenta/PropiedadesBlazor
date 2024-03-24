using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Propiedades.Data;
using Propiedades.Modelos;
using Propiedades.Modelos.DTO;
using Propiedades.Repositorio.IRepositorio;


namespace Propiedades.Repositorio
{
    public class PropiedadRepositorio : IPropiedadRepositorio
    {
        private readonly ApplicationDbContext _bd;
        private readonly IMapper _mapper;

        public PropiedadRepositorio(ApplicationDbContext bd, IMapper mapper)
        {
            _bd = bd;
            _mapper=mapper;
        }

        //------------------------------------------------------------------------------------------------------------
        public async Task<PropiedadDTO> ActualizarPropiedad(int propiedadId, PropiedadDTO propiedadDTO)
        {
            try
            {
                if (propiedadId == propiedadDTO.Id)
                {
                    //Válido para actualizar
                    Propiedad propiedad = await _bd.Propiedades.FindAsync(propiedadId);
                    Propiedad propie = _mapper.Map<PropiedadDTO, Propiedad>(propiedadDTO, propiedad);
                    propie.FechaActualizacion = DateTime.Now;
                    var propiedadActualizada = _bd.Propiedades.Update(propie);
                    await _bd.SaveChangesAsync();
                    return _mapper.Map<Propiedad, PropiedadDTO>(propiedadActualizada.Entity);
                }
                else
                {
                    //Inválido
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------
        public async Task<int> BorrarPropiedad(int propiedadId)
        {
            var propiedad = await _bd.Propiedades.FindAsync(propiedadId);
            if(propiedad != null)
            {
                _bd.Propiedades.Remove(propiedad);
                return await _bd.SaveChangesAsync();
            }
            return 0;            
        }

        //------------------------------------------------------------------------------------------------------------
        public async Task<PropiedadDTO> CrearPropiedad(PropiedadDTO propiedadDTO)
        {
            Propiedad propiedad = _mapper.Map<PropiedadDTO, Propiedad>(propiedadDTO);
            propiedad.FechaCreacion = DateTime.Now;
            var propiedadAgregada = await _bd.Propiedades.AddAsync(propiedad);
            await _bd.SaveChangesAsync();
            return _mapper.Map<Propiedad, PropiedadDTO>(propiedadAgregada.Entity);
        }

        //------------------------------------------------------------------------------------------------------------
        public async Task<IEnumerable<PropiedadDTO>> GetAllPropiedades()
        {
            //Version 1
            //try
            //{
            //    IEnumerable<PropiedadDTO> propiedadsDTO = _mapper.Map<IEnumerable<Propiedad>, IEnumerable<PropiedadDTO>>(_bd.Propiedades);
            //    return (propiedadsDTO);
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}

            //Version 2
            try
            {
                IEnumerable<PropiedadDTO> propiedadsDTO = _mapper.Map<IEnumerable<Propiedad>, IEnumerable<PropiedadDTO>>(_bd.Propiedades
                    .Include(x=>x.ImagenesPropiedad)
                    .Include(x => x.Categoria)
                    );
                return (propiedadsDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------
        public async Task<PropiedadDTO> GetPropiedad(int propiedadId)
        {
            try
            {
                PropiedadDTO propiedadDTO = _mapper.Map<Propiedad, PropiedadDTO>(await _bd.Propiedades.FirstOrDefaultAsync(c => c.Id == propiedadId));
                return (propiedadDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------
        public async Task<PropiedadDTO> NombrePropiedadExiste(string nombre)
        {
            try
            {
                PropiedadDTO propiedadDTO =
                           _mapper.Map<Propiedad, PropiedadDTO>
                           (await _bd.Propiedades.FirstOrDefaultAsync(
                               c => c.Nombre.ToLower() == nombre.ToLower()));
                return propiedadDTO;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
