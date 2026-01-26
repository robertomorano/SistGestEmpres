export class Persona {
  id: number;
  name: string;
  surname: string;
  departamento: number;

  constructor(id: number, nombre: string, apellidos: string, idDpto: number) {
    this.id = id;
    this.name = nombre;
    this.surname = apellidos;
    this.departamento = idDpto;
  }

  toString(): string {
    return `Persona { id: ${this.id}, nombre: '${this.name}', apellidos: '${this.surname}' }`;
  }
}
