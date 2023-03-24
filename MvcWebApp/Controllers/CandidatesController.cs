using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Contacts.Application.Interfaces;
using Core.Contacts.Domain.Models;
using Core.Contacts.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWebApp.Models;

namespace WebApplication1.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidateService _candidateService;
        private MapperConfiguration config;
        
        public CandidatesController(ICandidateService _service)
        {
            this._candidateService = _service;
            config = new MapperConfiguration(cfg => { cfg.CreateMap<MCandidate, DCandidate>(); });
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
        public async Task<IActionResult> Details(int id)
        {


            var candidate = await _candidateService.FindAsync(id);
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
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,Zipcode")] DCandidate candidate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int id = await _candidateService.CreateCandidate(candidate.FirstName, candidate.LastName, candidate.Email, candidate.PhoneNumber, candidate.Zipcode);
                    return RedirectToAction(nameof(Index));
                }
                catch (CandidateException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }   
               
            }
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null )
            {
                return NotFound();
            }

            MCandidate entidad = await _candidateService.FindAsync(id);
           
            if (entidad == null)
            {
                return NotFound();
            }
            var mapper = new Mapper(config);
            var candidate = mapper.Map<MCandidate, DCandidate>(entidad);
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Zipcode")] DCandidate candidate)
        {
            if (id != candidate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int updateCount = await _candidateService.UpdateAsync(candidate.Id,
                                                                     candidate.FirstName,
                                                                     candidate.LastName,
                                                                     candidate.Email,
                                                                     candidate.PhoneNumber,
                                                                     candidate.Zipcode);

                    return RedirectToAction(nameof(Index));
                }
                catch (CandidateException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
        }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int id)
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
            var mapper = new Mapper(config);
            var model = mapper.Map<MCandidate, DCandidate>(candidate);
            return View(model);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
                try
                {
                    int deleteCount = await _candidateService.Remove(id);
                }
                catch (Exception)
                {

                    return NotFound();
                }
                
            
            return RedirectToAction(nameof(Index));
        }

       

    }
}
