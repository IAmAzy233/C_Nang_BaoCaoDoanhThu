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
    public class SANPHAMsController : Controller
    {
        private readonly acomptec_shoDidongCTNDContext _context = new acomptec_shoDidongCTNDContext();


        // GET: SANPHAMs
        public async Task<IActionResult> Index()
        {
            var acomptec_shoDidongCTNDContext = _context.Sanpham.Include(s => s.Dm);
            return View(await acomptec_shoDidongCTNDContext.ToListAsync());
        }

        // GET: SANPHAMs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .Include(s => s.Dm)
                .FirstOrDefaultAsync(m => m.SpId == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: SANPHAMs/Create
        public IActionResult Create()
        {
            ViewData["DmId"] = new SelectList(_context.Danhmuc, "DmId", "DmId");
            return View();
        }

        // POST: SANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpId,DmId,HaId,SpTen,SpHangsanxuat,SpKichthuocmanhinh,SpDophangiai,SpHedieuhanh,SpChipxuli,SpRam,SpRom,SpDungluongpin,SpDongia,SpHinhanh")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DmId"] = new SelectList(_context.Danhmuc, "DmId", "DmId", sanpham.DmId);
            return View(sanpham);
        }

        // GET: SANPHAMs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["DmId"] = new SelectList(_context.Danhmuc, "DmId", "DmId", sanpham.DmId);
            return View(sanpham);
        }

        // POST: SANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SpId,DmId,HaId,SpTen,SpHangsanxuat,SpKichthuocmanhinh,SpDophangiai,SpHedieuhanh,SpChipxuli,SpRam,SpRom,SpDungluongpin,SpDongia,SpHinhanh")] Sanpham sanpham)
        {
            if (id != sanpham.SpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.SpId))
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
            ViewData["DmId"] = new SelectList(_context.Danhmuc, "DmId", "DmId", sanpham.DmId);
            return View(sanpham);
        }

        // GET: SANPHAMs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .Include(s => s.Dm)
                .FirstOrDefaultAsync(m => m.SpId == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sanpham = await _context.Sanpham.FindAsync(id);
            _context.Sanpham.Remove(sanpham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(string id)
        {
            return _context.Sanpham.Any(e => e.SpId == id);
        }
    }
}
