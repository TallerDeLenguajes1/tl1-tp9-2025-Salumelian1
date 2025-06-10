using System.IO;
using System;

class Program {
    static void Main(string[] args)
    {
        string? path;
        string[] carpetas, files;
        do
        {
            Console.WriteLine("Ingresar el path deseado: ");
            path = Console.ReadLine();
            if (!Directory.Exists(path))
            {
                Console.WriteLine("EL directorio no existe. ");
            }
        } while (!Directory.Exists(path));
        carpetas = Directory.GetDirectories(path);
        Console.WriteLine("---------Directorios dentro del directorio-----");
        foreach (string Carpetas in carpetas)
        {
            Console.WriteLine(Carpetas);
        }
        files = Directory.GetFiles(path);
        Console.WriteLine("---------Archivos dentro del directorio-----");
        foreach (string File in files)
        {
            Console.WriteLine(File);
        }
        string NombreArchivo = "reporte_archivos.csv";
        string ruta = Path.Combine(path, NombreArchivo);
        using (StreamWriter escritor = new StreamWriter(ruta, false))
        {
            foreach (string archivos in files)
            {
                FileInfo info = new FileInfo(archivos);
                string nombre = info.Name;
                long Tamaño = info.Length / 1024;
                DateTime fecha = info.LastWriteTime;
                escritor.WriteLine($"{nombre}; {Tamaño}; {fecha}");
            }
        }
    }
}
