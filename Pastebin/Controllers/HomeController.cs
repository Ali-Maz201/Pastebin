using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pastebin.Data;
using Pastebin.Models;
using Pastebin.Models.ViewModels;

namespace Pastebin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPasteRepo repository;

        public HomeController(IMapper mapper, IPasteRepo repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var getPastes = await repository.GetAllPublicPastes();

            var pasteViewModel = mapper.Map<IEnumerable<PasteReadViewModel>>(getPastes);

            return View(pasteViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? pasteCode, string? password)
        {
            if(pasteCode != null)
            {
                var pasteFound = await repository.GetPasteByCodeAsync(pasteCode);
                if (pasteFound.Exists == "true")
                {
                    if (password == pasteFound.PasswordPaste)
                    {
                        if (DateTime.Now.CompareTo(pasteFound.ExpirationTime) < 0 || pasteFound.OptionExpirationPaste == "Never")
                        {
                            return RedirectToAction("Details", "Home", new { pasteCode = pasteFound.PasteCode});
                        }
                    }
                } 
                ViewBag.message = "Paste is unavailable.";
            }
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Details(string? pasteCode)
        {
             if(pasteCode != null)
            {
                var currentPaste = await repository.GetPasteByCodeAsync(pasteCode);
                if (currentPaste == null)
                {
                    return NotFound();
                }
                var readViewModel = mapper.Map<PasteReadViewModel>(currentPaste);
                return View(readViewModel);
            }
            return View();
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PasteCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentPaste = mapper.Map<PasteCreateViewModel, Paste>(model);
                await repository.CreatePaste(currentPaste);
                ViewBag.message = "The paste with the code " + currentPaste.PasteCode + " has been created ";
            }
            return View();
        }
        

        [HttpGet]
        public async Task<IActionResult> Delete(string? pasteCode)
        {
            if (pasteCode == null)
            {
                return NotFound();
            }

            var currentPaste = await repository.GetPasteByCodeAsync(pasteCode);
            if (currentPaste == null)
            {
                return NotFound();
            }
            var viewModel = mapper.Map<Paste, PasteReadViewModel>(currentPaste);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string pasteCode)
        {
            var currentPaste = await repository.GetPasteByCodeAsync(pasteCode);
            repository.DeleteConfirmed(currentPaste);
            return RedirectToAction(nameof(Index));
        }
    }
}
