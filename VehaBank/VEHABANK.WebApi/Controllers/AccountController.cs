using Microsoft.AspNetCore.Mvc;
using VEHABANK.WebApi.Context;
using VEHABANK.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace VEHABANK.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAccountsByUserId/{userId}")]
        public async Task<ActionResult<List<AccountDto>>> GetAccountsByUserId(int userId)
        {
            var accounts = await _context.Accounts
                .Where(a => a.UserId == userId && a.IsActive)
                .Select(a => new AccountDto
                {
                    IBAN = a.IBAN,
                    Balance = a.Balance
                })
                .ToListAsync();

            return Ok(accounts);
        }
    }
}
