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
        public IActionResult Create()
        {
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
