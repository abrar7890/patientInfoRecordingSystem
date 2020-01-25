using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABPatients.Models;
using Microsoft.AspNetCore.Authorization;

namespace ABPatients.Controllers
{
    [Authorize(Roles = "members")]
    public class ABCountryController : Controller
    {
        private readonly ABPatientsContext _context;

        public ABCountryController(ABPatientsContext context)
        {
            _context = context;
        }

        //display list of countries
        //Arshdeep Brar September 2019

        /// <summary>
        /// Index is default action for this controller
        /// this will display list of countries
        /// </summary>
        /// <returns>An index page</returns>
        // GET: ABCountry
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Country.ToListAsync());
        }

        /// <summary>
        /// action to display the details of selected country
        /// </summary>
        /// <param name="id">country code</param>
        // GET: ABCountry/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country
                .FirstOrDefaultAsync(m => m.CountryCode == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country); //render ~/Views/ABCountry/Details.cshtml
        }

        /// <summary>
        /// action to create new country 
        /// </summary>
        /// <returns>default to a view named same as action i.e.create </returns>
        // GET: ABCountry/Create
        public IActionResult Create()
        {
            return View();
        }

        // postback action to create new country
        //(only invoked for POST requests)
        // POST: ABCountry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryCode,Name,PostalPattern,PhonePattern,FederalSalesTax")] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        //action to edit selected country 
        // GET: ABCountry/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country); //render ~/Views/ABCountry/Edit.cshtml
        }

        // postback action to edit selected country
        // POST: ABCountry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CountryCode,Name,PostalPattern,PhonePattern,FederalSalesTax")] Country country)
        {
            if (id != country.CountryCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.CountryCode))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // redirects you to ~/Views/ABCountry/Index.cshtml page
            }
            return View(country); 
        }

        //action to delete the selected country
        // GET: ABCountry/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country
                .FirstOrDefaultAsync(m => m.CountryCode == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country); //render ~/Views/ABCountry/Details.cshtml
        }

        //postback action to delete selected country
        // POST: ABCountry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var country = await _context.Country.FindAsync(id);
            _context.Country.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //checks if country exists
        private bool CountryExists(string id)
        {
            return _context.Country.Any(e => e.CountryCode == id);
        }
    }
}
