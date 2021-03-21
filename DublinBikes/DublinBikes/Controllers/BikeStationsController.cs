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

        // POST: BikeStations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractName,Name,adress,latitude,longitude,banking,AvailableBikes,AvailableStands,Capacity,Status")] BikeStation bikeStation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bikeStation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bikeStation);
        }

        // GET: BikeStations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikeStation = await _context.BikeStation.FindAsync(id);
            if (bikeStation == null)
            {
                return NotFound();
            }
            return View(bikeStation);
        }

        // POST: BikeStations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContractName,Name,adress,latitude,longitude,banking,AvailableBikes,AvailableStands,Capacity,Status")] BikeStation bikeStation)
        {
            if (id != bikeStation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bikeStation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeStationExists(bikeStation.Id))
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
            return View(bikeStation);
        }

        // GET: BikeStations/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: BikeStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bikeStation = await _context.BikeStation.FindAsync(id);
            _context.BikeStation.Remove(bikeStation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikeStationExists(int id)
        {
            return _context.BikeStation.Any(e => e.Id == id);
        }
    }
}
