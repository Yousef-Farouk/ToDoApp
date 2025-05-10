import { Component, Input } from '@angular/core';
import { Todo } from '../../../../core/models/todo.model';

@Component({
  selector: 'app-todo-details',
  templateUrl: './todo-details.component.html',
  styleUrl: './todo-details.component.css'
})
export class TodoDetailsComponent {

  @Input() todo?: Todo;
}
