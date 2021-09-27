using Vet02.App.Dominio;
using System.Collections.Generic;

namespace Vet02.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinarios();
        Veterinario AddVeterinario(Veterinario newVet);
        Veterinario UpdateVeterinario(Veterinario newVet);
        void DeleteVeterinario(int numDocVet);
        void DeleteVeterinarioById(int idVet);
        Veterinario GetVeterinario(int numDocVet);
        Veterinario GetVeterinarioByEmail(string emailVet);
    }
}