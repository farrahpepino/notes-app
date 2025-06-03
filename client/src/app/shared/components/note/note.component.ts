import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl } from '@angular/forms';
import { NoteService, Note } from '../../services/note.service';

@Component({
  selector: 'app-note',
  imports: [ReactiveFormsModule],
  templateUrl: './note.component.html',
  styleUrl: './note.component.css'
})
export class NoteComponent implements OnInit{
  constructor(private noteService: NoteService){}

  notes: Note[] = [];  
  noteForm = new FormGroup({
    title: new FormControl(''),
    content: new FormControl(''),
  });
  isClicked = false;
  isExpanded = false;
  selectedNote: Note | null = null;
  selectedNoteId: number | null = null;


  ngOnInit():void {
    this.loadNotes();
  }

  loadNotes(): void {
    this.noteService.getAllNotes().subscribe({
      next: (data) => {
        this.notes = data;
      },
      error: (err) => {
        console.error('Failed to load notes:', err);
      }
    });
  }

  editNote(id: number){
    this.isClicked = true;
    this.getNote(id);
    console.log(id), "from editNote";
  }
  expand(id: number){
    this.isExpanded = true;
    this.getNote(id);
  }
  close(){
    this.isExpanded = false;
  }
  cancel(){
    this.noteForm.reset();
    this.isClicked = false;
    this.isExpanded = false;
  }
 
  getNote(id: number): void {
    this.selectedNote = {
      id: 0, 
      title: '',
      content: '',
      createdAt: '',
      updatedAt: ''
    };  
    this.noteService.getNote(id).subscribe({
      next: (note: Note) => {   
        this.selectedNote = note;
      },
      error: err => console.error('Failed to fetch note', err)
    });
  }

  handleSubmit(): void {
    if (!this.selectedNote) return;
  
    const updatedNote: Partial<Note> = {
      title: this.noteForm.value.title?.trim() || this.selectedNote.title,
      content: this.noteForm.value.content?.trim() || this.selectedNote.content,
    };
  
    this.noteService.updateNote(this.selectedNote.id, updatedNote).subscribe({
      next: () => {
        this.loadNotes();
      },
      error: err => {
        console.error('Error updating note:', err);
      }
    });
  
    this.isClicked = false;
    this.isExpanded = false;
    this.selectedNote = null;
    this.noteForm.reset();
  }
  
  deleteNote(id: number) {
  
    this.noteService.deleteNote(id).subscribe({
      next: () => {
        this.loadNotes(); 
        
      },
      error: (err) => console.error('Delete failed', err)
    });

    this.loadNotes(); 
  }
}
  

