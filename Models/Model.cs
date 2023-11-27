using Microsoft.EntityFrameworkCore;

public class StudentiContext : DbContext
{
    public DbSet<CLasse> Classi { get; set; }
    public DbSet<Studente> Studenti { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(@" Data Source=Data/Studenti.db");
}