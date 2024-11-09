using byterisk_odontoprev_cs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace byterisk_odontoprev_cs.Infrastructure.Data.AppData;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    // Definindo os DbSet para as entidades do ByteRisk
    public DbSet<BeneficiarioEntity> Beneficiarios { get; set; }
    public DbSet<PlanoEntity> Planos { get; set; }
    public DbSet<ConsultaEntity> Consultas { get; set; }
    public DbSet<MedicoEntity> Medicos { get; set; }
    public DbSet<ExameEntity> Exames { get; set; }
    public DbSet<SinistroEntity> Sinistros { get; set; }
    
    
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Mapeamento para BeneficiarioEntity
    modelBuilder.Entity<BeneficiarioEntity>(entity =>
    {
        entity.ToTable("BENEFICIARIO");
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id).HasColumnName("ID_BENEFICIARIO");
        entity.Property(e => e.Nome).HasColumnName("NOME");
        entity.Property(e => e.DataNascimento).HasColumnName("DATA_NASCIMENTO");
        entity.Property(e => e.Cpf).HasColumnName("CPF");
        entity.Property(e => e.Telefone).HasColumnName("TELEFONE");
        entity.Property(e => e.Email).HasColumnName("EMAIL");
        entity.Property(e => e.Endereco).HasColumnName("ENDERECO");
        entity.Property(e => e.Ranking).HasColumnName("RANKING");
        entity.Property(e => e.PlanoId).HasColumnName("ID_PLANO");
        
        // Relacionamento com SinistroEntity
        entity.HasMany(e => e.Sinistros)
              .WithOne(s => s.Beneficiario)
              .HasForeignKey(s => s.BeneficiarioId);
        
        // Relacionamento com ConsultaEntity
        entity.HasMany(e => e.Consultas)
              .WithOne(c => c.Beneficiario)
              .HasForeignKey(c => c.BeneficiarioId);

        // Relacionamento com ExameEntity
        entity.HasMany(e => e.Exames)
              .WithOne(ex => ex.Beneficiario)
              .HasForeignKey(ex => ex.BeneficiarioId);
    });

    // Mapeamento para PlanoEntity
    modelBuilder.Entity<PlanoEntity>(entity =>
    {
        entity.ToTable("PLANO");
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id).HasColumnName("ID_PLANO");
        entity.Property(e => e.NomePlano).HasColumnName("NOME_PLANO");
        entity.Property(e => e.TipoPlano).HasColumnName("TIPO_PLANO");
        entity.Property(e => e.ValorMensal)
              .HasColumnType("DECIMAL(10, 2)")
              .HasPrecision(10, 2);

        // Relacionamento com BeneficiarioEntity
        entity.HasMany(e => e.Beneficiarios)
              .WithOne(b => b.Plano)
              .HasForeignKey(b => b.PlanoId);
    });

    // Mapeamento para SinistroEntity
    modelBuilder.Entity<SinistroEntity>(entity =>
    {
        entity.ToTable("SINISTRO");
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id).HasColumnName("ID_SINISTRO");
        entity.Property(e => e.BeneficiarioId).HasColumnName("ID_BENEFICIARIO");
        entity.Property(e => e.DataSinistro).HasColumnName("DATA_SINISTRO");
        entity.Property(e => e.TipoSinistro).HasColumnName("TIPO_SINISTRO");
        entity.Property(e => e.ValorSinistro)
              .HasColumnType("DECIMAL(10, 2)")
              .HasPrecision(10, 2);

        // Relacionamento com BeneficiarioEntity
        entity.HasOne(e => e.Beneficiario)
              .WithMany(b => b.Sinistros)
              .HasForeignKey(e => e.BeneficiarioId);
    });

    // Mapeamento para ConsultaEntity
    modelBuilder.Entity<ConsultaEntity>(entity =>
    {
          entity.ToTable("CONSULTA");
          entity.HasKey(e => e.Id);

          entity.Property(e => e.Id).HasColumnName("ID_CONSULTA");
          entity.Property(e => e.BeneficiarioId).HasColumnName("ID_BENEFICIARIO");
          entity.Property(e => e.DataConsulta).HasColumnName("DATA_CONSULTA");
          entity.Property(e => e.MotivoConsulta).HasColumnName("MOTIVO_CONSULTA");
          entity.Property(e => e.Status).HasColumnName("STATUS");
          entity.Property(e => e.MedicoId).HasColumnName("ID_PROFISSIONAL"); // Nome correto no banco

          // Relacionamento com BeneficiarioEntity
          entity.HasOne(e => e.Beneficiario)
                .WithMany(b => b.Consultas)
                .HasForeignKey(e => e.BeneficiarioId);

          // Relacionamento com MedicoEntity
          entity.HasOne(e => e.Medico)
                .WithMany(m => m.Consultas)
                .HasForeignKey(e => e.MedicoId);
    });

    // Mapeamento para ExameEntity
    modelBuilder.Entity<ExameEntity>(entity =>
    {
        entity.ToTable("EXAME");
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id).HasColumnName("ID_EXAME");
        entity.Property(e => e.BeneficiarioId).HasColumnName("ID_BENEFICIARIO");
        entity.Property(e => e.DataExame).HasColumnName("DATA_EXAME");
        entity.Property(e => e.TipoExame).HasColumnName("TIPO_EXAME");
        entity.Property(e => e.ResultadoExame).HasColumnName("RESULTADO_EXAME");
        entity.Property(e => e.MedicoId).HasColumnName("ID_PROFISSIONAL"); // Nome correto no banco

        // Relacionamento com BeneficiarioEntity
        entity.HasOne(e => e.Beneficiario)
              .WithMany(b => b.Exames)
              .HasForeignKey(e => e.BeneficiarioId);

        // Relacionamento com MedicoEntity
        entity.HasOne(e => e.Medico)
              .WithMany(m => m.Exames)
              .HasForeignKey(e => e.MedicoId);
    });

    // Mapeamento para MedicoEntity
    modelBuilder.Entity<MedicoEntity>(entity =>
    {
        entity.ToTable("PROFISSIONAL"); // Tabela 'PROFISSIONAL'
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id).HasColumnName("ID_PROFISSIONAL"); // Alinhado com o banco
        entity.Property(e => e.Nome).HasColumnName("NOME");
        entity.Property(e => e.Especialidade).HasColumnName("ESPECIALIDADE");
        entity.Property(e => e.Crm).HasColumnName("CRM");

        // Relacionamento com ConsultaEntity e ExameEntity
        entity.HasMany(e => e.Consultas)
              .WithOne(c => c.Medico)
              .HasForeignKey(c => c.MedicoId);

        entity.HasMany(e => e.Exames)
              .WithOne(ex => ex.Medico)
              .HasForeignKey(ex => ex.MedicoId);
    });
}
}
