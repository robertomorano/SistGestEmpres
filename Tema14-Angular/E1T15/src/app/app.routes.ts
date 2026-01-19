import { Routes } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { Formulario } from './components/formulario/formulario';

export const routes: Routes = [
    {path: "", component: TablaPersonas},
    {path: "formulario", component: Formulario},
    
];
