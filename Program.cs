using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

var context = new StudentiContext();

Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("solo lettura");
Console.WriteLine("----------------------------------------------------------");

//questa query non è tracciata ed è quindi di sola lettura
var query = context.Studenti.AsNoTracking()
                                        .Where(s => s.StudenteId.Equals(4));
//.toLlist();
//.ToQueryString();

Console.WriteLine(query);

foreach(var item in query)
{
    Console.WriteLine($"{item.Nome}{item.Cognome}{item.DataNascita}");
}