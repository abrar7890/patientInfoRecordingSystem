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
    public class ABPatientTreatmentController : Controller
    {
        private readonly ABPatientsContext _context;

        public ABPatientTreatmentController(ABPatientsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Displays an index page with list of patient treatments on file
        /// </summary>
        /// <param name="patientDiagnosisId"></param>
        /// <param name="patientId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="diagnosisName"></param>
        /// <returns></returns>
        // GET: ABPatientTreatment
        public async Task<IActionResult> Index(string patientDiagnosisId,string patientId,string firstName,string lastName,string diagnosisName)
        {
            if(patientDiagnosisId != null)
            {
                //store values as cookie variables passed as parameters to this action 
                Response.Cookies.Append("patientDiagnosisId", patientDiagnosisId);
                Response.Cookies.Append("patientId", patientId);
                Response.Cookies.Append("firstName", firstName);
                Response.Cookies.Append("lastName", lastName);
                Response.Cookies.Append("diagnosisName", diagnosisName);

                //store values as session variables passed as parameters to this action 
                HttpContext.Session.SetString("patientDiagnosisId",patientDiagnosisId);
                HttpContext.Session.SetString("patientId",patientId);
                HttpContext.Session.SetString("firstName",firstName);
                HttpContext.Session.SetString("lastName",lastName);
                HttpContext.Session.SetString("diagnosisName",diagnosisName);
            }
            //checks if id is passed in querystring
            else if(Request.Query["patientDiagnosisId"].Any())
            {
                //save the id passed in querystring to cookies
                Response.Cookies.Append("patientDiagnosisId", Request.Query["patientDiagnosisId"]);
                patientDiagnosisId = Request.Query["patientDiagnosisId"].Any().ToString();

                //store information passed for this record to cookies
                Response.Cookies.Append("patientId", patientId);
                Response.Cookies.Append("firstName", firstName);
                Response.Cookies.Append("lastName", lastName);
                Response.Cookies.Append("diagnosisName", diagnosisName);

                //store information passed for this record to session variables
                HttpContext.Session.SetString("patientDiagnosisId", Request.Query["patientDiagnosisId"]);
                HttpContext.Session.SetString("patientId", patientId);
                HttpContext.Session.SetString("firstName", firstName);
                HttpContext.Session.SetString("lastName", lastName);
                HttpContext.Session.SetString("diagnosisName", diagnosisName);
            }
            //check if id is already stored in cookies
            else if(Request.Cookies["patientDiagnosisId"] != null)
            {
                patientDiagnosisId = Request.Cookies["patientDiagnosisId"];
                patientId = Request.Cookies["patientId"];
                firstName = Request.Cookies["firstName"];
                lastName = Request.Cookies["lastName"];
                diagnosisName = Request.Cookies["diagnosisName"];
            }
            //check if id is already stored in session variables
            else if(HttpContext.Session.GetString("patientDiagnosisId") != null)
            {
                patientDiagnosisId = HttpContext.Session.GetString("patientDiagnosisId");
                patientId = HttpContext.Session.GetString("patientId");
                firstName = HttpContext.Session.GetString("firstName");
                lastName = HttpContext.Session.GetString("lastName");
                diagnosisName = HttpContext.Session.GetString("diagnosisName");
            }
            else
            {
                //if id is not found in above cases, then return message to select a record
                TempData["message"] = "Please select a patient diagnosis";
                //return to index action of the controller from where id is passed
                return RedirectToAction("Index", "ABPatientDiagnosis");
            }

            //store string variables in tempdata
            TempData["firstName"] = firstName;
            TempData["lastName"] = lastName;
            TempData["diagnosisName"] = diagnosisName;

            var aBPatientsContext = _context.PatientTreatment.Include(p => p.PatientDiagnosis).Include(p => p.Treatment).Where(a=>a.PatientDiagnosisId.ToString() == patientDiagnosisId).Where(a => a.PatientDiagnosisId.ToString() == patientDiagnosisId).Where(a => a.PatientDiagnosis.PatientId.ToString() == patientId).OrderByDescending(a=>a.DatePrescribed);
            return View(await aBPatientsContext.ToListAsync());
        }

        
        //create a new patientTreatment record
        // GET: ABPatientTreatment/Create
        public IActionResult Create()
        {
            //declare and initialize string variables
            string patientDiagnosisId = string.Empty;
            string patientId = string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;
            string diagnosisName = string.Empty;

            //checks if patientDiagnosisId is stored in cookies 
            if (Request.Cookies["patientDiagnosisId"] != null)
            {
                //if not null,get all the information like patientDiagnosisId,patientId,firstName,etc from cookies and store value in string variables
                patientDiagnosisId = Request.Cookies["patientDiagnosisId"];
                patientId = Request.Cookies["patientId"];
                firstName = Request.Cookies["firstName"];
                lastName = Request.Cookies["lastName"];
                diagnosisName = Request.Cookies["diagnosisName"];
            }
            else if (HttpContext.Session.GetString("patientDiagnosisId") != null)
            {
                //if not null,get all the information like patientDiagnosisId,patientId,firstName,etc from session variables and store value in string variables
                patientDiagnosisId = HttpContext.Session.GetString("patientDiagnosisId");
                patientId = HttpContext.Session.GetString("patientId");
                firstName = HttpContext.Session.GetString("firstName");
                lastName = HttpContext.Session.GetString("lastName");
                diagnosisName = HttpContext.Session.GetString("diagnosisName");
            }

            TempData["firstName"] = firstName;
            TempData["lastName"] = lastName;

            TempData["diagnosisName"] = diagnosisName;

            var patientDiagnosis = _context.PatientDiagnosis.Where(a => a.PatientDiagnosisId.ToString() == patientId).FirstOrDefault();

            //select list of patient diagnosis stored in Viewdata 
            ViewData["PatientDiagnosisId"] = new SelectList(_context.PatientDiagnosis, "PatientDiagnosisId", "PatientDiagnosisId");

            //select list of treatment on file for selected diagnosis  ordered by name
            ViewData["TreatmentId"] = new SelectList(_context.Treatment.Where(a => a.DiagnosisId == patientDiagnosis.DiagnosisId).OrderBy(a => a.Name), "TreatmentId", "Name");
            return View();
        }


        // post-back Create action
        // create new patient treatment record and save new record to the database, if it passes the edits.
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientTreatmentId,TreatmentId,DatePrescribed,Comments,PatientDiagnosisId")] PatientTreatment patientTreatment)
        {
            //declare and initialize string variables
            string patientDiagnosisId = string.Empty;
            string patientId = string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;
            string diagnosisName = string.Empty;

            //checks if patientDiagnosisId is stored in cookies 
            if (Request.Cookies["patientDiagnosisId"] != null)
            {
                //if not null,get all the information like patientDiagnosisId,patientId,firstName,etc from cookies and store value in string variables
                patientDiagnosisId = Request.Cookies["patientDiagnosisId"];
                patientId = Request.Cookies["patientId"];
                firstName = Request.Cookies["firstName"];
                lastName = Request.Cookies["lastName"];
                diagnosisName = Request.Cookies["diagnosisName"];
            }
            //checks if patientDiagnosisId is stored in session
            else if (HttpContext.Session.GetString("patientDiagnosisId") != null)
            {
                //if not null,get all the information like patientDiagnosisId,patientId,firstName,etc from session variables and store value in string variables
                patientDiagnosisId = HttpContext.Session.GetString("patientDiagnosisId");
                patientId = HttpContext.Session.GetString("patientId");
                firstName = HttpContext.Session.GetString("firstName");
                lastName = HttpContext.Session.GetString("lastName");
                diagnosisName = HttpContext.Session.GetString("diagnosisName");
            }

            TempData["firstName"] = firstName;
            TempData["lastName"] = lastName;

            TempData["diagnosisName"] = diagnosisName;

            var patientDiagnosis = _context.PatientDiagnosis.Where(a => a.PatientDiagnosisId.ToString() == patientId).FirstOrDefault();
            
            if (ModelState.IsValid)
            {
                //if data entered is valid, add it to context class
                _context.Add(patientTreatment);
                //save changes in database
                await _context.SaveChangesAsync();
                //redirect to list of all records with new added record, i.e. index action of this controller
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientDiagnosisId"] = new SelectList(_context.PatientDiagnosis, "PatientDiagnosisId", "PatientDiagnosisId", patientTreatment.PatientDiagnosisId);
            ViewData["TreatmentId"] = new SelectList(_context.Treatment.Where(a => a.DiagnosisId == patientDiagnosis.DiagnosisId).OrderBy(a => a.Name), "TreatmentId", "Name", patientTreatment.TreatmentId);
            return View(patientTreatment);
        }

        //display details of the selected record
        // GET: ABPatientTreatment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            string patientDiagnosisId = string.Empty;
            string patientId = string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;
            string diagnosisName = string.Empty;

            if (Request.Cookies["patientDiagnosisId"] != null)
            {
                patientDiagnosisId = Request.Cookies["patientDiagnosisId"];
                patientId = Request.Cookies["patientId"];
                firstName = Request.Cookies["firstName"];
                lastName = Request.Cookies["lastName"];
                diagnosisName = Request.Cookies["diagnosisName"];
            }
            else if (HttpContext.Session.GetString("patientDiagnosisId") != null)
            {
                patientDiagnosisId = HttpContext.Session.GetString("patientDiagnosisId");
                patientId = HttpContext.Session.GetString("patientId");
                firstName = HttpContext.Session.GetString("firstName");
                lastName = HttpContext.Session.GetString("lastName");
                diagnosisName = HttpContext.Session.GetString("diagnosisName");
            }

            TempData["firstName"] = firstName;
            TempData["lastName"] = lastName;

            TempData["diagnosisName"] = diagnosisName;
            if (id == null)
            {
                return NotFound();
            }

            var patientTreatment = await _context.PatientTreatment
                .Include(p => p.PatientDiagnosis)
                .Include(p => p.Treatment)
                .FirstOrDefaultAsync(m => m.PatientTreatmentId == id);
            if (patientTreatment == null)
            {
                return NotFound();
            }

            return View(patientTreatment);
        }

        //edit/update selected record 
        // GET: ABPatientTreatment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            string patientDiagnosisId = string.Empty;
            string patientId = string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;
            string diagnosisName = string.Empty;

            if (Request.Cookies["patientDiagnosisId"] != null)
            {
                patientDiagnosisId = Request.Cookies["patientDiagnosisId"];
                patientId = Request.Cookies["patientId"];
                firstName = Request.Cookies["firstName"];
                lastName = Request.Cookies["lastName"];
                diagnosisName = Request.Cookies["diagnosisName"];
            }
            else if (HttpContext.Session.GetString("patientDiagnosisId") != null)
            {
                patientDiagnosisId = HttpContext.Session.GetString("patientDiagnosisId");
                patientId = HttpContext.Session.GetString("patientId");
                firstName = HttpContext.Session.GetString("firstName");
                lastName = HttpContext.Session.GetString("lastName");
                diagnosisName = HttpContext.Session.GetString("diagnosisName");
            }

            TempData["firstName"] = firstName;
            TempData["lastName"] = lastName;

            TempData["diagnosisName"] = diagnosisName;
            if (id == null)
            {
                return NotFound();
            }

            var patientTreatment = await _context.PatientTreatment.FindAsync(id);
            if (patientTreatment == null)
            {
                return NotFound();
            }
            ViewData["PatientDiagnosisId"] = new SelectList(_context.PatientDiagnosis, "PatientDiagnosisId", "PatientDiagnosisId", patientTreatment.PatientDiagnosisId);

            //select list for treatments that displays treatment name on the view but stores treatment id for the record
            ViewData["TreatmentId"] = new SelectList(_context.Treatment, "TreatmentId", "Name", patientTreatment.TreatmentId);
            return View(patientTreatment);
        }

        //post back action to edit/update an existing record and save to database
        // POST: ABPatientTreatment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientTreatmentId,TreatmentId,DatePrescribed,Comments,PatientDiagnosisId")] PatientTreatment patientTreatment)
        {
            string patientDiagnosisId = string.Empty;
            string patientId = string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;
            string diagnosisName = string.Empty;

            if (Request.Cookies["patientDiagnosisId"] != null)
            {
                patientDiagnosisId = Request.Cookies["patientDiagnosisId"];
                patientId = Request.Cookies["patientId"];
                firstName = Request.Cookies["firstName"];
                lastName = Request.Cookies["lastName"];
                diagnosisName = Request.Cookies["diagnosisName"];
            }
            else if (HttpContext.Session.GetString("patientDiagnosisId") != null)
            {
                patientDiagnosisId = HttpContext.Session.GetString("patientDiagnosisId");
                patientId = HttpContext.Session.GetString("patientId");
                firstName = HttpContext.Session.GetString("firstName");
                lastName = HttpContext.Session.GetString("lastName");
                diagnosisName = HttpContext.Session.GetString("diagnosisName");
            }

            TempData["firstName"] = firstName;
            TempData["lastName"] = lastName;

            TempData["diagnosisName"] = diagnosisName;
            if (id != patientTreatment.PatientTreatmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //if modelstate is valid then update the record 
                    _context.Update(patientTreatment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientTreatmentExists(patientTreatment.PatientTreatmentId))
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
           
            ViewData["PatientDiagnosisId"] = new SelectList(_context.PatientDiagnosis, "PatientDiagnosisId", "PatientDiagnosisId", patientTreatment.PatientDiagnosisId);
            ViewData["TreatmentId"] = new SelectList(_context.Treatment, "TreatmentId", "Name", patientTreatment.TreatmentId);
            return View(patientTreatment);
        }

        // GET: ABPatientTreatment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            string patientDiagnosisId = string.Empty;
            string patientId = string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;
            string diagnosisName = string.Empty;

            if (Request.Cookies["patientDiagnosisId"] != null)
            {
                patientDiagnosisId = Request.Cookies["patientDiagnosisId"];
                patientId = Request.Cookies["patientId"];
                firstName = Request.Cookies["firstName"];
                lastName = Request.Cookies["lastName"];
                diagnosisName = Request.Cookies["diagnosisName"];
            }
            else if (HttpContext.Session.GetString("patientDiagnosisId") != null)
            {
                patientDiagnosisId = HttpContext.Session.GetString("patientDiagnosisId");
                patientId = HttpContext.Session.GetString("patientId");
                firstName = HttpContext.Session.GetString("firstName");
                lastName = HttpContext.Session.GetString("lastName");
                diagnosisName = HttpContext.Session.GetString("diagnosisName");
            }

            TempData["firstName"] = firstName;
            TempData["lastName"] = lastName;

            TempData["diagnosisName"] = diagnosisName;
            if (id == null)
            {
                return NotFound();
            }

            var patientTreatment = await _context.PatientTreatment
                .Include(p => p.PatientDiagnosis)
                .Include(p => p.Treatment)
                .FirstOrDefaultAsync(m => m.PatientTreatmentId == id);
            if (patientTreatment == null)
            {
                return NotFound();
            }

            return View(patientTreatment);
        }

        // POST: ABPatientTreatment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientTreatment = await _context.PatientTreatment.FindAsync(id);
            _context.PatientTreatment.Remove(patientTreatment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //returns a boolean value that checks patient treatment exists
        private bool PatientTreatmentExists(int id)
        {
            return _context.PatientTreatment.Any(e => e.PatientTreatmentId == id);
        }
    }
}
