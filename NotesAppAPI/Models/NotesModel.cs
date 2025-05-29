namespace NotesAppApi.Models
{
    protected class NotesModel{
        protected int Id {get; set;}
        protected string? Title {get; set;}
        protected string? Content {get; set;}
        protected datetime CreatedAt {get; set;}
        protected datetime UpdatedAt {get; set;}
    }
    
}