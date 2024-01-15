using RLRP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLRP.Core.ViewModels
{
  public class ProjectManagerViewModel
  {
    public Project Project { get; set; }
    public IEnumerable<Area> Areas { get; set; }

  }
}
