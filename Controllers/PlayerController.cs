using Microsoft.AspNetCore.Mvc;
using JugadoresFutbolPeruano.Data;
using JugadoresFutbolPeruano.Models;

namespace JugadoresFutbolPeruano.Controllers
{
    public class PlayerController : Controller
    {
        private readonly AppDbContext _context;

        public PlayerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Teams = _context.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Players.Add(player);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Teams = _context.Teams.ToList();
            return View(player);
        }
    }
}