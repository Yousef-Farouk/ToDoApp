import { Component, OnInit } from '@angular/core';
import { Todo } from '../../../../core/models/todo.model';
import { ActivatedRoute, Router } from '@angular/router';
import { TodoService } from '../../../../core/services/todo.service';
import { map, of, switchMap } from 'rxjs';

@Component({
  selector: 'app-todo-details-page',
  templateUrl: './todo-details-page.component.html',
  styleUrl: './todo-details-page.component.css'
})
export class TodoDetailsPageComponent {
  
    mode$ = this.route.firstChild?.data.pipe(map(data => data['mode']));
    todo$ = this.route.paramMap.pipe(
    switchMap(params => {
      const id = params.get('id');
      return id ? this.todoService.getTodoById(id) : of(null);
    })
  );

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private todoService: TodoService
  ) {}

  // ngOnInit(): void {
  //   this.mode$ = this.route.firstChild?.data.pipe(map(data => data['mode']));
  //   this.todo$ = this.route.paramMap.pipe(
  //     switchMap(params => {
  //       const id = params.get('id');
  //       return id ? this.todoService.getTodoById(id) : of(null);
  //     })
  //   );
  // }

  createTodo(todo: Partial<Todo>) {
    this.todoService.createTodo(todo).subscribe({
      next: (res) => console.log('Success', res),
      error: (err) => console.error('Error', err)
    });  
  }

  updateTodo(todo: Partial<Todo>) {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) this.todoService.updateTodo(id, todo).subscribe();
  }
}
