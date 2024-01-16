using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLRP.Core.Models
{
  public class Project : BaseEntity
  {

    [StringLength(40)]
    [DisplayName("Project Title")]
    public string Title { get; set; }
    public string Area { get; set; }
    public string Status { get; set; }
    public string OldNbr { get; set; }
    public DateTime DefinedDate { get; set; }
    public decimal BudgetYear { get; set; }
    public decimal BudgetCost { get; set; }
    public decimal BudgetLife { get; set; }
    public string OddEven { get; set; }
    public string Notes { get; set; }

  }
}
