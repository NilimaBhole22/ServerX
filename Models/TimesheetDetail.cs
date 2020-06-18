using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApplication.Models
{
  public class TimesheetDetail
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string User { get; set; }

    [Required]
    public string ProjectName { get; set; }

    ///public string RecordDate { get; set; }
    //[Required]
    public int Hour { get; set; }

    [Required]
    public string Comment { get; set; }

  }
}
