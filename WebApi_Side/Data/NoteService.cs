using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Side.Context;
using WebApi_Side.Models;

namespace WebApi_Side.Data
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext _context;

        public NoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET ALL NOTES
        /// </summary>
        /// <returns>All notes from Db</returns>
        public async Task<List<Note>> GetNotesAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        /// <summary>
        /// GET ONE NOTE BY ID
        /// </summary>
        /// <param name="id">Id of searching note</param>
        /// <returns>One note by id</returns>
        public Note GetNote(int id)
        {
            return _context.Notes.FirstOrDefault(n => n.Id == id);
        }

        /// <summary>
        /// CREATE NOTE
        /// </summary>
        /// <param name="note">Note to create</param>
        public void CreateNotes(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            _context.Add(note);
            SaveChanges();
        }

        /// <summary>
        /// UPDATE NOTES
        /// </summary>
        /// <param name="note">Note to update</param>
        public void UpdateNotes(Note note)
        {
            _context.Entry(note).State = EntityState.Modified;

            SaveChanges();

        }

        /// <summary>
        /// DELETE NOTES
        /// </summary>
        /// <param name="id"></param>
        /// <param name="note"></param>
        public void DeleteNotes(Note note)
        {
            _context.Notes.Remove(note);

            SaveChanges();
        }

        /// <summary>
        /// SAVE CHANGES METHOD
        /// </summary>
        /// <returns>Save changes to Context (to Db)</returns>
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
