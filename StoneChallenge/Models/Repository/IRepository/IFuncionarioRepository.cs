namespace StoneChallenge.Models.Repository.IRepository
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        void Update(Funcionario funcionario);
    }
}
