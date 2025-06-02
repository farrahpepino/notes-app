import { Component } from '@angular/core';
import { ReactiveFormsModule, FormControl, FormGroup } from '@angular/forms';
import { NoteService, Note } from '../../services/note.service';
import { Validators } from '@angular/forms';
@Component({
  selector: 'app-header',
  imports: [ReactiveFormsModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  notes: Note[] = [];  

  constructor(private noteService: NoteService){}
  isClicked = false;
  addNote(){
    this.isClicked = true;
  }
  
  cancelNote(){
    this.noteForm.reset();
    this.isClicked = false;
  }
 
  

  

  noteForm = new FormGroup({
    title: new FormControl('', Validators.required),
    content: new FormControl('', Validators.required),
  });

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
  
  handleSubmit() {
    if (!this.noteForm.valid) return;
    const newNote: Partial<Note> = {
      title: this.noteForm.value.title || 'Untitled',
      content: this.noteForm.value.content || ''
    };
    this.noteService.createNote(newNote).subscribe(() => {
      this.isClicked = false;     
      this.noteForm.reset(); 
      window.location.reload();
 
      }   );
    
  }
  

}
