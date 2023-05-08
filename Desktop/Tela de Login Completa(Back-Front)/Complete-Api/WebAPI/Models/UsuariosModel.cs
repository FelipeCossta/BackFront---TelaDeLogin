using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;
[Index(nameof(Email), IsUnique =true)]
public class UsuariosModel
{
    public int Id { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? Password { get; set; }
}
