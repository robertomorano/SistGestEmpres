import { Routes } from '@angular/router';
import { PersonListComponent } from '../Presentation/Components/PersonListComponent';

export const routes: Routes = [
  { path: '', component: PersonListComponent },
  { path: '**', redirectTo: '' }
];
