using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemOckovania.Models;
using SystemOckovania.Services;
using SystemOckovanie.Models;

namespace FirmaApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly OckovaciSystemDbContext _context;

        public AccountController(OckovaciSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccount()
        {
            return await _context.Account.ToListAsync();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var accountExist = _context.Account.FirstOrDefault(parX => parX.Id == id);
            if (accountExist == null)
            {
                return null;
            }

            var account = await _context.Account.FindAsync(id);            

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }        

        // PUT: api/Account/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            if (account.StoredSalt == "chp")
            {
                account.StoredSalt = SecurityHelper.GenerateSalt(70);
                account.Password = SecurityHelper.HashPassword(account.Password, account.StoredSalt);
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        

        // POST: api/Account
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {

            if (account.Mail == null || account.Mail == "" || account.Password == null ||
                account.Password == "") 
            {
                return null;
            }

            if (account.Id == -1)
            {
                var accountCompare = _context.Account.FirstOrDefault(accountX => accountX.Mail == account.Mail);

                if (accountCompare == null) 
                {
                    return null;
                }

                if (SecurityHelper.VerifyPassword(account.Password,accountCompare.Password, accountCompare.StoredSalt))
                {
                    return accountCompare;
                }
                else
                {                       
                    return account;
                }
            }

            if (account.StoredSalt == "reg") {
                var accountExist = _context.Account.FirstOrDefault(accountX => accountX.Id == account.Id);
                
                if (accountExist != null) {
                    return null;
                }

                var accountMail = _context.Account.FirstOrDefault(accountX => accountX.Mail == account.Mail);

                if (accountMail != null)
                {                    
                    return account;
                }
            }


            account.StoredSalt = SecurityHelper.GenerateSalt(70);
            account.Password = SecurityHelper.HashPassword(account.Password, account.StoredSalt);
            

            
            _context.Account.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Account.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return _context.Account.Any(e => e.Id == id);
        }
       
    }    

}
