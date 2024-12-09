using System.Collections;
using OrientadoObjetos.clases;

Libro libro1 = new Libro("Fundamentos de C#", "Clark Nathan", 1000);
Libro libro2 = new Libro("Programacion de C#", "Luc Gervais", 600);

Console.WriteLine(libro1.ObtenerDescripcion());
Console.WriteLine(libro2.ObtenerDescripcion());

Revista revista = new Revista("Pc World", "Charles Newton", 200);
Console.WriteLine(revista.ObtenerDescripcion());

// TODO: interfaces
// Bicicleta bicicleta = new Bicicleta();
// bicicleta.CambiarCarrera(1);
// bicicleta.Acelerar(3);
// bicicleta.imprimirEstados();

ArrayList arr = new ArrayList();
arr.Add(1);
arr.Add(2);
arr.Add("2254");