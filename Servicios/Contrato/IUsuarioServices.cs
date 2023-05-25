using Microsoft.EntityFrameworkCore;
using KlinikSystem.Models;

namespace KlinikSystem.Servicios.Contrato
{
    public interface IUsuarioServices
    {
        Task<Personal> GetPersonal(string correo, string clave);

        Task<List<AreaTrabajo>> GetArea(int idPersonal);

        //Task<Personal> SavePersonal(Personal modelo);
    }
}
