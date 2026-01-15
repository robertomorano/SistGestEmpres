import { Component, signal } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { Formulario } from './components/formulario/formulario';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TablaPersonas, Formulario, RouterLink, RouterLinkActive],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('EJ1');
}