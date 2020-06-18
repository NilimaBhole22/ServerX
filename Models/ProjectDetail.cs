using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApplication.Models
{
  public class ProjectDetail
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Project { get; set; }

  }
}
