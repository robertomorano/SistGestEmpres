export class Persona {
  id: number;
  nombre: string;
  apellidos: string;

  constructor(id: number, nombre: string, apellidos: string) {
    this.id = id;
    this.nombre = nombre;
    this.apellidos = apellidos;
  }

  toString(): string {
    return `Persona { id: ${this.id}, nombre: '${this.nombre}', apellidos: '${this.apellidos}' }`;
  }
}
