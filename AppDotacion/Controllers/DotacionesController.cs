using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppDotacion.Models;
using AppDotacion.Data;

namespace AppDotacion.Controllers
{
    public class DotacionesController : Controller
    {
        private readonly AppDotacionContext _context;

        public DotacionesController(AppDotacionContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dotaciones = await _context.Dotaciones.ToListAsync();
            return View(dotaciones);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Obtener opciones únicas de cada columna desde la base de datos
            ViewData["Pais_Call_Center"] = await _context.Dotaciones
                .Select(d => d.Pais_Call_Center)
                .Distinct()
                .ToListAsync();

            ViewData["Area"] = await _context.Dotaciones
                .Select(d => d.Area)
                .Distinct()
                .ToListAsync();

            ViewData["AreaGestion"] = await _context.Dotaciones
                .Select(d => d.AreaGestion)
                .Distinct()
                .ToListAsync();

            ViewData["Contrato"] = await _context.Dotaciones
                .Select(d => d.Contrato.ToString())
                .Distinct()
                .ToListAsync();

            ViewData["Tipos_de_agente"] = await _context.Dotaciones
                .Select(d => d.Tipos_de_agente)
                .Distinct()
                .ToListAsync();

            ViewData["Servicio"] = await _context.Dotaciones
                .Select(d => d.Servicio)
                .Distinct()
                .ToListAsync();

            ViewData["Nombre_Jefatura"] = await _context.Dotaciones
                .Select(d => d.Nombre_Jefatura)
                .Where(d => d != null)
                .Distinct()
                .ToListAsync();

            ViewData["Clasifica_Cargo"] = await _context.Dotaciones
                .Select(d => d.Clasifica_Cargo)
                .Where(d => d != null)
                .Distinct()
                .ToListAsync();

            ViewData["CARGO"] = await _context.Dotaciones
                .Select(d => d.CARGO)
                .Where(d => d != null)
                .Distinct()
                .ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rut_DNI,Agente,Pais_Call_Center,Nombre_Call_Center,Area,AreaGestion,Contrato,Tipos_de_agente,Servicio,Usuarios_RcWeb,Nombre_Jefatura,Rut_Ficticio,Rut_DNI2,DV,Clasifica_Cargo,CARGO,Fecha_Ingreso,Fecha_Baja,N_Personal,Correo")] Dotacion dotacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dotacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dotacion);
        }
    }
}
