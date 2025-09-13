import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl } from '@angular/forms';
@Component({
  selector: 'app-note',
  imports: [ReactiveFormsModule],
  templateUrl: './note.component.html',
  styleUrl: './note.component.css'
})
export class NoteComponent {
  isClicked = false;
  editNote(){
    this.isClicked = true;
  }
  cancelNote(){
    this.noteForm.reset();
    this.isClicked = false;
  }
 
  noteForm = new FormGroup({
    title: new FormControl(''),
    content: new FormControl(''),
  });
  
  handleSubmit() {
    alert(`Title: ${this.noteForm.value.title}\nContent: ${this.noteForm.value.content}`);
    this.isClicked = false;
    this.noteForm.reset();
  }
  
}
