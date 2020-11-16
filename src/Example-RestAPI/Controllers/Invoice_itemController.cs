using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example_RestAPI.Models;

namespace Example_RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Invoice_itemController : ControllerBase
    {
        private readonly ChinookContext _context;

        public Invoice_itemController()
        {
            _context = new ChinookContext();
        }

        // GET: api/Invoice_item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice_item>>> GetInvoice_Items()
        {
            return await _context.Invoice_Items.ToListAsync();
        }

        // GET: api/Invoice_item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice_item>> GetInvoice_item(int id)
        {
            var invoice_item = await _context.Invoice_Items.FindAsync(id);

            if (invoice_item == null)
            {
                return NotFound();
            }

            return invoice_item;
        }

        // PUT: api/Invoice_item/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice_item(int id, Invoice_item invoice_item)
        {
            if (id != invoice_item.InvoiceLineID)
            {
                return BadRequest();
            }

            _context.Entry(invoice_item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Invoice_itemExists(id))
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

        // POST: api/Invoice_item
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Invoice_item>> PostInvoice_item(Invoice_item invoice_item)
        {
            _context.Invoice_Items.Add(invoice_item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice_item", new { id = invoice_item.InvoiceLineID }, invoice_item);
        }

        // DELETE: api/Invoice_item/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoice_item>> DeleteInvoice_item(int id)
        {
            var invoice_item = await _context.Invoice_Items.FindAsync(id);
            if (invoice_item == null)
            {
                return NotFound();
            }

            _context.Invoice_Items.Remove(invoice_item);
            await _context.SaveChangesAsync();

            return invoice_item;
        }

        private bool Invoice_itemExists(int id)
        {
            return _context.Invoice_Items.Any(e => e.InvoiceLineID == id);
        }
    }
}
