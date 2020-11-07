using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Models.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IFuncionarioRepository Funcionario { get; }

        void Save();
    }
}
