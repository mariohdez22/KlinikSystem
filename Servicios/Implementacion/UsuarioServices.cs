using Microsoft.EntityFrameworkCore;
using KlinikSystem.Models;
using KlinikSystem.Servicios.Contrato;
using System.Drawing.Text;
#pragma warning disable

namespace KlinikSystem.Servicios.Implementacion
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly KlinikSystemContext _baseDatos;

        public UsuarioServices(KlinikSystemContext context)
        {
            _baseDatos = context;
        }

        public async Task<Personal> GetPersonal(string correo, string clave)
        {
            Personal personalEncontrado = await _baseDatos.Personals.Where(p => p.Correo == correo && p.Contrasena == clave)
                                          .FirstOrDefaultAsync();

            return personalEncontrado;
        }

        public async Task<List<AreaTrabajo>> GetArea(int idPersonal)
        {
            var tipos = await _baseDatos.Personals
                        .Where(p => p.Idpersonal == idPersonal)
                        .Join(_baseDatos.AreaTrabajos,
                        p => p.IdareaTrabajo,
                        t => t.IdareaTrabajo,
                        (p, t) => t)
                        .ToListAsync();

            return tipos;
        }
    }
}
