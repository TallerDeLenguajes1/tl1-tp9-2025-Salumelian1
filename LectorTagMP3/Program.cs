using System;
using IOFile = System.IO.File;
using TagFile = TagLib.File;

string? path;

do
{
    Console.WriteLine("Ingrese el path del archivo MP3 que desea analizar:");
    path = Console.ReadLine();

    if (path == null || !IOFile.Exists(path))
    {
        Console.WriteLine("El camino indicado no existe, intente de nuevo.");
        path = null;
    }

} while (path == null);

try
{
    var archivo = TagFile.Create(path);

    string titulo = archivo.Tag.Title ?? "Desconocido";
    string artista = (archivo.Tag.Performers.Length > 0)
        ? string.Join(", ", archivo.Tag.Performers)
        : "Desconocido";
    string album = archivo.Tag.Album ?? "Desconocido";
    string año = archivo.Tag.Year > 0 ? archivo.Tag.Year.ToString() : "Desconocido";
    DateTime anoDeCreacion = IOFile.GetCreationTime(path);

    Console.WriteLine("Título de la canción: " + titulo);
    Console.WriteLine("Autor(es) de la canción: " + artista);
    Console.WriteLine("Álbum de la canción: " + album);
    Console.WriteLine("Año especificado en el metadato (Tag): " + año);
    Console.WriteLine("Fecha de creación del archivo MP3: " + anoDeCreacion.ToShortDateString());
}
catch (Exception ex)
{
    Console.WriteLine("Ocurrió un error al analizar el archivo: " + ex.Message);
}
