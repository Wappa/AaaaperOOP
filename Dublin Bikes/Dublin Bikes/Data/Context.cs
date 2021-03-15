using Microsoft.EntityFrameworkCore;
using Dublin_Bikes.Models;

namespace Dublin_Bikes.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}
        
    }
}