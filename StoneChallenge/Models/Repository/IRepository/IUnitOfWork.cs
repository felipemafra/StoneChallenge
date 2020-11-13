using System;

namespace StoneChallenge.Models.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IFuncionarioRepository Funcionario { get; }

        void Save();
    }
}
