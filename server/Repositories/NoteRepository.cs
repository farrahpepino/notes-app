using server.Models;
using server.Data;
using Dapper;

namespace server.Repositories{
    public class NoteRepository {
        private readonly DapperContext _context;

        public NoteRepository (DapperContext context){
            _context = context;
        }

        private const string InsertNoteQuery =  "INSERT INTO notes (title, content) VALUES (@Title, @Content)";
        private const string DeleteNoteQuery = "DELETE FROM notes WHERE id = @Id";
        private const string UpdateNoteQuery = "UPDATE notes SET title = @Title, content = @Content WHERE id = @Id";
        private const string GetNoteByIdQuery = "SELECT * FROM notes WHERE id = @Id";
        private const string GetAllNotesQuery = "SELECT * FROM notes ORDER BY updated_at DESC";


        public async Task<int> CreateNote( Note note) {
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(InsertNoteQuery, note);
        }   

        public async Task<int> DeleteNote(int id){
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(DeleteNoteQuery, new {Id = id});
        }

        public async Task<int> UpdateNote(int id, Note note){
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(UpdateNoteQuery, new {note.Title, note.Content, Id = id});
       }

        public async Task<Note?> GetNoteById(int id){
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Note>(GetNoteByIdQuery, new { Id = id });
        }

        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Note>(GetAllNotesQuery);  
        }

    }
}