using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageServiceApp.Models;
using WebApplication5.Data;
using WebApplication5.Helpers;
using Microsoft.Extensions.Hosting;

namespace WebApplication5.Controllers
{
    public class ServiceDetailsController : Controller
    {
        private readonly WebApplication5Context _context;
        private readonly IWebHostEnvironment web;

        public ServiceDetailsController(WebApplication5Context context , IWebHostEnvironment web)
        {
            _context = context;
            this.web = web;
        }

        // GET: ServiceDetails
        public async Task<IActionResult> Index()
        {
            var webApplication5Context = _context.ServiceDetail.Include(s => s.ServiceReceived);
            return View(await webApplication5Context.ToListAsync());
        }

        // GET: ServiceDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceDetail = await _context.ServiceDetail
                .Include(s => s.ServiceReceived)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceDetail == null)
            {
                return NotFound();
            }

            return View(serviceDetail);
        }

        // GET: ServiceDetails/Create
        public IActionResult Create()
        {
            ViewData["ServiceReceivedId"] = new SelectList(_context.ServiceReceived, "Id", "CarModel");
            return View();
        }

        // POST: ServiceDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ServiceDetail serviceDetail)
        {
            if (ModelState.IsValid)
            {
                serviceDetail.PhotoBefore = serviceDetail.PhotoBefore!.ConvertMainImage(web);
                _context.Add(serviceDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceReceivedId"] = new SelectList(_context.ServiceReceived, "Id", "CarModel", serviceDetail.ServiceReceivedId);
            return View(serviceDetail);
        }

        // GET: ServiceDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            var serviceDetail = await _context.ServiceDetail.FindAsync(id);
            if (serviceDetail == null)
            {
                return NotFound();
            }
            ViewData["ServiceReceivedId"] = new SelectList(_context.ServiceReceived, "Id", "CarModel", serviceDetail.ServiceReceivedId);
            return View(serviceDetail);
        }

        // POST: ServiceDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] ServiceDetail serviceDetail)
        {
            if (id != serviceDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
 
                try
                {
                    if (!string.IsNullOrEmpty(serviceDetail.PhotoBefore))
                    {
                        // you could delete the old image
                        serviceDetail.PhotoBefore = serviceDetail.PhotoBefore!.ConvertMainImage(web);
                    }
                    else
                    {
                        var oldImage = await _context.ServiceDetail.AsNoTracking().FirstAsync(a => a.Id == id);
                        serviceDetail.PhotoBefore = oldImage.PhotoBefore;
                    }
                    //serviceDetail.PhotoBefore = serviceDetail.PhotoBefore!.ConvertMainImage(web);
                    _context.Update(serviceDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceDetailExists(serviceDetail.Id))
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
            ViewData["ServiceReceivedId"] = new SelectList(_context.ServiceReceived, "Id", "CarModel", serviceDetail.ServiceReceivedId);
            return View(serviceDetail);
        }

        // GET: ServiceDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceDetail = await _context.ServiceDetail
                .Include(s => s.ServiceReceived)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceDetail == null)
            {
                return NotFound();
            }

            return View(serviceDetail);
        }

        // POST: ServiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceDetail = await _context.ServiceDetail.FindAsync(id);
            if (serviceDetail != null)
            {
                _context.ServiceDetail.Remove(serviceDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceDetailExists(int id)
        {
            return _context.ServiceDetail.Any(e => e.Id == id);
        }
    }
}
