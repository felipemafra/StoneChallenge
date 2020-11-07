using StoneChallenge.Models.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoneChallengeContext _context;

        public UnitOfWork(StoneChallengeContext context)
        {
            _context = context;
            Funcionario = new FuncionarioRepository(context);
        }

        public IFuncionarioRepository Funcionario { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
