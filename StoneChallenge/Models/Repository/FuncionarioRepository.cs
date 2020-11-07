using StoneChallenge.Models.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge.Models.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        private readonly StoneChallengeContext _context;

        public FuncionarioRepository(StoneChallengeContext context)
            : base(context)
        {
            _context = context;
        }

        public void Update(Funcionario funcionario)
        {
            var objFromDb = _context.Funcionario.FirstOrDefault(s => s.Id == funcionario.Id);

            objFromDb.Nome = funcionario.Nome;
            objFromDb.Departamento = funcionario.Departamento;
            objFromDb.Cargo = funcionario.Cargo;
            objFromDb.SalarioBruto = funcionario.SalarioBruto;
            objFromDb.DataDeAdmissao = funcionario.DataDeAdmissao;

            _context.SaveChanges();
        }
    }
}
