using ForumUnifeso.src.API.Model;
using Microsoft.EntityFrameworkCore;

namespace ForumUnifeso.src.API.Base.Context
{
    public class PrincipalDbContext : DbContext
    {
        public PrincipalDbContext(DbContextOptions<PrincipalDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Post { get; set; } = null!;
        public DbSet<Person> Person { get; set; } = null!;
        public DbSet<ThreadForum> ThreadForum { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento da classe Post
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Id); // Chave primária

                entity.Property(e => e.Id)
                 .ValueGeneratedOnAdd(); // Gera o Id ao criar.

                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(200); // Título obrigatório com limite de 200 caracteres

                entity.Property(e => e.Description)
                      .HasMaxLength(1000); // Descrição opcional com limite de 1000 caracteres

                entity.Property(e => e.Date)
                      .IsRequired(); // Data obrigatória

                // Relacionamento com Person (Autor)
                entity.HasOne(e => e.Author)
                      .WithMany() // Um Person pode ter muitos Posts, mas um Post tem um autor
                      .IsRequired(); // Autor é obrigatório
            });

            // Mapeamento da classe ThreadForum
            modelBuilder.Entity<ThreadForum>(entity =>
            {
                entity.HasKey(e => e.Id); // Chave primária
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100); // Nome do tópico obrigatório

                // Relacionamento 1:1 entre ThreadForum e Post (Topic)
                entity.HasOne(e => e.Topic)
                      .WithMany() // Um tópico pertence a apenas uma thread
                      .IsRequired(); // Tópico é obrigatório

                // Relacionamento 1:N entre ThreadForum e Posts (Answers)
                entity.HasMany(e => e.Answers)
                      .WithOne() // Cada resposta está relacionada a uma única thread
                      .IsRequired(false); // Respostas são opcionais
            });

            // Mapeamento da classe Person
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id); // Chave primária
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100); // Nome obrigatório
            });
        }
    }
}
