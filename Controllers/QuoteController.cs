using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuoteApi.Models;
using QuoteApi.Helpers;


namespace QuoteApi.Controllers
{
    #region QuoteController
    [ApiController]
    [Route("api/quote")]

    public class QuoteController : ControllerBase
    {
        //private readonly QuoteContext _context;
        private readonly PremiumContext _premiumContext;
        private readonly ILogger<QuoteController> _logger;

        private FormulaHelper helper = new FormulaHelper();

        public QuoteController(ILogger<QuoteController> logger, QuoteContext context, PremiumContext premiumContext)
        {
            _logger = logger; //If had more time i'f add a logger, used them in my previous role and were very handy in debugging!
            //_context = context; //The idea was to have 2 Dbs running so a user could have accsses to both the sent data and posted result always but its over kill in this situation
            _premiumContext = premiumContext;
        }
        #endregion

        // GET: api/QuoteItems
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<QuoteItem>>> GetQuoteItems()
        // {
        //     return await _context.QuoteItems.ToListAsync();
        // }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PremiumItem>>> GetPremiumItems()
        {
            return await _premiumContext.PremiumItems.ToListAsync();
        }
        // GET: api/QuoteItems/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<QuoteItem>> GetQuoteItem(long id)
        // {
        //     var quoteItem = await _context.QuoteItems.FindAsync(id);

        //     if (quoteItem == null)
        //     {
        //         return NotFound();
        //     }

        //     return quoteItem;
        // }
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
        // POST: api/QuoteItems[Route("api/quote")]
        // [HttpPost]
        // public async Task<ActionResult<PremiumItem>> PostQuoteItem(QuoteItem quoteItem)
        // {
        //     _context.QuoteItems.Add(quoteItem);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetQuoteItem), new { id = quoteItem.Id }, quoteItem);
        // }

        [HttpPost]
        public async Task<ActionResult<PremiumItem>> PostPremiumItem(QuoteItem quoteItem)
        {
            var premiumItem = helper.Calculate(quoteItem);

            _premiumContext.PremiumItems.Add(premiumItem);
            await _premiumContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPremiumItem), new { id = premiumItem.Id }, premiumItem);
        }
        #endregion
    }
}