import { Persona } from '../Entities/Persona';

export class PersonDepartmentNameDto {
  public persona: Persona;
  public departamento: string;
  
  constructor(persona: Persona, departamento: string) {
    this.persona = persona;
    this.departamento = departamento;
  }
}