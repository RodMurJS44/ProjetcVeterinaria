using System;
using System.Threading;
using Vet02.App.Dominio;
using Vet02.App.Persistencia;

namespace Vet02.App.Consola
{
    class Program
    {
        //private static IRepositorioVeterinario repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        //private static IRepositorioAdministrador repositorioAdministrador = new RepositorioAdministrador(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            string opc = "n";
            while (!opc.ToUpper().Equals("S"))
            {
                Console.Clear();
                Console.WriteLine("\nMenu Inicial\n");
                Console.WriteLine("1. Gestionar Administradores");
                Console.WriteLine("2. Gestionar Veterinarios");
                Console.WriteLine("3. Gestionar Cuidadores");
                Console.WriteLine("4. Gestionar Mascotas");
                Console.WriteLine("5. Gestionar Citas");
                Console.WriteLine("6. Gestionar Vacunas");
                Console.WriteLine("7. Gestionar Historial Clinico");
                Console.WriteLine("8. Gestionar Diagnostico\n\n");
                Console.WriteLine("S. SALIR");
                Console.Write("\n\nSeleccione una opcion: ");
                opc = Console.ReadLine();
                switch (opc)
                {
                    case "1":
                        Console.Clear();
                        GestionEntidades("Menu Gestion de Administrativos", 1);
                        break;
                    case "2":
                        Console.Clear();
                        GestionEntidades("Menu de Gestion de Veterinarios", 2);
                        break;
                    case "3":
                        Console.Clear();
                        GestionEntidades("Menu de Gestion de Cuidadores", 3);
                        break;
                    case "4":
                        Console.Clear();
                        GestionEntidades("Menu de Gestion de Mascotas", 4);
                        break;
                    case "5":
                        Console.Clear();
                        GestionEntidades("Menu de Gestion de Citas", 5);
                        break;
                    case "6":
                        Console.Clear();
                        GestionEntidades("Menu de Gestion de Vacunas", 6);
                        break;
                    case "7":
                        Console.Clear();
                        GestionEntidades("Menu de Gestion de Historia Clinica", 7);
                        break;
                    case "8":
                        Console.Clear();
                        GestionEntidades("Menu de Gestion de Diagnostico", 8);
                        break;
                    case "s":
                    case "S":
                        Console.WriteLine("\n\nSaliendo del programa...\n\n");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("\n\nDigite opcion valida!!\n\n");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }
            }
        }

        public static void GestionEntidades(string tipoMenu, int tipoEntidad)
        {
            string opcAdmin = "a";
            while (!opcAdmin.ToUpper().Equals("S"))// && selecc != -1)
            {
                Console.Clear();
                Console.WriteLine(tipoMenu + "\n");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Consultar");
                Console.WriteLine("3. Editar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("\nS. Volver\n\n");
                Console.Write("Seleccione una opcion: ");
                opcAdmin = Console.ReadLine();
                switch (opcAdmin)
                {
                    case "1":
                        switch (tipoEntidad)
                        {
                            case 1:
                                Console.WriteLine("Agregar Admin...");
                                Thread.Sleep(1500);
                                Console.Clear();
                                bool regAdmin = GestionAdministradores.AgregarAdmin();
                                if(regAdmin)
                                {
                                    Console.WriteLine("Administrador registrado exitosamente");
                                    Console.WriteLine("\nPRESIONE ENTER PARA CONTINUAR");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("No se pudo registrar Administrador");
                                    Console.WriteLine("\nPRESIONE ENTER PARA CONTINUAR");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                break;
                            case 2:
                                Console.WriteLine("Agregar Vet...");
                                Thread.Sleep(1500);
                                Console.Clear();
                                bool regVet = GestionVeterinarios.AgregarVeterinario();
                                if(regVet)
                                {
                                    Console.WriteLine("Veterinario registrado exitosamente");
                                    Console.WriteLine("\nPRESIONE ENTER PARA CONTINUAR");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("No se pudo registrar Veterinario");
                                    Console.WriteLine("\nPRESIONE ENTER PARA CONTINUAR");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                break;
                            case 3:
                                Console.WriteLine("Agregar Cuidador...");
                                Thread.Sleep(1500);
                                break;
                            case 4:
                                Console.WriteLine("Agregar Macota...");
                                Thread.Sleep(1500);
                                break;
                            case 5:
                                Console.WriteLine("Agregar Cita...");
                                Thread.Sleep(1500);
                                break;
                            case 6:
                                Console.WriteLine("Agregar Vacuna...");
                                Thread.Sleep(1500);
                                break;
                            case 7:
                                Console.WriteLine("Agregar Historia...");
                                Thread.Sleep(1500);
                                break;
                            case 8:
                                Console.WriteLine("Agregar Diag...");
                                Thread.Sleep(1500);
                                break;
                        }
                        break;
                    case "2":
                        switch (tipoEntidad)
                        {
                            case 1:
                                Console.WriteLine("Consultar Admin...");
                                Thread.Sleep(1500);
                                Console.Clear();
                                GestionAdministradores.ConsultarAdministrador();
                                break;
                            case 2:
                                Console.WriteLine("Consultar Vet...");
                                Thread.Sleep(1500);
                                Console.Clear();
                                GestionVeterinarios.ConsultarVeterinario();
                                break;
                            case 3:
                                Console.WriteLine("Consultar Cuidador...");
                                Thread.Sleep(1500);
                                break;
                            case 4:
                                Console.WriteLine("Consultar Macota...");
                                Thread.Sleep(1500);
                                break;
                            case 5:
                                Console.WriteLine("Consultar Cita...");
                                Thread.Sleep(1500);
                                break;
                            case 6:
                                Console.WriteLine("Consultar Vacuna...");
                                Thread.Sleep(1500);
                                break;
                            case 7:
                                Console.WriteLine("Consultar Historia...");
                                Thread.Sleep(1500);
                                break;
                            case 8:
                                Console.WriteLine("Consultar Diag...");
                                Thread.Sleep(1500);
                                break;
                        }
                        break;
                    case "3":
                        switch (tipoEntidad)
                        {
                            case 1:
                                Console.WriteLine("Actualizar Admin...");
                                Thread.Sleep(1500);
                                Console.Clear();
                                GestionAdministradores.ActualizarAdministrador();
                                break;
                            case 2:
                                Console.WriteLine("Actualizar Vet...");
                                Thread.Sleep(1500);
                                Console.Clear();
                                GestionVeterinarios.ActualizarVeterinario();
                                break;
                            case 3:
                                Console.WriteLine("Actualizar Cuidador...");
                                Thread.Sleep(1500);
                                break;
                            case 4:
                                Console.WriteLine("Actualizar Macota...");
                                Thread.Sleep(1500);
                                break;
                            case 5:
                                Console.WriteLine("Actualizar Cita...");
                                Thread.Sleep(1500);
                                break;
                            case 6:
                                Console.WriteLine("Actualizar Vacuna...");
                                Thread.Sleep(1500);
                                break;
                            case 7:
                                Console.WriteLine("Actualizar Historia...");
                                Thread.Sleep(1500);
                                break;
                            case 8:
                                Console.WriteLine("Actualizar Diag...");
                                Thread.Sleep(1500);
                                break;
                        }
                        break;
                    case "4":
                        switch (tipoEntidad)
                        {
                            case 1:
                                Console.WriteLine("Borrar Admin...");
                                Thread.Sleep(1500);
                                Console.Clear();
                                GestionAdministradores.BorrarAdministrador();
                                break;
                            case 2:
                                Console.WriteLine("Borrar Vet...");
                                Thread.Sleep(1500);
                                Console.Clear();
                                GestionVeterinarios.BorrarVeterinario();
                                break;
                            case 3:
                                Console.WriteLine("Borrar Cuidador...");
                                Thread.Sleep(1500);
                                break;
                            case 4:
                                Console.WriteLine("Borrar Macota...");
                                Thread.Sleep(1500);
                                break;
                            case 5:
                                Console.WriteLine("Borrar Cita...");
                                Thread.Sleep(1500);
                                break;
                            case 6:
                                Console.WriteLine("Borrar Vacuna...");
                                Thread.Sleep(1500);
                                break;
                            case 7:
                                Console.WriteLine("Borrar Historia...");
                                Thread.Sleep(1500);
                                break;
                            case 8:
                                Console.WriteLine("Borrar Diag...");
                                Thread.Sleep(1500);
                                break;
                        }
                        break;
                    case "s":

                    case "S":
                        Console.WriteLine("Volviendo al menu anterior...");
                        Thread.Sleep(1500);
                        break;
                    default:
                        Console.WriteLine("\n\nDigite una opcion valida!!\n");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
