using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{


    public class ContactConfiguration : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {

            builder.HasKey(c => c.Id);
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);


            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.MobilePhone)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(c => c.JobTitle)
                .HasMaxLength(50);

            builder.Property(c => c.BirthDay)
                .IsRequired();


            builder.HasData(InitialData());
        }

        private IEnumerable<ContactEntity> InitialData()
        {
            return new List<ContactEntity>
    {
        new ContactEntity
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Иван Иванов",
            MobilePhone = "+375291112233",
            JobTitle = "Менеджер",
            BirthDay = new DateTime(1990, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedAt = new DateTime(1992, 9, 30, 0, 0, 0, DateTimeKind.Utc)
        },
        new ContactEntity
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Ольга Смирнова",
            MobilePhone = "+375293334455",
            JobTitle = "Разработчик",
            BirthDay = new DateTime(1995, 5, 15, 0, 0, 0, DateTimeKind.Utc),
            CreatedAt = new DateTime(1992, 9, 30, 0, 0, 0, DateTimeKind.Utc)
        },
        new ContactEntity
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Name = "Петр Сидоров",
            MobilePhone = "+375297778899",
            JobTitle = "Тестировщик",
            BirthDay = new DateTime(1992, 9, 30, 0, 0, 0, DateTimeKind.Utc),
            CreatedAt = new DateTime(1992, 9, 30, 0, 0, 0, DateTimeKind.Utc)
        }
    };
        }
    }
}
