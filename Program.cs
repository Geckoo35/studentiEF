using System.Net.Quic;
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

Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("modifica Villa in Villani");
Console.WriteLine("----------------------------------------------------------");

//questa query è tracciata da EF, quindi eventuali modifiche ai dati vengono rilevate e non possono essere gestite

var qry = context.Studenti
                        .Where(c => c.Cognome.Equals("Villani"))
                        .ToList();

if(qry.Count == 1)
{
    qry[0].Cognome = "Villanelli";
    context.SaveChanges();
}

Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("Aggiunta Baronetti");
Console.WriteLine("----------------------------------------------------------");

//questa query non è tracciata ed è quindi di sola lettura:

var s = new Studente();
s.StudenteId = "BNCFTT76b43H2773";
s.Nome = "Carlo";
s.Cognome = "Baronetti";
s.Indirizzo = "Via Ada Negri 34";
s.DataNascita = new DateOnly(1989,3,5);
s.NumTel = "1234567890";
context.Add(s);
context.SaveChanges();

Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("Cancellazione Baronetti");
Console.WriteLine("----------------------------------------------------------");

qry = context.Studenti
                    .Where(c => c.Cognome.Equals("Baronetti"))
                    .ToList();

foreach (var item in qry)
{
    context.Studenti.Remove(item);
}

context.SaveChanges();

context.Dispose();