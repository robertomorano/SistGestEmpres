import { Routes } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { Formulario } from './components/formulario/formulario';

export const routes: Routes = [
    {path: "tabla", component: TablaPersonas},
    {path: "formulario", component: Formulario}
];
