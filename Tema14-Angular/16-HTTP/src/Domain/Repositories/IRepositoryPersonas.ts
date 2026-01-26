import { Persona } from "../Entities/Persona";

export interface IRepositoryPersonas {
    getListadoCompletoPersonas(): Persona[];

    insertPersona(persona :Persona): number;
    deletePersona(id : number ): number;
    updatePersona(persona:Persona, id:number):number;
}