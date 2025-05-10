import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Todo } from './../../../../core/models/todo.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-todo-form',
  templateUrl: './todo-form.component.html',
  styleUrls: ['./todo-form.component.scss']
})
export class TodoFormComponent implements OnInit {
  @Input() todo?: Todo | undefined | null;
  @Output() submitForm = new EventEmitter<Partial<Todo>>();

  todoForm: FormGroup;
  isEditMode = false;

  statusOptions = ['Pending', 'InProgress', 'Completed'];
  priorityOptions = ['Low', 'Medium', 'High'];

  constructor(private fb: FormBuilder,private route: ActivatedRoute) {
    this.isEditMode = this.route.snapshot.data['mode'] === 'edit';
    this.todoForm = this.fb.group({
      title: ['', Validators.required],
      description: [''],
      status: ['Pending', Validators.required],
      priority: ['Medium', Validators.required],
      dueDate: [null]
    });
  }

  ngOnInit(): void {
    if (this.todo) {
      this.todoForm.patchValue(this.todo);
    }
  }

  onSubmit(): void {
    if (this.todoForm.valid) {
    }
    console.log("emitted")
    this.submitForm.emit(this.todoForm.value);
  }
}