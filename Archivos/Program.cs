//Leer contenido de un archvio de texto
using Archivos;
using Newtonsoft.Json;
using System.Text;

var ruta = @"C:\Users\rmorales\source\repos\Archivos\Archivos\ejemplo.txt";
var RutaDestino =  @"C:\Users\rmorales\source\repos\Archivos\Archivos\ejemplof copy.txt";

if (File.Exists(ruta))
{
    var contenido = File.ReadAllText(ruta);

    Console.WriteLine(contenido);
    File.Copy(ruta, RutaDestino, overwrite: true) ;

}
else
{
    Console.WriteLine("el archivo no fue encontrado");
}



//leer todas las linea



var lineas = File.ReadAllLines(@"C:\Users\rmorales\source\repos\Archivos\Archivos\ejemploLineas.txt");

//eliminar
 File.Delete(RutaDestino);

Console.WriteLine();

//crear un directorio

var rutaD = @"C:\Users\rmorales\source\repos\Archivos\Archivos\Mi Directorio";

Directory.CreateDirectory(rutaD);

var rutaLista = @"C:\Users\rmorales\source\repos\Archivos\Archivos";

foreach (var item in rutaLista)
{
    Console.Write(item);
    var nombreArchivo = Path.GetFileName(ruta);

}


//strem writer
var ruta4 = @"C:\Users\rmorales\source\repos\Archivos\Archivos\mensaje.txt";
var streamWriter = new StreamWriter(ruta4 , append: true);

streamWriter.WriteLine("Buenos dias");
streamWriter.WriteLine("te informo que es la hora es " + DateTime.Now.ToString("hh"));

//es importante del dispose()
streamWriter.Dispose();



//listado de archivos

var ruta5 = @"C:\Users\rmorales\source\repos\Archivos\Archivos\personas.txt";

var personas = new List<Persona>
{
    new Persona(){id = 1 , Nombre = "RAFAEL MORALES",Salario = 233m},
     new Persona(){id = 2 , Nombre = "RAFAEL",Salario = 223m},
      new Persona(){id = 3 , Nombre = " MORALES",Salario = 232m},
       new Persona() { id = 3, Nombre = "llanes", Salario = 253m },
};


var stringBuilder = new StringBuilder();

foreach (var item in personas)

{

    stringBuilder.AppendLine($"{item.id} | {item.Nombre} | {item.Salario}" );

}

using (var sw = new StreamWriter(ruta5, append: false))
{

    sw.Write(stringBuilder.ToString());
}

//formato json

var rutaEjmplo = @"C:\Users\rmorales\source\repos\Archivos\Archivos\personas.json";

var persona4 = new Persona { id = 1, Nombre = "Rafael Morales Llanes", Salario = 24.6m };

var json = JsonConvert.SerializeObject(persona4);

Console.WriteLine(json);

using(var sm = new StreamWriter(rutaEjmplo))
{
    sm.Write(json);
}    


var contenidoArchvio = File.ReadAllText(rutaEjmplo);
var personaese = JsonConvert.DeserializeObject<Persona>(contenidoArchvio)!;

Console.WriteLine(personaese.Nombre);