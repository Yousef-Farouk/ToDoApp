import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TodoListPageComponent } from './pages/todo-list-page/todo-list-page.component';
import { TodoDetailsPageComponent } from './pages/todo-details-page/todo-details-page.component';
import { TodoFormComponent } from './components/todo-form/todo-form.component';

const routes: Routes = [
    { 
        path: '', 
        component: TodoListPageComponent 
      },
      {
        path: 'new',
        component: TodoDetailsPageComponent,
        children: [{ path: '', component: TodoFormComponent, data: { mode: 'create' }}]
      }
      ,
      {
        path: ':id',
        component: TodoDetailsPageComponent,
        children: [
          { 
            path: 'edit', 
            component: TodoFormComponent,
            data: { mode: 'edit' }
          }
        ]
      }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TodosRoutingModule { }