import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { TodosRoutingModule } from './todos-routing.module';
// Material Modules
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';




// Components
import { TodoListComponent } from './components/todo-list/todo-list.component';
import { TodoFormComponent } from './components/todo-form/todo-form.component';
import { TodoDetailsComponent } from './components/todo-details/todo-details.component';
import { TodoListPageComponent } from './pages/todo-list-page/todo-list-page.component';
import { TodoDetailsPageComponent } from './pages/todo-details-page/todo-details-page.component';


@NgModule({
  declarations: [
    TodoListComponent,
    TodoFormComponent,
    TodoDetailsComponent,
    TodoListPageComponent,
    TodoDetailsPageComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    TodosRoutingModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatFormFieldModule, // Add this

  ]
})
export class TodosModule { }
