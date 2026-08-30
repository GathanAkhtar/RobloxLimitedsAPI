using Microsoft.EntityFrameworkCore;
using RobloxLimitedsAPI.Models;

namespace RobloxLimitedsAPI.Data
{
     public class AppDbContext (DbContextOptions<AppDbContext> options): DbContext(options)
     {
          public DbSet<Items> Items => Set<Items>();
     }
}
