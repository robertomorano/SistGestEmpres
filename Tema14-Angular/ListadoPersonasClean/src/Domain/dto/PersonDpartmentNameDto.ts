import { Persona } from "../Entities/Persona";
import { Department } from "../Entities/Department";

export class PersonDepartmentNameDto {
  public persona: Persona | undefined;
  public departamento: string | undefined;
  
  constructor(persona: Persona, departamento: string) {
    this.persona = persona;
    this.departamento = departamento;
  }
}