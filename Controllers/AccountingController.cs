using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using p1.DTO;
using p1.Entities;
using p1.Intefaces;

namespace p1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        private readonly IAccountingRepository _accountingRepository;
        public AccountingController(IAccountingRepository accountingRepository)
        {
            _accountingRepository = accountingRepository;
        }
        [HttpPost("form")]
        public IActionResult Post(DebtFormDto  debtForm)
        {
            if(debtForm == null)
                return BadRequest("invalid form!");
            _accountingRepository.DebtRegister(debtForm);
            return Ok(debtForm);
        }
        [HttpGet("GetAllDebtRegs")]
        public IActionResult GetAllDebtRegs()
        {
            return Ok(_accountingRepository.GetAllDebts());
        }
    }
}
