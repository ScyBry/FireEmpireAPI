using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Application
{
    [Column("ApplicationID")] public Guid Id { get; set; }
    public string Type { get; set; }
}