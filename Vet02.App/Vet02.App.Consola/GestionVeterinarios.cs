using System;
using Vet02.App.Dominio;
using Vet02.App.Persistencia;

namespace Vet02.App.Consola
{
    public class GestionVeterinarios
    {
        private static IRepositorioVeterinario repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        public static bool AgregarVeterinario()
        {
			Console.Write("Nombre: ");
			string nombreVet = Console.ReadLine();
			Console.Write("Apellidos: ");
			string apellidosVet = Console.ReadLine();
			Console.Write("Sexo: ");
			string sexoVet = Console.ReadLine();
			Console.Write("Edad: ");
			int edadVet = Convert.ToInt32(Console.ReadLine());
			Console.Write("Numero de Documento: ");
            int numDocVet = Convert.ToInt32(Console.ReadLine());
            if(repositorioVeterinario.GetVeterinario(numDocVet) != null)
            {
                Console.WriteLine("\nYA EXISTE UN VETERINARIO REGISTRADO CON ESTE NUMERO DE DOCUMENTO...");
                return false;
            }
			Console.Write("Tarjeta profesional: ");
			string tarjProfVet = Console.ReadLine();
            Console.Write("Especializacion: ");
			string espVet = Console.ReadLine();
			Console.Write("Correo electronico: ");
			string emailVet = Console.ReadLine();
            if(repositorioVeterinario.GetVeterinarioByEmail(emailVet) != null)
            {
                Console.WriteLine("\nYA EXISTE UN VETERINARIO REGISTRADO CON ESTE CORREO ELECTRONICO...");
                return false;
            }
			Console.Write("Contraseña de acceso: ");
			string psswdVet = Console.ReadLine();

			Veterinario vetNuevo = new Veterinario
			{
				Nombre = nombreVet,
                Apellidos = apellidosVet,
    	        NumeroDocumento = numDocVet,
                FechaRegistro = DateTime.Now.Date,
                Email = emailVet,
                Password = psswdVet,
                Sexo = sexoVet,
                Edad = edadVet,
				TarjetaProfesional = tarjProfVet,
                Especializacion = espVet
			};
			repositorioVeterinario.AddVeterinario(vetNuevo);
            return true;
        }
        
        public static void ConsultarVeterinario()
        {
            Console.Write("Digite numero de documento de Veterinario: ");
            int idVet = Convert.ToInt32(Console.ReadLine());
            Veterinario vetEncontrado = repositorioVeterinario.GetVeterinario(idVet);
            if(vetEncontrado != null)
            {
                Console.WriteLine("DATOS DE VETERINARIO\n");
                Console.WriteLine("Nombre: " + vetEncontrado.Nombre);
                Console.WriteLine("Apellidos: " + vetEncontrado.Apellidos);
                Console.WriteLine("Numero de documento: " + vetEncontrado.NumeroDocumento);
            }
            else
            {
                Console.WriteLine("VETERINARIO NO ENCONTRADO...");
            }
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();

        }

        public static void ActualizarVeterinario()
        {
            Console.Write("Ingrese numero de documento de Veterinario: ");
            int numDocVet = Convert.ToInt32(Console.ReadLine());
            Veterinario vetEncontrado = repositorioVeterinario.GetVeterinario(numDocVet);
            if(vetEncontrado != null)
            {
                Console.WriteLine("\nNombre de Veterinario: " + vetEncontrado.Nombre);
                Console.WriteLine("Desea editar? (S/N): ");
                string conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nuevo nombre: ");
                    vetEncontrado.Nombre = Console.ReadLine();
                }
                Console.WriteLine("\nApellidos de Veterinario: " + vetEncontrado.Apellidos);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nuevos apellidos: ");
                    vetEncontrado.Apellidos = Console.ReadLine();
                }
                Console.WriteLine("\nSexo de Administrador: " + vetEncontrado.Sexo);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nuevo sexo: ");
                    vetEncontrado.Sexo = Console.ReadLine();
                }
                Console.WriteLine("\nNumero de documento: "+vetEncontrado.NumeroDocumento);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    while(true)
                    {
                        Console.WriteLine("\nIngrese nuevo numero de documento: ");
                        int nuevoDocVet = Convert.ToInt32(Console.ReadLine());
                        if(repositorioVeterinario.GetVeterinario(nuevoDocVet) == null)
                        {
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
                Console.WriteLine("\nTarjeta profesional de Veterinario: " + vetEncontrado.TarjetaProfesional);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nueva tarjeta profesional: ");
                    vetEncontrado.TarjetaProfesional = Console.ReadLine();
                }
                Console.WriteLine("\nEspecializacion de Veterinario: " + vetEncontrado.Especializacion);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nueva Especializacion: ");
                    vetEncontrado.Especializacion = Console.ReadLine();
                }
                Console.WriteLine("\nEdad de Veterinario: " + vetEncontrado.Edad);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nueva edad: ");
                    vetEncontrado.Edad = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("\nCorreo electronico de Veterinario: " + vetEncontrado.Email);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    while(true)
                    {
                        Console.WriteLine("\nIngrese nuevo correo electronico: ");
                        string nuevoEmailVet = Console.ReadLine();
                        if(repositorioVeterinario.GetVeterinarioByEmail(nuevoEmailVet) == null)
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
                Console.WriteLine("\nContraseña de Veterinario: " + vetEncontrado.Password);
                Console.WriteLine("Desea editar? (S/N): ");
                conf = Console.ReadLine();
                if(conf.Equals("s") || conf.Equals("S"))
                {
                    Console.WriteLine("\nIngrese nueva contraseña: ");
                    vetEncontrado.Password = Console.ReadLine();
                }  
                repositorioVeterinario.UpdateVeterinario(vetEncontrado);
            }
            else
            {
                Console.WriteLine("VETERINARIO NO ENCONTRADO...\n");
                Console.WriteLine("\nPresione ENTER para continuar--");
                Console.ReadLine();
            }
        }

        public static void BorrarVeterinario()
        {
            Console.Write("Digite Numero de documento de Veterinario: ");
            int numDocVet = Convert.ToInt32(Console.ReadLine());
            repositorioVeterinario.DeleteVeterinario(numDocVet);
        }
    }
}