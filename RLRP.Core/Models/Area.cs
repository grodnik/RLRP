using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLRP.Core.Models
{
  public class Area
  {
    public string Id { get; set; }
    public string AreaName { get; set; }

    public Area()
    {
      this.Id = Guid.NewGuid().ToString();
    }
  }
}
