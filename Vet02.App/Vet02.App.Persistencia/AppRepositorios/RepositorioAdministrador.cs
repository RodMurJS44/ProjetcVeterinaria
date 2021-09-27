using System;
using System.Linq;
using Vet02.App.Dominio;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vet02.App.Persistencia
{
    public class RepositorioAdministrador : IRepositorioAdministrador
    {
        private readonly AppContext appContext;
        public RepositorioAdministrador(AppContext appContextParam)
        {
            this.appContext = appContextParam;
        }
        IEnumerable<Administrador> IRepositorioAdministrador.GetAllAdministradores()
        {
            return null;
        }
        Administrador IRepositorioAdministrador.AddAdministrador(Administrador admin)
        {
            var adminAdicionado = this.appContext.Administradores.Add(admin);
            this.appContext.SaveChanges();
            return adminAdicionado.Entity;
        }
        Administrador IRepositorioAdministrador.UpdateAdministrador(Administrador adminNuevo)
        {
            var adminEncontrado = this.appContext.Administradores.FirstOrDefault(a => a.Id == adminNuevo.Id);
            if(adminEncontrado != null)
            {
                adminEncontrado.Nombre = adminNuevo.Nombre;
                adminEncontrado.Apellidos = adminNuevo.Apellidos;
                adminEncontrado.NumeroDocumento = adminNuevo.NumeroDocumento;
                adminEncontrado.Email = adminNuevo.Email;
                adminEncontrado.Password = adminNuevo.Password;
                adminEncontrado.Sexo = adminNuevo.Sexo;
                adminEncontrado.Edad = adminNuevo.Edad;
                adminEncontrado.Cargo = adminNuevo.Cargo;
                this.appContext.SaveChanges();
                return adminNuevo;
            }
            else
            {
                return null;
            }
        }
        void IRepositorioAdministrador.DeleteAdministrador(int numDocAdmin)
        {
            var adminEncontrado = this.appContext.Administradores.FirstOrDefault(a => a.NumeroDocumento == numDocAdmin);
            if(adminEncontrado != null)
            {
                this.appContext.Remove(adminEncontrado);
                this.appContext.SaveChanges();
            }
        }
        void IRepositorioAdministrador.DeleteAdministradorById(int idAdm)
        {
            var adminEncontrado = this.appContext.Administradores.FirstOrDefault(a => a.Id == idAdm);
            if(adminEncontrado != null)
            {
                this.appContext.Remove(adminEncontrado);
                this.appContext.SaveChanges();
            }
        }
        Administrador IRepositorioAdministrador.GetAdministrador(int numDocAdm)
        {
            return this.appContext.Administradores.FirstOrDefault(a => a.NumeroDocumento == numDocAdm);
        }
        Administrador IRepositorioAdministrador.GetAdministradorByEmail(string emailAdmin)
        {
            return this.appContext.Administradores.FirstOrDefault(a => a.Email == emailAdmin);
        }
    }
}