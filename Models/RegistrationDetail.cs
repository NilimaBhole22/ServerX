using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApplication.Models
{
  public class RegistrationDetail
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password must match.")]
    public string ConfirmPassword { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string UserId { get; set; }
  }
}
