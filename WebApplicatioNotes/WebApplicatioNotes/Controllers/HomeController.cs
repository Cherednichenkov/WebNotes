using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicatioNotes.Models;


namespace WebApplicatioNotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly NotesRepository notesRepository;

        public HomeController(NotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public IActionResult Index()
        {
            var model = notesRepository.GetNotes();
            return View(model);
        }

        public IActionResult NotesEdit(int id)
        {
            Note model = id == default ? new Note() : notesRepository.GetNoteById(id);
            return View(model);
        }

        [HttpPost] 
        public IActionResult NotesEdit(Note model)
        {
            if (ModelState.IsValid)
            {
                notesRepository.SaveNote(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost] 
        public IActionResult NotesDelete(int id)
        {
            notesRepository.DeleteNote(new Note() { Id = id });
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
