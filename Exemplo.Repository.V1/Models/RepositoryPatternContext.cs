using Microsoft.EntityFrameworkCore;

namespace Exemplo.Repository.V1.Models
{
    public class RepositoryPatternContext: DbContext
    {
        public RepositoryPatternContext(DbContextOptions<RepositoryPatternContext> option): base(option)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
