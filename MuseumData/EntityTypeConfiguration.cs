using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuseumDomain;


namespace MuseumData
{
    public class MuseumEntityTypeConfiguration : IEntityTypeConfiguration<Museum>
    {
        public void Configure(EntityTypeBuilder<Museum> builder)
        {
            builder.HasAlternateKey(u => u.Name);
        }
    }
    public class WorkerEntityTypeConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.Property(x => x.Position).HasDefaultValue("Staff");
            builder.HasOne(x => x.Museum).WithMany(y => y.Workers).HasForeignKey(z => z.Adress_of_museum).OnDelete(DeleteBehavior.Restrict);
            builder.HasCheckConstraint("CH_Salary", "Salary > 14999");
        }
    }
    public class HallEntityTypeConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.HasOne(x => x.Museum).WithMany(y => y.Halls).HasForeignKey(z => z.Adress_of_museum).OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class ExhibitEntityTypeConfiguration : IEntityTypeConfiguration<Exhibit>
    {
        public void Configure(EntityTypeBuilder<Exhibit> builder)
        {
            builder.HasOne(x => x.Hall).WithMany(y => y.Exhibits).HasForeignKey(z => z.HallID).OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class TicketEntityTypeConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasOne(x => x.Client).WithMany(y => y.Tickets).HasForeignKey(z => z.ClientID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Museum).WithMany(y => y.Tickets).HasForeignKey(z => z.Adress_of_museum).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Worker).WithMany(y => y.Tickets).HasForeignKey(z => z.WorkerID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
