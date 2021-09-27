using System;
using System.Linq;
using Vet02.App.Dominio;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vet02.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        private readonly AppContext appContext;
        public RepositorioVeterinario(AppContext appContextParam)
        {
            this.appContext = appContextParam;
        }
        IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinarios()
        {
            return null;
        }
        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario vetNuevo)
        {
            var vetAdicionado = this.appContext.Veterinarios.Add(vetNuevo);
            this.appContext.SaveChanges();
            return vetAdicionado.Entity;
        }
        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario vetNuevo)
        {
            var vetEncontrado = this.appContext.Veterinarios.FirstOrDefault(v => v.Id == vetNuevo.Id);
            if(vetEncontrado != null)
            {
                vetEncontrado.Nombre = vetNuevo.Nombre;
                vetEncontrado.Apellidos = vetNuevo.Apellidos;
                vetEncontrado.NumeroDocumento = vetNuevo.NumeroDocumento;
                vetEncontrado.Email = vetNuevo.Email;
                vetEncontrado.Password = vetNuevo.Password;
                vetEncontrado.Sexo = vetNuevo.Sexo;
                vetEncontrado.Edad = vetNuevo.Edad;
                vetEncontrado.TarjetaProfesional = vetNuevo.TarjetaProfesional;
                vetEncontrado.Especializacion = vetNuevo.Especializacion;
                this.appContext.SaveChanges();
                return vetNuevo;
            }
            else
            {
                return null;
            }
        }
        void IRepositorioVeterinario.DeleteVeterinario(int numDocVet)
        {
            var vetEncontrado = this.appContext.Veterinarios.FirstOrDefault(v => v.NumeroDocumento == numDocVet);
            if(vetEncontrado != null)
            {
                this.appContext.Remove(vetEncontrado);
                this.appContext.SaveChanges();
            }
        }
        void IRepositorioVeterinario.DeleteVeterinarioById(int idVet)
        {
            var vetEncontrado = this.appContext.Veterinarios.FirstOrDefault(v => v.Id == idVet);
            if(vetEncontrado != null)
            {
                this.appContext.Remove(vetEncontrado);
                this.appContext.SaveChanges();
            }
        }
        Veterinario IRepositorioVeterinario.GetVeterinario(int numDocVet)
        {
            return this.appContext.Veterinarios.FirstOrDefault(v => v.NumeroDocumento == numDocVet);
        }
        Veterinario IRepositorioVeterinario.GetVeterinarioByEmail(string emailVet)
        {
            return this.appContext.Veterinarios.FirstOrDefault(v => v.Email == emailVet);
        }
    }
}