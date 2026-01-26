import { PersonDepartmentNameDto } from "../dto/PersonDpartmentNameDto";
import { Persona } from "../Entities/Persona";

export interface IGetPersonasUseCase {
    getPeople(): Promise<PersonDepartmentNameDto[]>;
}