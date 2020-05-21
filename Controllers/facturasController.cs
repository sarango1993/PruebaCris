using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaCris.Models;

namespace PruebaCris.Controllers
{
    public class facturasController : Controller
    {
        private readonly PruebaCrisContext _context;

        public facturasController(PruebaCrisContext context)
        {
            _context = context;
        }

        // GET: facturas
        public async Task<IActionResult> Index()
        {
            return View(await _context.factura.ToListAsync());
        }

        // GET: facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.factura
                .FirstOrDefaultAsync(m => m.ID == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: facturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: facturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Numero,Direccion")] factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factura);
        }

        // GET: facturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.factura.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            return View(factura);
        }

        // POST: facturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Numero,Direccion")] factura factura)
        {
            if (id != factura.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!facturaExists(factura.ID))
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
            return View(factura);
        }

        // GET: facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.factura
                .FirstOrDefaultAsync(m => m.ID == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factura = await _context.factura.FindAsync(id);
            _context.factura.Remove(factura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool facturaExists(int id)
        {
            return _context.factura.Any(e => e.ID == id);
        }
    }
}
