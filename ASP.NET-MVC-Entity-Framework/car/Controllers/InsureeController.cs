using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using car.Models;

namespace car.Controllers
{
    public class InsureeController : Controller
    {
        private readonly InsuranceContext _context;

        public InsureeController(InsuranceContext context)
        {
            _context = context;
        }

        // GET: Insuree
        public async Task<IActionResult> Index()
        {
            return View(await _context.Insurees.ToListAsync());
        }

        // GET: Insuree/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // GET: Insuree/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,SpeedingTickets,DUI,FullCoverage")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // Calculate quote
                CalculateQuote(insuree);

                _context.Add(insuree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees.FindAsync(id);
            if (insuree == null)
            {
                return NotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,SpeedingTickets,DUI,FullCoverage,Quote")] Insuree insuree)
        {
            if (id != insuree.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Calculate quote
                    CalculateQuote(insuree);

                    _context.Update(insuree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsureeExists(insuree.Id))
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
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuree = await _context.Insurees.FindAsync(id);
            if (insuree != null)
            {
                _context.Insurees.Remove(insuree);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool InsureeExists(int id)
        {
            return _context.Insurees.Any(e => e.Id == id);
        }

        // GET: Insuree/Admin
        public async Task<IActionResult> Admin()
        {
            return View(await _context.Insurees.ToListAsync());
        }

        private void CalculateQuote(Insuree insuree)
        {
            // Start with base rate of $50 per month
            decimal monthlyTotal = 50;

            // Calculate age
            int age = DateTime.Today.Year - insuree.DateOfBirth.Year;
            // Adjust age if birthday hasn't occurred yet this year
            if (insuree.DateOfBirth.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            // Age-based charges
            if (age <= 18)
            {
                monthlyTotal += 100;
            }
            else if (age >= 19 && age <= 25)
            {
                monthlyTotal += 50;
            }
            else // age >= 26
            {
                monthlyTotal += 25;
            }

            // Car year-based charges
            if (insuree.CarYear < 2000)
            {
                monthlyTotal += 25;
            }
            else if (insuree.CarYear > 2015)
            {
                monthlyTotal += 25;
            }

            // Car make and model-based charges
            if (insuree.CarMake.ToLower() == "porsche")
            {
                monthlyTotal += 25;

                if (insuree.CarModel.ToLower() == "911 carrera")
                {
                    monthlyTotal += 25;
                }
            }

            // Speeding ticket charges
            monthlyTotal += (decimal)(insuree.SpeedingTickets * 10);

            // Apply DUI surcharge (25%)
            if (insuree.DUI)
            {
                monthlyTotal *= 1.25m;
            }

            // Apply full coverage surcharge (50%)
            if (insuree.FullCoverage)
            {
                monthlyTotal *= 1.50m;
            }

            // Set the calculated quote
            insuree.Quote = monthlyTotal;
        }
    }
} 