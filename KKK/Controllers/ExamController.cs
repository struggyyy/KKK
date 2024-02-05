using KKK.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KKK.Controllers
{
    public class ExamController : Controller
    {
        private readonly IDateProvider _dateProvider;
        private readonly NoteService _noteService;

        public ExamController(IDateProvider dateProvider, NoteService noteService)
        {
            _dateProvider = dateProvider;
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var notes = _noteService.GetAll();
            return View(notes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                // Sprawdzanie warunku co do poprawności daty ważności
                if (note.Deadline <= _dateProvider.CurrentDate.AddHours(1))
                {
                    ModelState.AddModelError("Deadline", "Czas ważności musi być o godzinę późniejszy od bieżącego czasu!");
                    return View(note);
                }

                // Obsługa dodawania notatki do serwisu
                _noteService.Add(note);

                // Przekierowanie gdzieś po poprawnym dodaniu notatki.
                return RedirectToAction("Index");
            }

            return View(note);
        }
    }
}