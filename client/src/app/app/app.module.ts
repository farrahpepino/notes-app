import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from '../app.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [AppComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
  ],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
