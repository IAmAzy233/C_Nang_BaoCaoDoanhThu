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
    public class DONHANGsController : Controller
    {
        private readonly acomptec_shoDidongCTNDContext _context = new acomptec_shoDidongCTNDContext();


        // GET: DONHANGs
        public async Task<IActionResult> Index()
        {
            var acomptec_shoDidongCTNDContext = _context.Donhang.Include(d => d.Kh);
            return View(await acomptec_shoDidongCTNDContext.ToListAsync());
        }

        // GET: DONHANGs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhang
                .Include(d => d.Kh)
                .FirstOrDefaultAsync(m => m.DhId == id);
            if (donhang == null)
            {
                return NotFound();
            }

            return View(donhang);
        }
        public async Task<IActionResult> Print(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhang
                .Include(d => d.Kh)
                .Include(c=> c.Chitietdonhang)
                .FirstOrDefaultAsync(m => m.DhId == id);
            if (donhang == null)
            {
                return NotFound();
            }

            return View(donhang);
        }

        // GET: DONHANGs/Create
        public IActionResult Create()
        {
            ViewData["KhId"] = new SelectList(_context.Khachhang, "KhId", "KhId");
            return View();
        }

        // POST: DONHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DhId,DhThoigianmua,DhTinhtrangdonhang,DhTinhtranggiaohang,KhId,DhTongtien")] Donhang donhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhId"] = new SelectList(_context.Khachhang, "KhId", "KhId", donhang.KhId);
            return View(donhang);
        }

        // GET: DONHANGs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhang.FindAsync(id);
            if (donhang == null)
            {
                return NotFound();
            }
            ViewData["KhId"] = new SelectList(_context.Khachhang, "KhId", "KhId", donhang.KhId);
            return View(donhang);
        }

        // POST: DONHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DhId,DhThoigianmua,DhTinhtrangdonhang,DhTinhtranggiaohang,KhId,DhTongtien")] Donhang donhang)
        {
            if (id != donhang.DhId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonhangExists(donhang.DhId))
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
            ViewData["KhId"] = new SelectList(_context.Khachhang, "KhId", "KhId", donhang.KhId);
            return View(donhang);
        }

        // GET: DONHANGs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhang
                .Include(d => d.Kh)
                .FirstOrDefaultAsync(m => m.DhId == id);
            if (donhang == null)
            {
                return NotFound();
            }

            return View(donhang);
        }

        // POST: DONHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var donhang = await _context.Donhang.FindAsync(id);
            _context.Donhang.Remove(donhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonhangExists(string id)
        {
            return _context.Donhang.Any(e => e.DhId == id);
        }
    }
}
