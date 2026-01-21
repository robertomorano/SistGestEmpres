import {FormGroup, FormControl, ReactiveFormsModule} from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field'; 
import { MatCardModule } from '@angular/material/card'; 
import { MatInputModule } from '@angular/material/input';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-formulario',
  imports: [ReactiveFormsModule, MatFormFieldModule, MatCardModule, MatInputModule],
  templateUrl: './formulario.html',
  styleUrl: './formulario.css',
})



export class Formulario implements OnInit {

  formulario: FormGroup;

  constructor() {
    
  }

  ngOnInit(): void {

    this.formulario=new FormGroup(

      {

        nombre: new FormControl('',[]),

        apellidos:new FormControl('',[])

      }

    );

  }

  saluda(){

    if (this.formulario.valid){

      alert('Hola ' + this.formulario.controls['nombre'].value + ' ' + this.formulario.controls['apellidos'].value);

    }
  }
}