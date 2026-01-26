import { TYPES } from "../../Core/types";
import { PersonDepartmentNameDto } from "../dto/PersonDpartmentNameDto";
import { Persona } from "../Entities/Persona";
import { IGetPersonasUseCase } from "../Interfaces/IGetPersonasUseCase";
import { IRepositoryPersonas } from "../Repositories/IRepositoryPersonas";
import { inject } from "inversify";

export class GetPersonasUseCase implements IGetPersonasUseCase{

    
    constructor(
        @inject(TYPES.IRepositoryPersonas)
        private personRepo: IRepositoryPersonas
    ) {
        
    }
    

    async getPeople(): Promise<PersonDepartmentNameDto[]> {
    try {
      // Obtener todas las personas
      const people = await this.personRepo.getPeople();
      
      // Crear un array de promesas para obtener el departamento de cada persona
      const peopleWithDepartments = await Promise.all(
        people.map(async (person) => {
          try {
            const departmentName = await this.personRepo.getPersonDepartment(person.id);
            return new PersonDepartmentNameDto(person, departmentName);
          } catch (error) {
            console.error(`Error obteniendo departamento para persona ${person.id}:`, error);
            // Retornar con departamento vacío o "Desconocido" en caso de error
            return new PersonDepartmentNameDto(person, "Desconocido");
          }
        })
      );

      return peopleWithDepartments;
    } catch (error) {
      console.error("Error en PersonUseCase.getPeople:", error);
      throw new Error("No se pudieron obtener las personas con sus departamentos");
    }
  }
}