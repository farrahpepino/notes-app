import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Note{
  id: number;
  title: string;
  content: string;
  createdAt: string;
  updatedAt: string;
}

@Injectable({
  providedIn: 'root'
})
export class NoteService {
  private apiUrl = 'http://localhost:5287/api/notes';

  constructor(private http: HttpClient) {}
 
  createNote(note: Partial<Note>): Observable<string> {
    return this.http.post(this.apiUrl, note, { responseType: 'text' });
  }

  deleteNote(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  
  }
  
  getAllNotes() {
    return this.http.get<Note[]>(this.apiUrl);
  }

  getNote(id: number): Observable<Note> {
    return this.http.get<Note>(`${this.apiUrl}/${id}`);
  }

  updateNote(id: number, note: Partial<Note>): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, note);
  }
  
}
