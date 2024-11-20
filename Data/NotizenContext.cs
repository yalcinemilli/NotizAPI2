using Microsoft.EntityFrameworkCore;
using NotizAPI2.Models;

namespace NotizAPI2.Data;

    public class NotizenContext : DbContext
    {
        // Konstruktor, der die Datenbankverbindung initialisiert
        public NotizenContext(DbContextOptions<NotizenContext> options) : base(options){}
        // Eigenschaft, die die Notizen-Tabelle darstellt
        public DbSet<Notiz> notizen { get; set; } = null!;
        // Konfiguration der Datenbanktabelle
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ruft die Basisklasse auf, um die Konfiguration zu erhalten
            base.OnModelCreating(modelBuilder); 

            // Setzt die Primärschlüssel-Eigenschaft
            modelBuilder.Entity<Notiz>().HasKey(n => n.Id);

            // Legt den Namen der Tabelle fest
            modelBuilder.Entity<Notiz>().ToTable("Notizen2");
        }
    }
