using RLRP.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLRP.DataAccess.SQL
{
  public class DataContext : DbContext
  {
    public DataContext()
      :base("DefaultConnection")
    {

    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Area> Areas { get; set; }
  }
}
