using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoneChallenge.Models;
using StoneChallenge.Models.Repository.IRepository;
using StoneChallenge.Services.Interfaces;
using System;

namespace StoneChallenge.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICalculadoraDeBonusService _calculadoraDeBonusService;

        public FuncionariosController(IUnitOfWork unitOfWork, ICalculadoraDeBonusService calculadoraDeBonusService)
        {
            _unitOfWork = unitOfWork;
            _calculadoraDeBonusService = calculadoraDeBonusService;
        }

        // GET: Funcionarios
        public IActionResult Index()
        {
            return View(_unitOfWork.Funcionario.GetAll());
        }

        // GET: Funcionarios/Details/5
        public IActionResult Details(int id = 0)
        {
            Funcionario funcionario = _unitOfWork.Funcionario.GetById(id) as Funcionario;
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,Departamento,Cargo,SalarioBruto,DataDeAdmissao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Funcionario.Insert(funcionario);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = _unitOfWork.Funcionario.GetById(id.GetValueOrDefault());
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome,Departamento,Cargo,SalarioBruto,DataDeAdmissao")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Funcionario.Update(funcionario);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = _unitOfWork.Funcionario.GetFirstOrDefault(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var funcionario = _unitOfWork.Funcionario.GetById(id);
            _unitOfWork.Funcionario.Delete(funcionario);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _unitOfWork.Funcionario.GetFirstOrDefault(e => e.Id == id) is Funcionario;
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetBonus(double bonusDisponivel)
        {
            var funcionarios = _unitOfWork.Funcionario.GetAll();
            return Json(_calculadoraDeBonusService.CalculatarBonus(funcionarios, new Decimal(bonusDisponivel)));
        }
        #endregion
    }
}
