using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAppAPI.Models;
using NotesAppAPI.Data;

namespace NotesAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase{
        private readonly ApiContext _context;

        public NotesController(ApiContex context){
            _context = context
        }

        //create/edit

        //delete
    }
}