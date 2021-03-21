using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DublinBikes.Data;
using DublinBikes.Models;

namespace DublinBikes.Controllers
{
    public class BikeStationsController : Controller
    {
        private readonly Context _context;

        public BikeStationsController(Context context)
        {
            _context = context;
        }

        // GET: BikeStations
        public async Task<IActionResult> Index()
        {
            return View(await _context.BikeStation.ToListAsync());
        }

        // GET: BikeStations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikeStation = await _context.BikeStation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bikeStation == null)
            {
                return NotFound();
            }

            return View(bikeStation);
        }

        // GET: BikeStations/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
