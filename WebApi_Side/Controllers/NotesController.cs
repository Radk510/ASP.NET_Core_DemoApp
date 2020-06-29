using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Side.Models;
using WebApi_Side.Data;

namespace WebApi_Side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _service;

        public NotesController(INoteService service)
        {
            _service = service;
        }

        // GET api/notes
        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetNotes()
        {
            var notes = await _service.GetNotesAsync();

            return Ok(notes);
        }

        // Get api/notes/65
        [HttpGet("{id}")]
        public ActionResult<Note> GetNote(int id)
        {
            var note = _service.GetNote(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        // Post api/notes
        [HttpPost]
        public ActionResult PostNote(Note note)
        {
            if (note == null)
            {
                return BadRequest();
            }

            _service.CreateNotes(note);

            return Ok(note);
        }

        // Put api/notes/43
        [HttpPut("{id}")]
        public ActionResult PutNote(int id, Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            _service.UpdateNotes(note);

            return NoContent();
        }

        // Delete api/notes/423
        [HttpDelete]
        public ActionResult<Note> DeleteNote(int id)
        {
            var noteToDelete = _service.GetNote(id);

            if (noteToDelete == null)
            {
                return NotFound();
            }

            _service.DeleteNotes(noteToDelete);

            return noteToDelete;
        }
    }
}
