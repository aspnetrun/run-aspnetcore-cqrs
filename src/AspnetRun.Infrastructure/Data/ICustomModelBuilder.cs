using Microsoft.EntityFrameworkCore;

namespace AspnetRun.Infrastructure.Data
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
