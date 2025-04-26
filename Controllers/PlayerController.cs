using Microsoft.AspNetCore.Mvc;
using JugadoresFutbolPeruano.Data;
using JugadoresFutbolPeruano.Models;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult Index()
        {
            var players = _context.Players
                .Include(p => p.Team) // Incluye la información del equipo
                .ToList();
            return View(players);
        }

        [HttpGet]
        public IActionResult Associate()
        {
            ViewBag.Players = _context.Players.ToList();
            ViewBag.Teams = _context.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Associate(int playerId, int teamId)
        {
            var player = _context.Players.Find(playerId);
            var team = _context.Teams.Find(teamId);

            if (player != null && team != null)
            {
                player.TeamId = teamId;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}