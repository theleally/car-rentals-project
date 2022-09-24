using Microsoft.EntityFrameworkCore;
using car_rentals_project.Models;

namespace car_rentals_project.Models
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    //public DbSet<Funcionario> Funcionarios { get; set; }
  }
}