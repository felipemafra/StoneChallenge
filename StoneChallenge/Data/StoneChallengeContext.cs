using Microsoft.EntityFrameworkCore;
using StoneChallenge.Models;

public class StoneChallengeContext : DbContext
{
    public DbSet<Funcionario> Funcionario { get; set; }

    public StoneChallengeContext(DbContextOptions<StoneChallengeContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

}
