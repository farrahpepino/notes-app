import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './components/header/header.component';
import { NoteComponent } from './components/note/note.component';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  exports:[
    CommonModule,
    HeaderComponent,
    NoteComponent
  ]
})
export class SharedModule { }
