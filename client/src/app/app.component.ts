import { Component } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'; 
import { HeaderComponent } from './shared/components/header/header.component';
import { NoteComponent } from './shared/components/note/note.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
     HeaderComponent, NoteComponent, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'client';
}
