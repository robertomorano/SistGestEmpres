import { Component, OnInit} from '@angular/core';

import { Persona } from '../../../Domain/Entities/Persona';

import { PersonasService } from '../../../services/FromTheCallingOfMyApi';
import { CommonModule } from '@angular/common';

@Component({

selector: 'app-tabla-api',

imports : [CommonModule],

templateUrl: './lista-persona.html',

styleUrls: ['./lista-persona.css']

})

export class TablaAPIComponent implements OnInit {

listadoPersonas:Persona[] = [];

constructor(private personasServicio: PersonasService) { }

ngOnInit(): void {

this.obtenerPersonas();

}

obtenerPersonas(): void {

this.personasServicio.getPersonas().subscribe({

  next:(response) =>{

  this.listadoPersonas=response;

  },

  error: (error)=>{

    alert("Ha ocurrido un error al obtener los datos del servidor");

  }

});

}

}
