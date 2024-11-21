using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Editortext.Data;
using Editortext.Models;

namespace Editortext.Controllers
{
    public class ArchivoEditorsController : Controller
    {
        private readonly EditortextContext _context;

        public ArchivoEditorsController(EditortextContext context)
        {
            _context = context;
        }

        // GET: ArchivoEditors
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArchivoEditor.ToListAsync());
        }

        // GET: ArchivoEditors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivoEditor = await _context.ArchivoEditor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (archivoEditor == null)
            {
                return NotFound();
            }

            return View(archivoEditor);
        }

        // GET: ArchivoEditors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArchivoEditors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Contenido,FechaCreacion,FechaActualizacion")] ArchivoEditor archivoEditor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(archivoEditor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(archivoEditor);
        }

        // GET: ArchivoEditors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivoEditor = await _context.ArchivoEditor.FindAsync(id);
            if (archivoEditor == null)
            {
                return NotFound();
            }
            return View(archivoEditor);
        }

        // POST: ArchivoEditors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Contenido,FechaCreacion,FechaActualizacion")] ArchivoEditor archivoEditor)
        {
            if (id != archivoEditor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(archivoEditor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchivoEditorExists(archivoEditor.Id))
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
            return View(archivoEditor);
        }

        // GET: ArchivoEditors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivoEditor = await _context.ArchivoEditor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (archivoEditor == null)
            {
                return NotFound();
            }

            return View(archivoEditor);
        }

        // POST: ArchivoEditors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var archivoEditor = await _context.ArchivoEditor.FindAsync(id);
            if (archivoEditor != null)
            {
                _context.ArchivoEditor.Remove(archivoEditor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchivoEditorExists(int id)
        {
            return _context.ArchivoEditor.Any(e => e.Id == id);
        }
    }
}
