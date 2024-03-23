using Microsoft.AspNetCore.Components.Forms;

namespace Propiedades.Servicios
{
    public interface ISubidaArchivo
    {
        Task<string> SubirArchivo(IBrowserFile archivo);
        bool BorrarArchivo(string nombreArchivo);
    }
}
