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
        
    }
}
