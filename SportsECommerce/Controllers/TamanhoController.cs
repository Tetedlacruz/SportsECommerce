using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsECommerce.Data;
using SportsECommerce.Models;

namespace SportsECommerce.Controllers
{
    public class TamanhoController : Controller
    {
        private readonly SportsContext _context;
        public TamanhoController(SportsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tamanhos.OrderBy(i => i.TamanhoID).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] Tamanho tamanho)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tamanho);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possivel cadastrar o tamanho");
            }
            return View(tamanho);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tamanho = await _context.Tamanhos.SingleOrDefaultAsync(i => i.TamanhoID == id);
            if (tamanho == null)
            {
                return NotFound();
            }
            return View(tamanho);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Edit(long id, [Bind("ID","Nome")]Tamanho tamanho)
        {
            if (id != tamanho.TamanhoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tamanho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(tamanho.TamanhoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(tamanho);
        }

        private bool ProdutoExists(long? id)
        {
            var tamanho = _context.Tamanhos.FirstOrDefault(i => i.TamanhoID == id);
            if (tamanho == null)
            {
                return false;
            }
            return true;
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tamanho = await _context.Tamanhos.SingleOrDefaultAsync(i => i.TamanhoID == id);
            if (tamanho == null)
            {
                return NotFound();
            }

            return View(tamanho);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tamanho = await _context.Tamanhos.SingleOrDefaultAsync(i => i.TamanhoID == id);
            if (tamanho == null)
            {
                return NotFound();
            }

            return View(tamanho);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var tamanho = await _context.Tamanhos.SingleOrDefaultAsync(i => i.TamanhoID == id);
            _context.Tamanhos.Remove(tamanho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
