using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder.ToTable("Contacts");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.MobilePhone)
                .IsRequired();

            builder.Property(c => c.JobTitle)
                .HasMaxLength(50);

            builder.Property(c => c.BirthDay)
                .IsRequired();



            builder.HasData(
                 new ContactEntity
                 {
                     Id = Guid.NewGuid(),
                     Name = "Иван Иванов",
                     MobilePhone = "+375291112233",
                     JobTitle = "Менеджер",
                     BirthDay = new DateTime(1990, 1, 1),

                 },
                 new ContactEntity
                 {
                     Id = Guid.NewGuid(),
                     Name = "Ольга Смирнова",
                     MobilePhone = "+375293334455",
                     JobTitle = "Разработчик",
                     BirthDay = new DateTime(1995, 5, 15),

                 },
                 new ContactEntity
                 {
                     Id = Guid.NewGuid(),
                     Name = "Петр Сидоров",
                     MobilePhone = "+375297778899",
                     JobTitle = "Тестировщик",
                     BirthDay = new DateTime(1992, 9, 30),

                 }
             );
        }
    }
}