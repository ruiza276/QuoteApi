using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuoteApi.Models;
using QuoteApi.Helpers;

namespace QuoteApi.Controllers
{
    #region PremiumController
    [ApiController]

    public class PremiumController : ControllerBase
    {
        private readonly PremiumContext _premiumContext;
        private readonly ILogger<PremiumController> _logger;//If had more time id add a logger, used them in my previous role and they were very handy in debugging!

        private FormulaHelper helper = new FormulaHelper();

        public PremiumController(ILogger<PremiumController> logger, PremiumContext premiumContext)
        {
            _logger = logger; 
            _premiumContext = premiumContext;
        }
        #endregion

        [Route("api/quote")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuoteItem>>> GetQuoteItems()
        {
            return await _premiumContext.QuoteItems.ToListAsync();
        }

        [Route("api/quote")]
        [HttpGet("{id}/quotes")]
        public async Task<ActionResult<QuoteItem>> GetQuoteItem(int id, double revenue)
        {
            var quoteItem = await _premiumContext.QuoteItems.FindAsync(id);

            if (quoteItem == null)
            {
                return NotFound();
            }

            return quoteItem;
        }

        [Route("api/premium")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PremiumItem>>> GetPremiumItems()
        {
            return await _premiumContext.PremiumItems.ToListAsync();
        }

        [Route("api/premium")]
        [HttpGet("{id}")]
        public async Task<ActionResult<PremiumItem>> GetPremiumItem(long id)
        {
            var premiumItem = await _premiumContext.PremiumItems.FindAsync(id);

            if (premiumItem == null)
            {
                return NotFound();
            }

            return premiumItem;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        #region snippet_Create
        [Route("api/premium")]
        [HttpPost]
        public async Task<ActionResult<PremiumItem>> PostPremiumItem(QuoteItem quoteItem)
        {
            var premiumItem = helper.Calculate(quoteItem);

            _premiumContext.QuoteItems.Add(quoteItem);
            _premiumContext.PremiumItems.Add(premiumItem);
            await _premiumContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPremiumItem), new { id = premiumItem.Id }, premiumItem);
        }
        #endregion
    }
}