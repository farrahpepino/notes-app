using Dapper;
using Microsoft.AspNetCore.Mvc;
using NotesAppAPI.Models;
using NotesAppAPI.Data;

namespace NotesAppAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController: ControllerBase{
        private readonly DapperContext _context;
        public NotesController (DapperContext context){
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] Note note) {
           
            var query = "INSERT INTO notes (title, content) VALUES (@Title, @Content)";
            using var connection = _context.CreateConnection();
            try{
            var result = await connection.ExecuteAsync(query, note);
            if (result > 0) {
                return StatusCode(201, note); 
                }
            return StatusCode(500, "Failed to create note.");
            }
            catch(Exception ex){
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }   


        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id){
        
            var query = "DELETE FROM notes WHERE id = @Id";
            using var connection = _context.CreateConnection();
            try{
            var result = await connection.ExecuteAsync(query, new {Id = id});
            return (result > 0) ? StatusCode(200) : NotFound();
            }
            catch(Exception ex){
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, [FromBody]Note note){
            var query = "UPDATE notes SET title = @Title, content = @Content WHERE id = @Id";
            using var connection = _context.CreateConnection();
            try{
            var result = await connection.ExecuteAsync(query, new {note.Title, note.Content, Id = id});
            if (result>0){
                return StatusCode(200);
            }
            else{ 
                return NotFound();}
            }
            catch(Exception ex){
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id){
          
            var query = "SELECT * FROM notes WHERE id = @Id";
           
            using var connection = _context.CreateConnection();
            try{
            var note = await connection.QuerySingleOrDefaultAsync<Note>(query, new { Id = id });

            if (note == null) return NotFound();

            return Ok(note);}
             catch(Exception ex){
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

       [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {

            try
            {
                var query = "SELECT * FROM notes ORDER BY updated_at DESC";
                using var connection = _context.CreateConnection();
                var notes = await connection.QueryAsync<Note>(query);
                return StatusCode(200, notes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching notes.");
            }
        }

    }
}
