using Microsoft.AspNetCore.Mvc;
using Paschoalotto.Application.Services;
using Paschoalotto.Infrastructure.Data;
using Paschoalotto.Model;
using System;
using System.Threading.Tasks;

namespace Paschoalotto.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class DebtController : ControllerBase
    {
        private readonly IReadRepository<Debt> _repository;
        private readonly IDebtService _service;

        public DebtController(IReadRepository<Debt> repository, IDebtService service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));

        }

        [HttpPost("add-debt")]
        public async Task<Debt> CreateDebt(Debt debt)
        {
            var result = await _service.Create(debt);
            return result;
        }

        [HttpGet]
        public IActionResult GetDebt()
        {
            return Ok(_repository.FindAll());
        }
    }
}
