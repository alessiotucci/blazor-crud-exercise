using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MonusProject.Client.Shared.Models;

namespace MonusProject.Server.Data //nome cartella e nome DbContext devono essere diversi altrimenti vanno in conflitto
{
	public class ColloquioContext : DbContext
	{
        public ColloquioContext(DbContextOptions<ColloquioContext> options) : base(options)
        { }
        public DbSet<Candidato> Candidati { get; set; }
        public DbSet <Sede> Sedi { get; set; }
        public DbSet <Dipendente> Dipendenti { get; set; }
        public DbSet <Colloquio> Colloqui { get; set; }
        public DbSet <Skill> Skills { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
