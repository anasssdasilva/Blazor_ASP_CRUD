using EntreprisesContacts.Shared.Models;
using Microsoft.EntityFrameworkCore;


namespace EntreprisesContacts.Server.Models
{
    public partial class ContactDBContext : DbContext
    {
        public ContactDBContext()
        {

        }

        public ContactDBContext(DbContextOptions<ContactDBContext> options) :base(options)
        {
        }

        public virtual DbSet<Entreprise> Entreprises { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entreprise>(entity =>
            {
                entity.ToTable("Entreprise");

                entity.Property(e => e.EntrepriseId).HasColumnName("EntrepriseID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstAdress)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SecondAdress)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.thumbnail)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Entreprise)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .IsUnicode(false);


            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
