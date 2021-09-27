using System;
using Vet02.App.Dominio;
using Vet02.App.Persistencia;

namespace Vet02.App.Consola
{
    public class GestionAdministradores
    {
        private static IRepositorioVeterinario repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioAdministrador repositorioAdministrador = new RepositorioAdministrador(new Persistencia.AppContext());
        public static bool AgregarAdmin()
        {
			Console.Write("Nombre: ");
			string nombreAdm = Console.ReadLine();
			Console.Write("Apellidos: ");
			string apellidosAdm = Console.ReadLine();
			Console.Write("Sexo: ");
			string sexoAdm = Console.ReadLine();
			Console.Write("Edad: ");
			int edadAdm = Convert.ToInt32(Console.ReadLine());
			Console.Write("Numero de Documento: ");
            int numDocAdm = Convert.ToInt32(Console.ReadLine());
            if(repositorioAdministrador.GetAdministrador(numDocAdm) != null)
            {
                Console.WriteLine("\nYA EXISTE UN ADMINISTRADOR REGISTRADO CON ESTE NUMERO DE DOCUMENTO...");
                return false;
            }
			Console.Write("Cargo: ");
			string cargoAdm = Console.ReadLine();
			Console.Write("Correo electronico: ");
			string emailAdm = Console.ReadLine();
            if(repositorioAdministrador.GetAdministradorByEmail(emailAdm) != null)
            {
                Console.WriteLine("\nYA EXISTE UN ADMINISTRADOR REGISTRADO CON ESTE CORREO ELECTRONICO...");
                return false;
            }
			Console.Write("Contraseña de acceso: ");
			string psswdAdm = Console.ReadLine();

			Administrador admin = new Administrador
			{
				Nombre = nombreAdm,
                Apellidos = apellidosAdm,
    	        NumeroDocumento = numDocAdm,
                FechaRegistro = DateTime.Now.Date,
                Email = emailAdm,
                Password = psswdAdm,
                Sexo = sexoAdm,
                Edad = edadAdm,
				Cargo = cargoAdm
			};
			repositorioAdministrador.AddAdministrador(admin);
            return true;
        }

        public static void ConsultarAdministrador()
        {
            Console.Write("Digite numero de documento de Administrador: ");
            int idAmin = Convert.ToInt32(Console.ReadLine());
            Administrador adminEncontrado = repositorioAdministrador.GetAdministrador(idAmin);
            if(adminEncontrado != null)
            {
                Console.WriteLine("DATOS DE ADMINISTRADOR\n");
                Console.WriteLine("Nombre: " + adminEncontrado.Nombre);
                Console.WriteLine("Apellidos: " + adminEncontrado.Apellidos);
                Console.WriteLine("Numero de documento: " + adminEncontrado.NumeroDocumento);
            }
            else
            {
                Console.WriteLine("ADMINISTRADOR NO ENCONTRADO...");
            }
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();

        }

        public static void ActualizarAdministrador()
        {
            Console.Write("Ingrese numero de documento de Administrador: ");
            int numDocAdm = Convert.ToInt32(Console.ReadLine());
            Administrador adminEncontrado = repositorioAdministrador.GetAdministrador(numDocAdm);
            if(adminEncontrado != null)
            {
                Console.WriteLine("\nNombre de Administrador: "+adminEncontrado.Nombre);
                Console.WriteLine("Desea editar? (S/N): ");
                string conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nuevo nombre: ");
                    adminEncontrado.Nombre = Console.ReadLine();
                }
                Console.WriteLine("\nApellidos de Administrador: "+adminEncontrado.Apellidos);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nuevos apellidos: ");
                    adminEncontrado.Apellidos = Console.ReadLine();
                }
                Console.WriteLine("\nSexo de Administrador: "+adminEncontrado.Sexo);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nuevo sexo: ");
                    adminEncontrado.Sexo = Console.ReadLine();
                }
                Console.WriteLine("\nNumero de documento de Administrador: "+adminEncontrado.NumeroDocumento);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    while(true)
                    {
                        Console.WriteLine("\nIngrese nuevo numero de documento: ");
                        int nuevoDocAdmin = Convert.ToInt32(Console.ReadLine());
                        if(repositorioAdministrador.GetAdministrador(nuevoDocAdmin) == null)
                        {
                            adminEncontrado.NumeroDocumento = nuevoDocAdmin;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("YA EXISTE UN USUARIO REGISTRADO CON EL MISMO NUMERO DE DOCUMENTO!!\n");
                            Console.Write("Desea volver a intentarlo? (S/N): ");
                            string askNew = Console.ReadLine();
                            if(!(askNew.Equals("n") || askNew.Equals("N")))
                            {
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine("\nCargo de Administrador: "+adminEncontrado.Cargo);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nuevo cargo: ");
                    adminEncontrado.Cargo = Console.ReadLine();
                }
                Console.WriteLine("\nEdad de Administrador: "+adminEncontrado.Edad);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nueva edad: ");
                    adminEncontrado.Edad = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("\nCorreo electronico de Administrador: "+adminEncontrado.Email);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    while(true)
                    {
                        Console.WriteLine("\nIngrese nuevo correo electronico: ");
                        string nuevoEmailAdmin = Console.ReadLine();
                        if(repositorioAdministrador.GetAdministradorByEmail(nuevoEmailAdmin) == null)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("YA EXISTE UN USUARIO REGISTRADO CON EL MISMO COREO ELECTRONICO!!\n");
                            Console.Write("Desea volver a intentarlo? (S/N): ");
                            string askNew = Console.ReadLine();
                            if(!(askNew.Equals("s") || askNew.Equals("S")))
                            {
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine("\nContraseña de Administrador: "+adminEncontrado.Password);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nueva contraseña: ");
                    adminEncontrado.Password = Console.ReadLine();
                }  
                repositorioAdministrador.UpdateAdministrador(adminEncontrado);
            }
            else
            {
                Console.WriteLine("ADMINISTRADOR NO ENCONTRADO...\n");
                Console.WriteLine("\nPresione ENTER para continuar--");
                Console.ReadLine();
            }
        }

        public static void BorrarAdministrador()
        {
            Console.Write("Digite Numero de documento de Aministrador: ");
            int idAmin = Convert.ToInt32(Console.ReadLine());
            repositorioAdministrador.DeleteAdministrador(idAmin);
        }
    }
}