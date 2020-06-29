
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Side.Models;

namespace WebApi_Side.Data
{
    public interface INoteService
    {
        bool SaveChanges();

        Task<List<Note>> GetNotesAsync();

        Note GetNote(int id);

        void CreateNotes(Note note);

        void UpdateNotes(Note note);

        void DeleteNotes(Note note);
    }
}
