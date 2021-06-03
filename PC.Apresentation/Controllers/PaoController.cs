using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PC.Apresentation.Data;
using PC.Apresentation.Models;

namespace PC.Apresentation.Controllers
{
    public class PaoController : Controller
    {
        private readonly PCApresentationContext _context;

        public PaoController(PCApresentationContext context)
        {
            _context = context;
        }

        // GET: Pao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pao.ToListAsync());
        }

        // GET: Pao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pao = await _context.Pao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pao == null)
            {
                return NotFound();
            }

            return View(pao);
        }

        // GET: Pao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Valor")] Pao pao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pao);
        }

        // GET: Pao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pao = await _context.Pao.FindAsync(id);
            if (pao == null)
            {
                return NotFound();
            }
            return View(pao);
        }

        // POST: Pao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Valor")] Pao pao)
        {
            if (id != pao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaoExists(pao.Id))
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
            return View(pao);
        }

        // GET: Pao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pao = await _context.Pao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pao == null)
            {
                return NotFound();
            }

            return View(pao);
        }

        // POST: Pao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pao = await _context.Pao.FindAsync(id);
            _context.Pao.Remove(pao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaoExists(int id)
        {
            return _context.Pao.Any(e => e.Id == id);
        }
    }
}
