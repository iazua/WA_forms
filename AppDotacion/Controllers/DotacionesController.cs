using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppDotacion.Models;  // Asegúrate de que el namespace sea el correcto
using AppDotacion.Data;    // Asegúrate de que el namespace de tu contexto sea el correcto

namespace AppDotacion.Controllers
{
    public class DotacionesController : Controller
    {
        private readonly AppDotacionContext _context;

        // Constructor donde se inyecta el contexto de la base de datos
        public DotacionesController(AppDotacionContext context)
        {
            _context = context;
        }

        // GET: Dotaciones
        public async Task<IActionResult> Index()
        {
            // Obtener todas las dotaciones desde la base de datos
            var dotaciones = await _context.Dotaciones.ToListAsync();
            return View(dotaciones); // Enviar las dotaciones a la vista
        }

        // GET: Dotaciones/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Buscar una dotación por ID
            var dotacion = await _context.Dotaciones
                .FirstOrDefaultAsync(m => m.ID == id);

            if (dotacion == null)
            {
                return NotFound();
            }

            return View(dotacion);
        }

        // GET: Dotaciones/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dotaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Rut_DNI,Agente,Pais_Call_Center,Nombre_Call_Center,Area,AreaGestion,Contrato,Tipos_de_agente,Servicio,Usuarios_RcWeb,Nombre_Jefatura,Rut_Ficticio,Rut_DNI2,DV,Clasifica_Cargo,CARGO,Fecha_Ingreso,Fecha_Baja,N_Personal,Correo")] Dotacion dotacion)
        {
            if (ModelState.IsValid)
            {
                // Agregar la nueva dotación a la base de datos
                _context.Add(dotacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dotacion);
        }

        // GET: Dotaciones/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Buscar la dotación a editar
            var dotacion = await _context.Dotaciones.FindAsync(id);
            if (dotacion == null)
            {
                return NotFound();
            }
            return View(dotacion);
        }

        // POST: Dotaciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("ID,Rut_DNI,Agente,Pais_Call_Center,Nombre_Call_Center,Area,AreaGestion,Contrato,Tipos_de_agente,Servicio,Usuarios_RcWeb,Nombre_Jefatura,Rut_Ficticio,Rut_DNI2,DV,Clasifica_Cargo,CARGO,Fecha_Ingreso,Fecha_Baja,N_Personal,Correo")] Dotacion dotacion)
        {
            if (id != dotacion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Actualizar la dotación en la base de datos
                    _context.Update(dotacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DotacionExists(dotacion.ID))
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
            return View(dotacion);
        }

        // GET: Dotaciones/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Buscar la dotación para eliminar
            var dotacion = await _context.Dotaciones
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dotacion == null)
            {
                return NotFound();
            }

            return View(dotacion);
        }

        // POST: Dotaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            // Eliminar la dotación de la base de datos
            var dotacion = await _context.Dotaciones.FindAsync(id);
            _context.Dotaciones.Remove(dotacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método auxiliar para verificar si una dotación existe
        private bool DotacionExists(short id)
        {
            return _context.Dotaciones.Any(e => e.ID == id);
        }
    }
}
