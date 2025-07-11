using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageServiceApp.Data;
using GarageServiceApp.Models;

namespace GarageServiceApp.Controllers
{
    public class ServiceReceivedsController : Controller
    {
        private readonly GarageServiceAppContext _context;

        public ServiceReceivedsController(GarageServiceAppContext context)
        {
            _context = context;
        }

        // GET: ServiceReceiveds
        public async Task<IActionResult> Index()
        {
            var garageServiceAppContext = _context.ServiceReceived.Include(s => s.Customer);
            return View(await garageServiceAppContext.ToListAsync());
        }

        // GET: ServiceReceiveds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceReceived = await _context.ServiceReceived
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceReceived == null)
            {
                return NotFound();
            }

            return View(serviceReceived);
        }

        // GET: ServiceReceiveds/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name");
            return View();
        }

        // POST: ServiceReceiveds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,CarModel,LicensePlate,VIN,StateBeforeRepair,CustomerComplaint,InitialDiagnosis,EstimatedCost,ReceivedDate,Notes,TechnicianName")] ServiceReceived serviceReceived)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceReceived);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", serviceReceived.CustomerId);
            return View(serviceReceived);
        }

        // GET: ServiceReceiveds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceReceived = await _context.ServiceReceived.FindAsync(id);
            if (serviceReceived == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", serviceReceived.CustomerId);
            return View(serviceReceived);
        }

        // POST: ServiceReceiveds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,CarModel,LicensePlate,VIN,StateBeforeRepair,CustomerComplaint,InitialDiagnosis,EstimatedCost,ReceivedDate,Notes,TechnicianName")] ServiceReceived serviceReceived)
        {
            if (id != serviceReceived.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceReceived);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceReceivedExists(serviceReceived.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", serviceReceived.CustomerId);
            return View(serviceReceived);
        }

        // GET: ServiceReceiveds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceReceived = await _context.ServiceReceived
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceReceived == null)
            {
                return NotFound();
            }

            return View(serviceReceived);
        }

        // POST: ServiceReceiveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceReceived = await _context.ServiceReceived.FindAsync(id);
            if (serviceReceived != null)
            {
                _context.ServiceReceived.Remove(serviceReceived);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceReceivedExists(int id)
        {
            return _context.ServiceReceived.Any(e => e.Id == id);
        }
    }
}
