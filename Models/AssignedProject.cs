using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApplication.Models
{
  public class AssignedProject
  {
    [Key]
    public int Id { get; set; }

    public string User { get; set; }

    //[ForeignKey("UserId")]
    //public RegistrationDetail registerDetails { get; set; }
    public string Project { get; set; }

    //[ForeignKey("ProjectId")]
    //public ProjectDetail projectDetails { get; set; }
  }
}
