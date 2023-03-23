using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contacts.Application.Interfaces;
using Core.Contacts.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWebApp.Models;

namespace WebApplication1.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService _service)
        {
            this._candidateService = _service;
        }

        // GET: Candidates
        public async Task<IActionResult> Index(string firstName, string lastName, string email, string phone, string zipcode)
        {
            if (firstName==null && lastName==null && email==null && phone==null && zipcode==null)
                return View(new List<MCandidate>());
            var result = await _candidateService.FindCandidate(firstName, lastName, email, phone, zipcode);
                          
            return View(result);
        }
        
        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {


            var candidate = await _candidateService.GetById(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,Zipcode")] DCandidate candidate)
        {
            if (ModelState.IsValid)
            {
                int id= await _candidateService.CreateCandidate(candidate.FirstName,candidate.LastName,candidate.Email, candidate.PhoneNumber, candidate.Zipcode);                
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            MCandidate candidate = await _candidateService.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Zipcode")] MCandidate candidate)
        {
            if (id != candidate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int updateCount = await _candidateService.Update(candidate);

                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var candidate = await _candidateService.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _candidateService.FindAsync(id);
            if (candidate != null)
            {
                try
                {
                    int deleteCount = await _candidateService.Remove(id);
                }
                catch (Exception)
                {

                    return NotFound();
                }
                
            }
            
            return RedirectToAction(nameof(Index));
        }

       

    }
}
