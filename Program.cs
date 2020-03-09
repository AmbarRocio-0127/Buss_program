using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buss
{
    class Program
    {
        public struct autobus
        {
            public string marca { get; set; }
            public string modelo { get; set; }
            public int capacidad { get; set; }
            public int placa { get; set; }
        }
        public struct chofer
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public long telefono { get; set; }
        }
        public struct Ruta
        {
            public string city_origin { get; set; }
            public string city_destiny { get; set; }
            public double cost { get; set; }
            public int id_ruta { get; set; }
        }
        public struct asignar_autobuses
        {
            public string nombre_chofer { get; set; }
            public string marca_autobus { get; set; }
            public int placa { get; set; }
        }
        public struct asignar_ruta
        {
            public string nombre_chofer_asignado { get; set; }
            public string marca_autobus_asignado { get; set; }
            public string destino_ruta { get; set; }
            public double costo_ruta { get; set; }
            public int placa_asignada { get; set; }
        }
        public struct reservaciones
        {
            public string clientenombre { get; set; }
            public string clienteapellido { get; set; }
            public string chofer_asignado { get; set; }
            public string autobus_asignado { get; set; }
            public string destino_ruta { get; set; }
            public double costo_ruta { get; set; }
            public double presupuesto { get; set; }
            public double total { get; set; }
            public int cantidad { get; set; }
            public double cambio { get; set; }
        }
        public static List<autobus> buss = new List<autobus>();
        public static List<chofer> choferes = new List<chofer>();
        public static List<Ruta> ruta = new List<Ruta>();
        public static List<reservaciones> reservacion = new List<reservaciones>();
        public static List<asignar_ruta> asignaciones_ruta = new List<asignar_ruta>();
        public static List<asignar_autobuses> asignacion_autobus = new List<asignar_autobuses>();
        public static void Agregar<T>(List<T> listado, T item)
        {
            listado.Add(item);
        }
        public static void Editar<T>(List<T> listado, int index, T value)
        {
            listado[index] = value;
        }
        public static void Borrar<T>(List<T> listado, int index)
        {
            listado.RemoveAt(index);
        }
        public static void Listar<T>(List<T> listado)
        {
            int j = 1;
            foreach (T item in listado)
            {
                Console.WriteLine(j + " - " + item);
                j++;
            }
        }
        private static string GetElement<T>(List<T> listado, int index)
        {
            return listado[index].ToString();
        }
        static void Main(string[] args)
        {
            mainmenu();
        }
        public static void mainmenu()
        {
            try
            {
            menuprincipal:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Title = "BUSS SYSTEM";
                Console.WriteLine("\t\t\t\t\a-----------------------------------");
                Console.WriteLine("\t\t\t\tBienvenido al Sistema De Autobuses ");
                Console.WriteLine("\t\t\t\t-----------------------------------");

                Console.WriteLine("Elija una opción: ");
                Console.WriteLine("\n1. Mantenimiento de autobuses.    2. Mantenimiento de choferes.    3. Mantenimiento de rutas.   4.Ventas de tickets para las rutas  5.Salir del sistema");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        mantenerautobuses();
                        break;
                    case 2:
                        mantenerchoferes();
                        break;
                    case 3:
                        mantenerrutas();
                        break;
                    case 4:
                    menuventas();
                        break;
                    case 5:
                        System.Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("Elija una opción válida. Toque enter para volver al menú...");
                        Console.ReadKey();
                        goto menuprincipal;
                        break;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("ERROR. " + error.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void mantenerautobuses()
        {
            try
            {
            m_autobuses:
                Console.Clear();
                Console.WriteLine("Seleccione una opción: ");
                Console.WriteLine("\n1.crear Autobús    2.Editar Autobús    3.Borrar Autobús    4.Listar Autobuses   5.Volver al menú principal");
                int opciones = int.Parse(Console.ReadLine());
                switch (opciones)
                {
                    case 1:
                        agregarautobuses();
                        break;
                    case 2:
                        editarautobuses();
                        break;
                    case 3:
                        borrarautobuses();
                        break;
                    case 4:
                        listarautobuses();
                        break;
                    case 5:
                        mainmenu();
                        break;
                    default:
                        Console.WriteLine("Opción no valida. elija una opción valida.");
                        Console.ReadKey();
                        goto m_autobuses;
                        break;

                }
            }
            catch (Exception error)
            {
                Console.WriteLine("ERROR. " + error.Message);
                Console.ReadKey();
                mainmenu();
            }
        }

        //Metodos para el mantenimiento de autobuses
        public static void agregarautobuses()
        {
            try
            {
                autobus addbuss = new autobus();
                Console.Clear();
                Console.Write("Marca del autobus: ");
                addbuss.marca = Console.ReadLine();
                Console.Write("Modelo del autobus: ");
                addbuss.modelo = Console.ReadLine();
                Console.Write("Capacidad del autobus: ");
                addbuss.capacidad = int.Parse(Console.ReadLine());
                Console.Write("Placa del autobus: ");
                addbuss.placa = int.Parse(Console.ReadLine());
                buss.Add(addbuss);

                mainmenu();
            }
            catch (Exception mistake)
            {
                Console.WriteLine(mistake.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void editarautobuses()
        {
            try
            {
            editarbuss:
                Console.Clear();
                Console.WriteLine("Introduzca la placa del autobús");
                int plc = int.Parse(Console.ReadLine());
                autobus editbuss;
                foreach (autobus k in buss)
                {
                    if (plc == k.placa)
                    {
                        buss.Remove(k);
                        editbuss = new autobus();
                        Console.Write("Marca del autobus (editado): ");
                        editbuss.marca = Console.ReadLine();
                        Console.Write("Modelo del autobus (editado): ");
                        editbuss.modelo = Console.ReadLine();
                        Console.Write("Capacidad del autobus(editado): ");
                        editbuss.capacidad = int.Parse(Console.ReadLine());
                        Console.Write("Placa del autobus: ");
                        editbuss.placa = int.Parse(Console.ReadLine());
                        buss.Add(editbuss);
                        mainmenu();
                    }
                    else
                    {
                        Console.WriteLine("La placa es incorrecta. Toque enter para volver al menú principal");
                        Console.ReadKey();
                        goto editarbuss;
                    }
                }
            }
            catch (Exception mistake)
            {
                Console.WriteLine("ERROR. " + mistake.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void borrarautobuses()
        {
            try
            {
                Console.Clear();
                Console.Write("Introduzca el numero de la placa del autobús: ");
                int placadelete = int.Parse(Console.ReadLine());
                buss.RemoveAll(l => l.placa == placadelete);

                Console.ReadKey();
                mainmenu();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error. " + error.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void listarautobuses()
        {
            try
            {
                Console.Clear();
                if (buss.Count == 0)
                {
                    Console.WriteLine("No hay listado de autobuses disponibles. Toque enter para volver al menú principal...");
                    Console.ReadKey();
                    mainmenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\tListado De Autobuses");
                    Console.WriteLine("\t\t\t--------------------\n");
                    foreach (autobus A in buss)
                    {
                        Console.WriteLine("Marca: " + A.marca);
                        Console.WriteLine("Modelo: " + A.modelo);
                        Console.WriteLine("Capacidad: " + A.capacidad);
                        Console.WriteLine("Placa: " + A.placa);
                        Console.WriteLine("---------------------");
                    }
                    Console.ReadKey();
                    mainmenu();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("ERROR " + error.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void mantenerchoferes()
        {
        choferes:
            Console.Clear();
            Console.WriteLine("Elija la opción deseada: ");
            Console.WriteLine("\n1.Agregar Chofer.   2.Editar Chofer   3.Borrar chofer   4.Listar choferes   5.Volver al menu principal.");
            int opc_choferes = int.Parse(Console.ReadLine());
            switch (opc_choferes)
            {
                case 1:
                    agregarchofer();
                    break;
                case 2:
                    editarchofer();
                    break;
                case 3:
                    borrarchofer();
                    break;
                case 4:
                    listarchoferes();
                    break;
                case 5:
                    mainmenu();
                    break;
                default:
                    Console.WriteLine("Opción no valida. Escoja una opción valida.");
                    Console.WriteLine("Toque ENTER para continuar...");
                    Console.ReadKey();
                    goto choferes;
                    break;
            }
        }
        //Metodos para el mantenimiento de choferes
        public static void agregarchofer()
        {
            try
            {
                Console.Clear();
                chofer adddriver = new chofer();
                Console.Clear();
                Console.Write("Nombre del chofer: ");
                adddriver.nombre = Console.ReadLine();
                Console.Write("Apellido del chofer: ");
                adddriver.apellido = Console.ReadLine();
                Console.Write("Teléfono del chofer: ");
                adddriver.telefono = Convert.ToInt64(Console.ReadLine());
                choferes.Add(adddriver);

                mainmenu();
            }
            catch (Exception mistake)
            {
                Console.WriteLine(mistake.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void editarchofer()
        {
            try
            {
            editarchofer:
                Console.Clear();
                Console.WriteLine("Introduzca el numero telefónico del chofer:");
                long cellphn = Convert.ToInt64(Console.ReadLine());
                chofer editchofer = new chofer();
                foreach (chofer k in choferes)
                {
                    if (cellphn == k.telefono)
                    {
                        choferes.Remove(k);
                        Console.Write("Nombre del nuevo chofer: ");
                        editchofer.nombre = Console.ReadLine();
                        Console.Write("Apellido del nuevo chofer: ");
                        editchofer.apellido = Console.ReadLine();
                        Console.Write("Telefono del nuevo chofer: ");
                        editchofer.telefono = Convert.ToInt64(Console.ReadLine());

                        choferes.Add(editchofer);
                        mainmenu();
                    }
                    else
                    {
                        Console.WriteLine("El número de Telefono es incorrecto. Toque Enter para volver a introducirla");
                        Console.ReadKey();
                        goto editarchofer;
                    }
                }
            }
            catch (Exception mistake)
            {
                Console.WriteLine("ERROR. " + mistake.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void borrarchofer()
        {
            try
            {
                Console.Clear();
                Console.Write("Introduzca el numero de telefono del chofer: ");
                long cellphone_number = Convert.ToInt64(Console.ReadLine());
                choferes.RemoveAll(l => l.telefono == cellphone_number);

                Console.ReadKey();
                mainmenu();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error. " + error.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void listarchoferes()
        {
            try
            {
                Console.Clear();
                if (choferes.Count == 0)
                {
                    Console.WriteLine("No hay listado de choferes disponibles. Toque enter para volver al menú principal...");
                    Console.ReadKey();
                    mainmenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\tListado De Choferes");
                    Console.WriteLine("\t\t\t--------------------\n");
                    foreach (chofer B in choferes)
                    {
                        Console.WriteLine("Nombre: " + B.nombre);
                        Console.WriteLine("Apellido: " + B.apellido);
                        Console.WriteLine("Teléfono: " + B.telefono);
                        Console.WriteLine("------------------------");
                    }
                    Console.ReadKey();
                    mainmenu();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("ERROR " + error.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void mantenerrutas()
        {
        mantenerruta:
            Console.Clear();
            Console.WriteLine("Elija la opción deseada: ");
            Console.WriteLine("\n1.Agregar Ruta   \n2.Editar  \n3.Borrar Ruta   \n4.Listar Rutas  \n5.Hacer asignaciones  \n6.listar choferes asignados a autobuses  \n7.Listar autobuses asignados a las rutas   \n8.Volver al menú principal");
            int opc_rut = int.Parse(Console.ReadLine());
            switch (opc_rut)
            {
                case 1:
                    agregarruta();
                    break;
                case 2:
                    editarruta();
                    break;
                case 3:
                    borrarruta();
                    break;
                case 4:
                    listarrutas();
                    break;
                case 5:
                    Asignaciones();
                    break;
                case 6:
                    choferesasignados();
                    break;
                case 7:
                    listar_asignaciones();
                    break;
                case 8:
                    mainmenu();
                    break;
                default:
                    Console.WriteLine("Opción no valida. Escoja una opción valida.");
                    Console.WriteLine("Toque ENTER para continuar...");
                    Console.ReadKey();
                    goto mantenerruta;
                    break;
            }
        }
        //Metodos para el mantenimiento de ruta
        public static void agregarruta()
        {
            try
            {
                Console.Clear();
                Ruta addrut = new Ruta();
                Console.Clear();
                Console.Write("Número de ruta: ");
                addrut.id_ruta = int.Parse(Console.ReadLine());
                Console.Write("Ciudad de origen: ");
                addrut.city_origin = Console.ReadLine();
                Console.Write("Ciudad de destino: ");
                addrut.city_destiny = Console.ReadLine();
                Console.Write("Costo de la ruta: ");
                addrut.cost = Convert.ToDouble(Console.ReadLine());
                ruta.Add(addrut);

                mainmenu();
            }
            catch (Exception mistake)
            {
                Console.WriteLine(mistake.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void editarruta()
        {
            try
            {
            editarruta:
                Console.Clear();
                Console.WriteLine("Seleccione una opcion: \n1.Editar Solo rutas    \n2.Editar Rutas, autobuses y choferes");
                int edit = int.Parse(Console.ReadLine());
                switch (edit)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Introduzca el ID de la ruta:");
                        int id_r = Convert.ToInt32(Console.ReadLine());
                        Ruta editrut = new Ruta();
                        foreach (Ruta l in ruta)
                        {
                            if (id_r == l.id_ruta)
                            {
                                ruta.Remove(l);
                                Console.Write("Número de ruta: ");
                                editrut.id_ruta = int.Parse(Console.ReadLine());
                                Console.Write("Nueva ciudad de origen: ");
                                editrut.city_origin = Console.ReadLine();
                                Console.Write("Nueva ciudad de destino: ");
                                editrut.city_destiny = Console.ReadLine();
                                Console.Write("Costo Actualizado de las rutas: ");
                                editrut.cost = Convert.ToDouble(Console.ReadLine());

                                ruta.Add(editrut);
                                mainmenu();
                            }
                            else
                            {
                                Console.WriteLine("El ID de la ruta es incorrecto. Toque Enter para volver a introducirla");
                                Console.ReadKey();
                                goto editarruta;
                            }

                        }
                        break;
                    case 2:
                    editartodo:
                        Console.Clear();
                        Console.WriteLine("Elija que desea editar: \n1.Editar Ruta  \n2.Editar Chofer    \n3.Editar Autobus   \n4.Volver atrás");
                        int ediciones = int.Parse(Console.ReadLine());
                        switch (ediciones)
                        {
                            case 1:
                            Console.WriteLine("Introduzca el ID de la ruta:");
                        int id_rut = Convert.ToInt32(Console.ReadLine());
                        Ruta editruta = new Ruta();
                        foreach (Ruta k in ruta)
                        {
                            if (id_rut == k.id_ruta)
                            {
                                ruta.Remove(k);
                                Console.Write("Número de ruta: ");
                                editruta.id_ruta = int.Parse(Console.ReadLine());
                                Console.Write("Nueva ciudad de origen: ");
                                editruta.city_origin = Console.ReadLine();
                                Console.Write("Nueva ciudad de destino: ");
                                editruta.city_destiny = Console.ReadLine();
                                Console.Write("Costo Actualizado de las rutas: ");
                                editruta.cost = Convert.ToDouble(Console.ReadLine());

                                ruta.Add(editruta);

                            }
                            else
                            {
                                Console.WriteLine("El ID de la ruta es incorrecto. Toque Enter para volver a introducirla");
                                Console.ReadKey();
                                goto editartodo;
                            }
                        }
                                break;
                            case 2:
                                editarchofer();
                                break;
                            case 3:
                                editarautobuses();
                                break;
                            case 4:
                                mainmenu();
                                break;
                }
                        
                        break;
                }
            }


            catch (Exception mistake)
            {
                Console.WriteLine("ERROR. " + mistake.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void borrarruta()
        {
            try
            {
                Console.Clear();
                Console.Write("Introduzca el Número de ruta: ");
                int delete_ruta = Convert.ToInt32(Console.ReadLine());
                ruta.RemoveAll(k => k.id_ruta == delete_ruta);

                Console.ReadKey();
                mainmenu();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error. " + error.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void listarrutas()
        {
            try
            {
                Console.Clear();
                if (ruta.Count == 0)
                {
                    Console.WriteLine("No hay listado de rutas disponibles. Toque enter para volver al menú principal...");
                    Console.ReadKey();
                    mainmenu();
                }
                else
                {
                    Console.WriteLine("\t\t\tListado De Rutas disponibles");
                    Console.WriteLine("\t\t\t---------------------------\n");
                    foreach (Ruta C in ruta)
                    {
                        Console.WriteLine("Número de ruta: " + C.id_ruta);
                        Console.WriteLine("Ciudad de Origen: " + C.city_origin);
                        Console.WriteLine("Ciudad de Destino: " + C.city_destiny);
                        Console.WriteLine("Costo: " + C.cost);
                        Console.WriteLine("------------------------");
                    }
                    Console.ReadKey();
                    mainmenu();
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Error. " + ex.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        
        public static void Asignaciones()
        {
            try
            {
                if (buss.Count > 0 && choferes.Count > 0)
                {
                    Console.Clear();
                    asignar_autobuses asignar = new asignar_autobuses();
                    Console.Clear();
                    Console.WriteLine("\t\t\tListado De Choferes");
                    Console.WriteLine("\t\t\t--------------------\n");
                    int j = 0;
                    foreach (chofer B in choferes)
                    {
                        Console.WriteLine("Nombre: " + B.nombre);
                        Console.WriteLine("Apellido: " + B.apellido);
                        Console.WriteLine("Teléfono: " + B.telefono);
                        Console.WriteLine("------------------------\n");
                        j++;
                    }

                    Console.Write("Introduzca el nombre y apellido del chofer: ");
                    string n_chofer = Console.ReadLine();
                    asignar.nombre_chofer = n_chofer;
                    Console.WriteLine("\t\t\tListado De Autobuses");
                    Console.WriteLine("\t\t\t--------------------\n");
                    int i = 0;
                    foreach (autobus A in buss)
                    {
                        Console.WriteLine("Marca: " + A.marca);
                        Console.WriteLine("Modelo: " + A.modelo);
                        Console.WriteLine("Capacidad: " + A.capacidad);
                        Console.WriteLine("Placa: " + A.placa);
                        Console.WriteLine("---------------------\n");
                        i++;
                    }
                    
                    Console.Write("Introduzca la marca del autobus que desea asignar al chofer: ");
                    string marca_buss = Console.ReadLine();
                    asignar.marca_autobus = marca_buss;
                    Console.Write("Introduzca la placa del autobus que desea asignar al chofer: ");
                    int plac = int.Parse(Console.ReadLine());
                    asignar.placa = plac;
                    
                    if (ruta.Count == 0)
                    {
                        Console.WriteLine("No hay rutas en el listado. Debe agregar almenos una ruta.");
                        Console.WriteLine("Toque una tecla para volver al menú principal");
                        Console.ReadKey();
                        mainmenu();
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tListado De Rutas disponibles");
                        Console.WriteLine("\t\t\t---------------------------\n");
                        foreach (Ruta C in ruta)
                        {
                            Console.WriteLine("Número de ruta: " + C.id_ruta);
                            Console.WriteLine("Ciudad de Origen: " + C.city_origin);
                            Console.WriteLine("Ciudad de Destino: " + C.city_destiny);
                            Console.WriteLine("Costo: " + C.cost);
                            Console.WriteLine("------------------------");
                        }
                        asignar_ruta asignar_r = new asignar_ruta();
                        Console.Write("Introduzca la ciudad de destino de la ruta: ");
                        asignar_r.destino_ruta = Console.ReadLine();
                        Console.Write("Introduzca el costo de la ruta: ");
                        asignar_r.costo_ruta = Convert.ToDouble(Console.ReadLine());
                        asignar_r.marca_autobus_asignado = marca_buss;
                        asignar_r.nombre_chofer_asignado = asignar.nombre_chofer;
                        asignar_r.placa_asignada = plac;

                        asignacion_autobus.Add(asignar);
                        asignaciones_ruta.Add(asignar_r);
                        Console.WriteLine("Toque una tecla para volver al menú principal");
                        Console.ReadKey();
                        mainmenu();
                    }
                }
                else
                {
                    Console.WriteLine("No existen choferes o autobuses suficientes para hacer asignaciones.");
                    Console.WriteLine("Toque para volver al menú principal...");
                    Console.ReadKey();
                    mainmenu();
                }
            }catch(Exception ex)
            {
                Console.WriteLine("ERROR. " + ex.Message);
                Console.ReadKey();
                mainmenu();
            }

        }
        public static void choferesasignados()
        {
            try
            {
                if (asignacion_autobus.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No hay asignaciones de choferes en el sistema.");
                    Console.WriteLine("Toque una tecla para volver al menú principal.");
                    Console.ReadKey();
                    mainmenu();
                }
                else
                { 
                Console.Clear();
                int j = 0;
                    Console.WriteLine("\t\t\tListado de choferes asignados a Autobuses");
                    Console.WriteLine("\t\t\t-----------------------------------------\n");
                foreach (asignar_autobuses item in asignacion_autobus)
                {
                    Console.WriteLine("Nombre del chofer: " + item.nombre_chofer);
                    Console.WriteLine("Marca del autobus asignado: " + item.marca_autobus);
                    Console.WriteLine("Placa del autobus: " + item.placa);
                    Console.WriteLine("------------------------------------");
                    j++;
                }
                Console.ReadKey();
                mainmenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error. " + ex.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void listar_asignaciones()
        {
            try
            {
                Console.Clear();
                if (asignaciones_ruta.Count == 0)
                {
                    Console.WriteLine("No hay asignaciones a rutas reservadas en el sistema.");
                    Console.WriteLine("Toque para volver al menú principal");
                    Console.ReadKey();
                    mainmenu();
                }
                else
                { 
                Console.Clear();
                Console.WriteLine("\t\t\tListar Asignaciones");
                Console.WriteLine("\t\t\t___________________\n");
                int k = 0;

                foreach (asignar_ruta item2 in asignaciones_ruta)
                {
                    Console.WriteLine((k + 1) + ")" + " Chofer Asignado: " + item2.nombre_chofer_asignado);
                    Console.WriteLine("Autobus Asignado: " + item2.marca_autobus_asignado);
                    Console.WriteLine("Paca del autobus asignado: " + item2.placa_asignada);
                    Console.WriteLine("Ruta Asignada (Ciudad de destino): " + item2.destino_ruta);
                    Console.WriteLine("Costo De la ruta: " + item2.costo_ruta);
                    Console.WriteLine("----------------------------");
                    k++;
                }
                Console.ReadKey();
                mainmenu();
                }
        }catch(Exception ex)
            {
                Console.WriteLine("ERROR. " + ex.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void menuventas()
        {
            try
            {
                ventas:
                Console.Clear();
                Console.WriteLine("Elija una opcion:\n   \n1.Realizar ventas    2.Mostrar reservaciones    3.Volver al menú principal");
                int opciones = int.Parse(Console.ReadLine());
                switch (opciones)
                {
                    case 1:
                        ventassdetickets();
                        break;
                    case 2:
                        mostrar_reservaciones();
                        break;
                    case 3:
                        mainmenu();
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.WriteLine("Toque una tecla para vlver al menú principal...");
                        Console.ReadKey();
                        goto ventas;
                        break;
                }
            }
            catch (Exception mistake)
            {
                Console.WriteLine("ERROR. " + mistake.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void ventassdetickets()
        {
            try
            {
                Ruta r = new Ruta();
                reservaciones info_cliente = new reservaciones();
                Console.Clear();
                Console.Write("Nombre del Cliente: ");
                info_cliente.clientenombre = Console.ReadLine();
                Console.Write("Apellido del Cliente: ");
                info_cliente.clienteapellido = Console.ReadLine();
                reservacion.Add(info_cliente);
                int k = 0;
                foreach (asignar_ruta item2 in asignaciones_ruta)
                {
                    Console.WriteLine("\n" + (k + 1) + ")" + " Chofer Asignado: " + item2.nombre_chofer_asignado);
                    Console.WriteLine("Autobus Asignado: " + item2.marca_autobus_asignado);
                    Console.WriteLine("Placa del autobuss: " + item2.placa_asignada);
                    Console.WriteLine("Ruta Asignada (Ciudad de destino): " + item2.destino_ruta);
                    Console.WriteLine("Costo De la ruta: " + item2.costo_ruta);
                    Console.WriteLine("------------------------");
                    k++;
                }
                reservaciones reservar = new reservaciones();
                Console.WriteLine("Introduzca el nombre del chofer de la ruta que desea reservar: ");
                reservar.chofer_asignado = Console.ReadLine();
                Console.WriteLine("Introduzca el autobus de la ruta que desea reservar: ");
                reservar.autobus_asignado = Console.ReadLine();
                Console.WriteLine("Introduzca el nombre del chofer de la ruta que desea reservar: ");
                reservar.chofer_asignado = Console.ReadLine();
                Console.WriteLine("Introduzca el destino de la ruta que desea reservar: ");
                reservar.destino_ruta = Console.ReadLine();
                Console.WriteLine("Introduzca el costo de la ruta que desea reservar: ");
                reservar.costo_ruta = Convert.ToDouble(Console.ReadLine());
                reservacion.Add(reservar);

                var sumatickets = reservacion.Sum(item => item.cantidad);
                var suma_capacidad_buss = buss.Sum(item2 => item2.capacidad);
                var total = suma_capacidad_buss - sumatickets;
                if(total > 0 )
                {
                    Console.Clear();
                    reservaciones vender = new reservaciones();
                    Console.Write("Cantidad de tickets que desea comprar: ");
                    vender.cantidad = int.Parse(Console.ReadLine());
                    Console.Write("Introduzca el presupuesto: ");
                    vender.presupuesto = Convert.ToDouble(Console.ReadLine());
                    vender.total = vender.cantidad * reservar.costo_ruta;
                    if (vender.presupuesto < reservar.costo_ruta)
                    {
                        Console.Clear();
                        Console.WriteLine("El presupuesto que introdujo no es suficiente.");
                        Console.WriteLine("Toque para volver al menú principal...");
                        Console.ReadKey();
                        mainmenu();
                    }
                    else
                    {
                        Console.Clear();
                        vender.cambio = vender.presupuesto - vender.total;
                        Console.WriteLine(vender.cantidad + " Tickets fueron comprados por el precio de: " + vender.total + ". Su cambio es de: " + vender.cambio);

                        Console.WriteLine("Toque ENTER para volver al menú principal...");
                        Console.ReadKey();
                        reservacion.Add(vender);
                        Console.ReadKey();
                        mainmenu();
                    }
                    Console.ReadKey();
                    mainmenu();
                }
                else
                {
                    Console.WriteLine("No hay rutas Tickets disponible para la ruta.");
                    Console.WriteLine("Toque para volver al menú principal...");
                    Console.ReadKey();
                    mainmenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR." + ex.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
        public static void mostrar_reservaciones()
        {
            try
            {
                Console.Clear();
                if (reservacion.Count == 0)
                {
                    Console.WriteLine("No hay reservaciones en el sistema.");
                    Console.WriteLine("Toque para volver al menú principal...");
                    Console.ReadKey();
                }
                Console.WriteLine("\t\t\t\tListado de reservaciones");
                Console.WriteLine("\t\t\t\t________________________\n");
                int k = 0;
                foreach (reservaciones item in reservacion)
                {
                    Console.WriteLine((k+1) + " Nombre del cliente: " + item.clientenombre + " " + item.clienteapellido);
                    Console.WriteLine("Cantidad de asientos reservados: " + item.cantidad);
                    Console.WriteLine("Fecha de la reservación: " + DateTime.Now);
                    Console.WriteLine("Costo de los tickets: " + item.costo_ruta);
                    Console.WriteLine("Destino de la ruta: " + item.destino_ruta);
                    Console.WriteLine("________________________________________________________\n");
                    k++;
                }
                Console.ReadKey();
                mainmenu();
            }
            catch (Exception error)
            {
                Console.WriteLine("ERROR." + error.Message);
                Console.ReadKey();
                mainmenu();
            }
        }
    }
}
