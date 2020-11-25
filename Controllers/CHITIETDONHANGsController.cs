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
    public class CHITIETDONHANGsController : Controller
    {
        private readonly acomptec_shoDidongCTNDContext _context = new acomptec_shoDidongCTNDContext();

        // GET: CHITIETDONHANGs
        public async Task<IActionResult> Index()
        {
            var acomptec_shoDidongCTNDContext = _context.Chitietdonhang.Include(c => c.Dh).Include(c => c.Sp);
            return View(await acomptec_shoDidongCTNDContext.ToListAsync());
        }

        // GET: CHITIETDONHANGs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietdonhang = await _context.Chitietdonhang
                .Include(c => c.Dh)
                .Include(c => c.Sp)
                .FirstOrDefaultAsync(m => m.CtDhId == id);
            if (chitietdonhang == null)
            {
                return NotFound();
            }

            return View(chitietdonhang);
        }

        // GET: CHITIETDONHANGs/Create
        public IActionResult Create()
        {
            ViewData["DhId"] = new SelectList(_context.Donhang, "DhId", "DhId");
            ViewData["SpId"] = new SelectList(_context.Sanpham, "SpId", "SpId");
            return View();
        }

        // POST: CHITIETDONHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CtDhId,SpId,DhId,CtDhSoluong,CtDhThanhtien")] Chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitietdonhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DhId"] = new SelectList(_context.Donhang, "DhId", "DhId", chitietdonhang.DhId);
            ViewData["SpId"] = new SelectList(_context.Sanpham, "SpId", "SpId", chitietdonhang.SpId);
            return View(chitietdonhang);
        }

        // GET: CHITIETDONHANGs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietdonhang = await _context.Chitietdonhang.FindAsync(id);
            if (chitietdonhang == null)
            {
                return NotFound();
            }
            ViewData["DhId"] = new SelectList(_context.Donhang, "DhId", "DhId", chitietdonhang.DhId);
            ViewData["SpId"] = new SelectList(_context.Sanpham, "SpId", "SpId", chitietdonhang.SpId);
            return View(chitietdonhang);
        }

        // POST: CHITIETDONHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CtDhId,SpId,DhId,CtDhSoluong,CtDhThanhtien")] Chitietdonhang chitietdonhang)
        {
            if (id != chitietdonhang.CtDhId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitietdonhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitietdonhangExists(chitietdonhang.CtDhId))
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
            ViewData["DhId"] = new SelectList(_context.Donhang, "DhId", "DhId", chitietdonhang.DhId);
            ViewData["SpId"] = new SelectList(_context.Sanpham, "SpId", "SpId", chitietdonhang.SpId);
            return View(chitietdonhang);
        }

        // GET: CHITIETDONHANGs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietdonhang = await _context.Chitietdonhang
                .Include(c => c.Dh)
                .Include(c => c.Sp)
                .FirstOrDefaultAsync(m => m.CtDhId == id);
            if (chitietdonhang == null)
            {
                return NotFound();
            }

            return View(chitietdonhang);
        }

        // POST: CHITIETDONHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chitietdonhang = await _context.Chitietdonhang.FindAsync(id);
            _context.Chitietdonhang.Remove(chitietdonhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitietdonhangExists(string id)
        {
            return _context.Chitietdonhang.Any(e => e.CtDhId == id);
        }
    }
}
