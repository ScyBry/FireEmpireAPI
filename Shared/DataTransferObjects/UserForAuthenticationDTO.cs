using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Shared.DataTransferObjects;

public record UserForAuthenticationDTO
{
    [Required(ErrorMessage = "Login is required")]
    [MaxLength(100, ErrorMessage = "Login cannot be longer than 100 characters")]
    public string? Login { get; init; }
    
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
    
};  