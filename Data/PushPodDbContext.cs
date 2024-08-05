using Microsoft.EntityFrameworkCore;

namespace pushpod.Data;

public class PushPodDbContext : DbContext
{
	public DbSet<pushpod.Models.Repository> Repositories { get; set; } = null!;
	
	public PushPodDbContext(DbContextOptions<PushPodDbContext> options) : base(options) {}
}
