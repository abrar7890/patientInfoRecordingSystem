using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABPatients.Models;
using Microsoft.AspNetCore.Http;

namespace ABPatients.Controllers
{
    public class ABMedicationController : Controller
    {
        private readonly ABPatientsContext _context;

        public ABMedicationController(ABPatientsContext context)
        {
            _context = context;
        }

        //index action that list all the medications
        // GET: ABMedication
        public async Task<IActionResult> Index(string medicationTypeId,string medicationType)
        {
            if(medicationTypeId != null || medicationType != null)
            {
                //store values as cookies
                Response.Cookies.Append("medicationTypeId", medicationTypeId);
                Response.Cookies.Append("medicationType", medicationType);

                //store values as session variables
                HttpContext.Session.SetString("medicationTypeId", medicationTypeId);
                HttpContext.Session.SetString("medicationType", medicationType);
            }
            //checks if value is passed in querystring or not
            else if (Request.Query["medicationTypeId"].Any() || Request.Query["medicationType"].Any())
            {
                Response.Cookies.Append("medicationTypeId", medicationTypeId);
                HttpContext.Session.SetString("medicationTypeId", medicationTypeId);
                medicationTypeId = Request.Query["medicationTypeId"].ToString();

                Response.Cookies.Append("medicationType", medicationType);
                HttpContext.Session.SetString("medicationType", medicationType);
                medicationType = Request.Query["medicationType"];
            }
            else if (Request.Cookies["medicationTypeId"] != null || Request.Cookies["medicationType"] != null)
            {
                medicationTypeId = Request.Query["medicationTypeId"];
                medicationType = Request.Query["medicationType"];
            }
            else if (HttpContext.Session.GetString("medicationTypeId") != null || HttpContext.Session.GetString("medicationType") != null)
            {
                medicationTypeId = HttpContext.Session.GetString("medicationTypeId");
                medicationType = HttpContext.Session.GetString("medicationType");
            }
            else
            {
                //gives an error message
                TempData["message"] = "Please select a medication type";

                //redirects to index action of medicationtype
                return RedirectToAction("Index", "ABMedicationType");
            }
            ViewData["medicationType"] = medicationType;

            var aBPatientsContext = _context.Medication.Include(m => m.ConcentrationCodeNavigation).Include(m => m.DispensingCodeNavigation)
                .Include(m => m.MedicationType).Where(m => m.MedicationTypeId.ToString() == medicationTypeId).OrderBy(m => m.Name).ThenBy(m=>m.Concentration);
            return View(await aBPatientsContext.ToListAsync());
        }

        //details of medication 
        // GET: ABMedication/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medication
                .Include(m => m.ConcentrationCodeNavigation)
                .Include(m => m.DispensingCodeNavigation)
                .Include(m => m.MedicationType)
                .FirstOrDefaultAsync(m => m.Din == id);
            if (medication == null)
            {
                return NotFound();
            }
            string mType = string.Empty;
            if (Request.Cookies["medicationType"] != null)
            {
                mType = Request.Cookies["medicationType"].ToString();
            }
            else if (HttpContext.Session.GetString("medicationType") != null)
            {
                mType = HttpContext.Session.GetString("medicationType");
            }

            ViewData["mdType"] = mType;
            return View(medication);
        }

        //create a new medication
        // GET: ABMedication/Create
        public IActionResult Create()
        {
            string mType = string.Empty;
            if (Request.Cookies["medicationType"] != null)
            {
                mType = Request.Cookies["medicationType"].ToString();
            }
            else if (HttpContext.Session.GetString("medicationType") != null)
            {
                mType = HttpContext.Session.GetString("medicationType");
            }

            ViewData["mdType"] = mType;

            //order list of concentration unit, dispensing code and medication type bby ascending order
            //by default orderby sorts in ascending order
            ViewData["ConcentrationCode"] = new SelectList(_context.ConcentrationUnit.OrderBy(a => a.ConcentrationCode), "ConcentrationCode", "ConcentrationCode");
            ViewData["DispensingCode"] = new SelectList(_context.DispensingUnit.OrderBy(a=>a.DispensingCode), "DispensingCode", "DispensingCode");
            ViewData["MedicationTypeId"] = new SelectList(_context.MedicationType.OrderBy(a => a.MedicationTypeId), "MedicationTypeId", "Name");
            return View();
        }

        //Http post action for creating a medication
        // POST: ABMedication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Din,Name,Image,MedicationTypeId,DispensingCode,Concentration,ConcentrationCode")] Medication medication)
        {
            
            string mType = string.Empty;
            if (Request.Cookies["medicationType"] != null)
            {
                mType = Request.Cookies["medicationType"].ToString();
            }
            else if (HttpContext.Session.GetString("medicationType") != null)
            {
                mType = HttpContext.Session.GetString("medicationType");
            }

            //checks if medication with same name, concemtration and concentration code exists or not
            var isDuplicate = _context.Medication.Where(a => a.Name == mType && a.Concentration == medication.Concentration && a.ConcentrationCode == medication.ConcentrationCode);
            if (isDuplicate.Any())
            {
                ModelState.AddModelError("", "This medication already exists on file");
            }

            if (ModelState.IsValid)
            {
                _context.Add(medication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["mdType"] = mType;
            ViewData["ConcentrationCode"] = new SelectList(_context.ConcentrationUnit.OrderBy(a => a.ConcentrationCode), "ConcentrationCode", "ConcentrationCode", medication.ConcentrationCode);
            ViewData["DispensingCode"] = new SelectList(_context.DispensingUnit.OrderBy(a => a.DispensingCode), "DispensingCode", "DispensingCode", medication.DispensingCode);
            ViewData["MedicationTypeId"] = new SelectList(_context.MedicationType.OrderBy(a => a.MedicationTypeId), "MedicationTypeId", "Name", medication.MedicationTypeId);
            return View(medication);
        }

        //edit medication
        // GET: ABMedication/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            string mType = string.Empty;
            if (Request.Cookies["medicationType"] != null)
            {
                mType = Request.Cookies["medicationType"].ToString();
            }
            else if (HttpContext.Session.GetString("medicationType") != null)
            {
                mType = HttpContext.Session.GetString("medicationType");
            }

            ViewData["mdType"] = mType;
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medication.FindAsync(id);
            if (medication == null)
            {
                return NotFound();
            }
            ViewData["ConcentrationCode"] = new SelectList(_context.ConcentrationUnit.OrderBy(a => a.ConcentrationCode), "ConcentrationCode", "ConcentrationCode", medication.ConcentrationCode);
            ViewData["DispensingCode"] = new SelectList(_context.DispensingUnit.OrderBy(a => a.DispensingCode), "DispensingCode", "DispensingCode", medication.DispensingCode);
            ViewData["MedicationTypeId"] = new SelectList(_context.MedicationType.OrderBy(a => a.MedicationTypeId), "MedicationTypeId", "Name", medication.MedicationTypeId);
            return View(medication);
        }

        //postback action when edit is clicked
        // POST: ABMedication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Din,Name,Image,MedicationTypeId,DispensingCode,Concentration,ConcentrationCode")] Medication medication)
        {
            if (id != medication.Din)
            {
                return NotFound();
            }

            string mType = string.Empty;
            if (Request.Cookies["medicationType"] != null)
            {
                mType = Request.Cookies["medicationType"].ToString();
            }
            else if (HttpContext.Session.GetString("medicationType") != null)
            {
                mType = HttpContext.Session.GetString("medicationType");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationExists(medication.Din))
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
            ViewData["mdType"] = mType;
            ViewData["ConcentrationCode"] = new SelectList(_context.ConcentrationUnit.OrderBy(a => a.ConcentrationCode), "ConcentrationCode", "ConcentrationCode", medication.ConcentrationCode);
            ViewData["DispensingCode"] = new SelectList(_context.DispensingUnit.OrderBy(a => a.DispensingCode), "DispensingCode", "DispensingCode", medication.DispensingCode);
            ViewData["MedicationTypeId"] = new SelectList(_context.MedicationType.OrderBy(a => a.MedicationTypeId), "MedicationTypeId", "Name", medication.MedicationTypeId);
            return View(medication);
        }

        //action for delete medication
        // GET: ABMedication/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medication
                .Include(m => m.ConcentrationCodeNavigation)
                .Include(m => m.DispensingCodeNavigation)
                .Include(m => m.MedicationType)
                .FirstOrDefaultAsync(m => m.Din == id);
            if (medication == null)
            {
                return NotFound();
            }
            string mType = string.Empty;
            if (Request.Cookies["medicationType"] != null)
            {
                mType = Request.Cookies["medicationType"].ToString();
            }
            else if (HttpContext.Session.GetString("medicationType") != null)
            {
                mType = HttpContext.Session.GetString("medicationType");
            }

            ViewData["mdType"] = mType;
            return View(medication);
        }


        //confirms if record is deleted
        // POST: ABMedication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var medication = await _context.Medication.FindAsync(id);
            _context.Medication.Remove(medication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //checks if medication type exists or not
        private bool MedicationExists(string id)
        {
            return _context.Medication.Any(e => e.Din == id);
        }
    }
}
