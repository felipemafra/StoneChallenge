using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoneChallenge.Models;

    public class StoneChallengeContext : DbContext
    {
        public StoneChallengeContext (DbContextOptions<StoneChallengeContext> options)
            : base(options)
        {
        Database.EnsureCreated();
        }

        public DbSet<StoneChallenge.Models.Funcionario> Funcionario { get; set; }
    }
