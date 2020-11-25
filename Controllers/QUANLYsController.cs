using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn1_BanFinal.Models;

namespace DoAn1_BanFinal.Controllers
{
    public class QUANLYsController : Controller
    {
        private readonly acomptec_shoDidongCTNDContext _context;

        public QUANLYsController(acomptec_shoDidongCTNDContext context)
        {
            _context = context;
        }

        // GET: QUANLYs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quanly.ToListAsync());
        }

        // GET: QUANLYs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanly = await _context.Quanly
                .FirstOrDefaultAsync(m => m.QlId == id);
            if (quanly == null)
            {
                return NotFound();
            }

            return View(quanly);
        }

        // GET: QUANLYs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QUANLYs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QlId,QlTen")] Quanly quanly)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanly);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanly);
        }

        // GET: QUANLYs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanly = await _context.Quanly.FindAsync(id);
            if (quanly == null)
            {
                return NotFound();
            }
            return View(quanly);
        }

        // POST: QUANLYs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("QlId,QlTen")] Quanly quanly)
        {
            if (id != quanly.QlId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanly);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanlyExists(quanly.QlId))
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
            return View(quanly);
        }

        // GET: QUANLYs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanly = await _context.Quanly
                .FirstOrDefaultAsync(m => m.QlId == id);
            if (quanly == null)
            {
                return NotFound();
            }

            return View(quanly);
        }

        // POST: QUANLYs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var quanly = await _context.Quanly.FindAsync(id);
            _context.Quanly.Remove(quanly);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanlyExists(string id)
        {
            return _context.Quanly.Any(e => e.QlId == id);
        }
    }
}
