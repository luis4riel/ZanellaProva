using MF6.Domain.Features.Impressoras;
using System.Data.Entity.ModelConfiguration;

namespace MF6.Infra.ORM.Features.Impressoras
{
    public class ImpressoraConfiguracao : EntityTypeConfiguration<Impressora>
    {
        public ImpressoraConfiguracao()
        {
            this.ToTable("TBImpressora");

            Property(x => x.Marca).HasColumnType("Varchar").HasMaxLength(100).IsRequired();
            Property(x => x.Ip).HasColumnType("Varchar").HasMaxLength(25).IsRequired();
            Property(x => x.EmUso).IsRequired();
            Property(x => x.NivelTonerColorido).HasColumnType("Int").IsRequired();
            Property(x => x.NivelTonerPreto).HasColumnType("Int").IsRequired();

            this.HasKey(o => o.Id);
        }

    }
}
