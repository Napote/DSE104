using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvcPeliculas.Models;

namespace mvcPeliculas.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly PeliculaDBContext _context;
  
        public PeliculasController(PeliculaDBContext context)
        {
            _context = context;
        }

        // GET: Peliculas
        public async Task<IActionResult> Index(string searchDirector, string genero)

        {
            
            var peliculas = from p in _context.Peliculas select p;
            var GeneroQry = from g in _context.Peliculas 
                                orderby g.Genero
                                select g.Genero;

            var GeneroLst = new List<String>();

            GeneroLst.AddRange(GeneroQry.Distinct());

            ViewBag.genero = new SelectList(GeneroLst);


            List<SelectListItem> DirectorLst = (from p in _context.Directores.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = p.Nombre,
                                                    Value = p.ID.ToString()
                                                }).ToList();
            ViewBag.directores = DirectorLst;

            if (!string.IsNullOrEmpty(searchDirector))
            {
                peliculas = peliculas.Where(s => s.DirectorMubi.Nombre.Contains(searchDirector));
            }

            if (!string.IsNullOrEmpty(genero))
            {
                peliculas = peliculas.Where(x => x.Genero == genero);
            }

            return View(await peliculas.ToListAsync());
        }

        // GET: Peliculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            List<SelectListItem> DirectorLst = (from p in _context.Directores.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = p.Nombre,
                                                    Value = p.ID.ToString()
                                                }).ToList();
            ViewBag.directores = DirectorLst;

            return View(pelicula);
        }

        // GET: Peliculas/Create
        public IActionResult Create()
        {
            //Enviando lista de directores a la vista
            List<SelectListItem> DirectorLst = (from p in _context.Directores.ToList()
                select new SelectListItem
                {
                    Text = p.Nombre,
                    Value = p.ID.ToString()
                }).ToList();
            ViewBag.directores = DirectorLst;
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,FechaLanzamiento,Genero,Precio,Calificacion,Productor,Director_ID")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                 _context.Add(pelicula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            List<SelectListItem> DirectorLst = (from p in _context.Directores.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = p.Nombre,
                                                    Value = p.ID.ToString()
                                                }).ToList();
            ViewBag.directores = DirectorLst;

            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,FechaLanzamiento,Genero,Precio,Calificacion,Productor,Director_ID")] Pelicula pelicula)
        {
            if (id != pelicula.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelicula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(pelicula.ID))
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
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            _context.Peliculas.Remove(pelicula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaExists(int id)
        {
            return _context.Peliculas.Any(e => e.ID == id);
        }
    }
}
