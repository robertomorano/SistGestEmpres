import {FormGroup, FormControl, ReactiveFormsModule} from '@angular/forms';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-formulario',
  imports: [ReactiveFormsModule],
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