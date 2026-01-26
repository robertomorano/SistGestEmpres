import { Persona } from "../Entities/Persona";

export interface IRepositoryPersonas {
    getPersonDepartment(id:number): Promise<string>;
  getPerson(id: number): Promise<Persona>;
  getPeople(): Promise<Persona[]>;
  deletePerson(id: number):Promise<number>;
  putPerson(person : Persona):Promise<number>;
}