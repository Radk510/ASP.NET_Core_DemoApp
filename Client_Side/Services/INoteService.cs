using Client_Side.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_Side.Services
{
    public interface INoteService
    {
        Task<List<Note>> GetNotes();

        Task<Note> GetNote(int id);

        Task PostNote(Note note);
    }
}
