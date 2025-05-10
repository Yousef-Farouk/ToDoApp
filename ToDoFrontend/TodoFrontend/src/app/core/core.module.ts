import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { TodoService } from './services/todo.service';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers:[TodoService],
  exports:[
    HttpClientModule
  ]
})
export class CoreModule { }
