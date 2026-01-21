import { Persona } from "../Entities/Persona";

export interface IGetPersonasUseCase {
    execute(): Persona[];
}