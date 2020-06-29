using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Client_Side.Services;

namespace Client_Side.Controllers
{
    public class NotesController : Controller
    {
        private readonly INoteService _service;

        public NotesController(INoteService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var notes = await _service.GetNotes();

            return View(notes);
        }

        public async Task<IActionResult> NoteDetails(int id)
        {
            var note = await _service.GetNote(id);

            return View(note);
        }
    }
}
