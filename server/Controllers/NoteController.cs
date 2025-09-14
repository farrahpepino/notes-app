using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;


namespace server.Controllers{
    [Route("api/[controller]")]
    [ApiController]

    public class NoteController: ControllerBase{
        private readonly NoteService _noteService;

        public NoteController (NoteService noteService){
            _noteService =  noteService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] Note note) {
            var response = await _noteService.CreateNote(note);  
            if (response==null) {
                return BadRequest();
            }
            return Ok(response);
        }   

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id){
           var result = await _noteService.DeleteNote(id);
            return (result > 0) ? StatusCode(200) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, [FromBody]Note note){

            var result = await _noteService.UpdateNote(id, note);
            if (result>0){
                return Ok();
            }

            return BadRequest();    
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id){
           
            var response = await _noteService.GetNoteById(id);
            if (response == null) return NotFound();
            return Ok(response);
           
        }

       [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
           
            var notes = await _noteService.GetAllNotes();
            return Ok(notes);
          
        }

    }
}
