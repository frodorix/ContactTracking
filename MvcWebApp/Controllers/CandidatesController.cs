using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contacts.Application.Interfaces;
using Core.Contacts.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
      
    }
}
