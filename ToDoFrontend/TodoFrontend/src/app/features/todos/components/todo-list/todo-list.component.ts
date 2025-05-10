import { Component, OnInit } from '@angular/core';
import { TodoService } from '../../../../core/services/todo.service';
import { Todo } from '../../../../core/models/todo.model';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.scss']
})
export class TodoListComponent implements OnInit {
  todos: Todo[] = [];
  
  constructor(private todoService: TodoService) { }

  ngOnInit(): void {
    this.loadTodos();
  }

  private loadTodos(): void {
    this.todoService.getAllTodos().subscribe(todos => {
      this.todos = todos;
    });
  }

  deleteTodo(id: string): void {
    this.todoService.deleteTodo(id).subscribe({
      next: () => this.todos = this.todos.filter(t => t.id !== id),
      error: (err) => console.error('Error deleting todo:', err)
    });
  }
}