import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { 
    path: '', 
    redirectTo: 'todos', 
    pathMatch: 'full' 
  },
  { 
    path: 'todos',
    loadChildren: () => import('./features/todos/todos.module')
      .then(m => m.TodosModule)
  },
  { 
    path: '**', 
    redirectTo: 'todos',
    pathMatch: 'full' 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
