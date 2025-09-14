using server.Models;
using server.Repositories;


namespace server.Services{
    public class NoteService{
        private readonly NoteRepository _noteRepository;


        public NoteService (NoteRepository noteRepository){
            _noteRepository = noteRepository;
        }

        public async Task<Note?> CreateNote(Note note) {
            var result = await _noteRepository.CreateNote(note);
            if (result<=0) {
                return null;
            }
            return note;
        }   

        public async Task<int> DeleteNote(int id){
            return await _noteRepository.DeleteNote(id);
        }

        public async Task<int> UpdateNote(int id, Note note){
            return await _noteRepository.UpdateNote(id, note);     
        }

        public async Task<Note?> GetNoteById(int id){
            return await _noteRepository.GetNoteById(id);
        }

        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            return await _noteRepository.GetAllNotes();
        }

    }
}