import { Persona } from "../Entities/Persona";

export interface ICreatePersonasUseCase {
    execute(persona: Persona): number;
}