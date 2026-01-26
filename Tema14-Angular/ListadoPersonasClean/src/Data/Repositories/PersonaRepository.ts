import { inject, injectable } from "inversify";
import { Persona } from "../../Domain/Entities/Persona"
import { IRepositoryPersonas } from "../../Domain/Repositories/IRepositoryPersonas";
import { TYPES } from "../../Core/types";
import APIAzure from "../Connection/ApisCalling";





@injectable()
export class PersonasRepository implements IRepositoryPersonas{

   constructor(
    @inject(TYPES.Connection) private connection: APIAzure
  ) {}
    

  async getPerson(id: number): Promise<Persona> {
    try {
      const baseUrl = this.connection.getConnection();
      const response = await fetch(`${baseUrl}/api/Personas/${id}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.json();
      
      // Asumiendo que la API devuelve un objeto similar a getPeople
      const personData = data.persona || data;
      
      return new Persona(
        personData.id,
        personData.name,
        personData.surname,
        personData.departamento
      );
    } catch (error) {
      console.error('Error en PersonRepo.getPerson:', error);
      throw new Error(`No se pudo obtener la persona con id ${id}`);
    }
  }

  async getPersonDepartment(id: number): Promise<string> {
    try {
      const baseUrl = this.connection.getConnection();
      const response = await fetch(`${baseUrl}/api/PersonasDepartamentoList/${id}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.json();

      // Extraer el nombre del departamento
      const departmentName = data.departamento?.name || data.nombreDepartamento;

      if (!departmentName) {
        throw new Error('No se encontró el nombre del departamento');
      }

      return departmentName;
    } catch (error) {
      console.error('Error en PersonRepo.getPersonDepartment:', error);
      throw new Error(`No se pudo obtener el departamento de la persona con id ${id}`);
    }
  }

  async putPerson(person: Persona): Promise<number> {
    try {
      const baseUrl = this.connection.getConnection();
      const response = await fetch(`${baseUrl}/api/Personas/${person.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          id: person.id,
          name: person.name,
          surname: person.surname,
          departamento: person.departamento,
        }),
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      // Retornar el status code o el id de la persona actualizada
      return response.status;
    } catch (error) {
      console.error('Error en PersonRepo.putPerson:', error);
      throw new Error('No se pudo actualizar la persona');
    }
  }

  async deletePerson(id: number): Promise<number> {
    try {
      const baseUrl = this.connection.getConnection();
      const response = await fetch(`${baseUrl}/api/Personas/${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      // Retornar el status code
      return response.status;
    } catch (error) {
      console.error('Error en PersonRepo.deletePerson:', error);
      throw new Error(`No se pudo eliminar la persona con id ${id}`);
    }
  }

  async getPeople(): Promise<Persona[]> {
    try {
      const baseUrl = this.connection.getConnection();
      const response = await fetch(`${baseUrl}/api/Personas`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.json();
      const array: Persona[] = [];

      console.log(data);

      data.forEach((element: any) => {
        const personData = element.persona || element;
        array.push(
          new Persona(
            personData.id,
            personData.name,
            personData.surname,
            personData.departamento
          )
        );
      });

      console.log(array);

      return array;
    } catch (error) {
      console.error('Error en PersonRepo.getPeople:', error);
      throw new Error('No se pudieron obtener las personas');
    }
  }
}

/*
@injectable()
export class PersonasRepositoryEmpty implements IRepositoryPersonas{
    insertPersona(persona: Persona): number {
        throw new Error("Method not implemented.");
    }
    deletePersona(id: number): number {
        throw new Error("Method not implemented.");
    }
    updatePersona(persona: Persona, id: number): number {
        throw new Error("Method not implemented.");
    }


    getListadoCompletoPersonas(): Persona[] {


        //En un futuro, esto podría hacer llamadas a una API que nos ofreciera los datos
        return [        ];
    }
}

@injectable()
export class    PersonasRepository100 implements IRepositoryPersonas{
    insertPersona(persona: Persona): number {
        throw new Error("Method not implemented.");
    }
    deletePersona(id: number): number {
        throw new Error("Method not implemented.");
    }
    updatePersona(persona: Persona, id: number): number {
        throw new Error("Method not implemented.");
    }


    getListadoCompletoPersonas(): Persona[] {


        //En un futuro, esto podría hacer llamadas a una API que nos ofreciera los datos
        return [ new Persona(1, 'Fernando', 'Galiana Fernández'),
new Persona(2, 'Carlos', 'Martínez López'),
new Persona(3, 'Ana', 'Rodríguez Pérez'),
new Persona(4, 'Miguel', 'Sánchez Ruiz'),
new Persona(5, 'Laura', 'Torres Díaz'),
new Persona(6, 'David', 'Moreno García'),
new Persona(7, 'Isabel', 'Hernández Castro'),
new Persona(8, 'Javier', 'López Gómez'),
new Persona(9, 'María', 'Fernández Sánchez'),
new Persona(10, 'Luis', 'Gómez Herrera'),
new Persona(11, 'Sofía', 'Navarro Jiménez'),
new Persona(12, 'Pablo', 'Vargas Ortega'),
new Persona(13, 'Elena', 'Ramírez Romero'),
new Persona(14, 'Alberto', 'Domínguez León'),
new Persona(15, 'Lucía', 'Cabrera Soto'),
new Persona(16, 'Manuel', 'Iglesias Márquez'),
new Persona(17, 'Patricia', 'Reyes Delgado'),
new Persona(18, 'Raúl', 'Cortés Peña'),
new Persona(19, 'Claudia', 'Flores Gil'),
new Persona(20, 'Andrés', 'Cano Rubio'),
new Persona(21, 'Carmen', 'Ortega Morales'),
new Persona(22, 'Sergio', 'Ramos Rivas'),
new Persona(23, 'Natalia', 'Suárez Méndez'),
new Persona(24, 'Francisco', 'Luna Molina'),
new Persona(25, 'Alicia', 'Guerrero Lozano'),
new Persona(26, 'Iván', 'Castillo Marín'),
new Persona(27, 'Beatriz', 'Vega Pardo'),
new Persona(28, 'Diego', 'Gil Salazar'),
new Persona(29, 'Marta', 'Campos Vera'),
new Persona(30, 'Óscar', 'Herrera Fuentes'),
new Persona(31, 'Teresa', 'Santos Vidal'),
new Persona(32, 'Adrián', 'Medina Bravo'),
new Persona(33, 'Nuria', 'Arias Valverde'),
new Persona(34, 'Rubén', 'Lorenzo Alcántara'),
new Persona(35, 'Eva', 'Nieto Esteban'),
new Persona(36, 'Tomás', 'Carretero Aguado'),
new Persona(37, 'Paula', 'Gallardo Montes'),
new Persona(38, 'Mario', 'Benítez Cordero'),
new Persona(39, 'Silvia', 'Ríos Camacho'),
new Persona(40, 'Álvaro', 'Palacios Figueroa'),
new Persona(41, 'Lorena', 'Montes Linares'),
new Persona(42, 'Eduardo', 'Soler Barrios'),
new Persona(43, 'Sandra', 'Esteban Castaño'),
new Persona(44, 'Gabriel', 'Muñoz Rosado'),
new Persona(45, 'Irene', 'Lara Segura'),
new Persona(46, 'Cristian', 'Delgado Bustos'),
new Persona(47, 'Rocío', 'Carrillo Pascual'),
new Persona(48, 'Víctor', 'Ferrero Sanz'),
new Persona(49, 'Noelia', 'León Pastor'),
new Persona(50, 'Alejandro', 'Pérez Gallardo'),
new Persona(51, 'Verónica', 'Reina Aguilera'),
new Persona(52, 'Jorge', 'Blanco Cardona'),
new Persona(53, 'Inés', 'Castañeda Aranda'),
new Persona(54, 'Mateo', 'Franco Barea'),
new Persona(55, 'Sara', 'Navas Rico'),
new Persona(56, 'Hugo', 'Sáez Zamora'),
new Persona(57, 'Cristina', 'Campos Laguna'),
new Persona(58, 'Enrique', 'Mendoza Parrado'),
new Persona(59, 'Raquel', 'Romero Tapia'),
new Persona(60, 'Lucas', 'Bueno Olivares'),
new Persona(61, 'Blanca', 'Salas Moya'),
new Persona(62, 'Antonio', 'Robles Tejada'),
new Persona(63, 'Julia', 'Valle Caro'),
new Persona(64, 'Ángel', 'Andrade Méndez'),
new Persona(65, 'Mónica', 'Escribano Téllez'),
new Persona(66, 'Gonzalo', 'Villegas Montero'),
new Persona(67, 'Helena', 'Cuevas Sevilla'),
new Persona(68, 'Iván', 'Alarcón Baena'),
new Persona(69, 'Esther', 'Barragán Jurado'),
new Persona(70, 'Samuel', 'Collado Marchena'),
new Persona(71, 'Rebeca', 'Miranda Gracia'),
new Persona(72, 'Guillermo', 'Padilla Llamas'),
new Persona(73, 'Nerea', 'Pozo Alcázar'),
new Persona(74, 'Ernesto', 'Silva Carrión'),
new Persona(75, 'Clara', 'Mateos Arellano'),
new Persona(76, 'Jaime', 'Rosales Ibáñez'),
new Persona(77, 'Daniela', 'Cordero Gallego'),
new Persona(78, 'Martín', 'Rueda Carmona'),
new Persona(79, 'Ainhoa', 'Escobar Zambrano'),
new Persona(80, 'Félix', 'Gallego Ordóñez'),
new Persona(81, 'Bárbara', 'Quesada Román'),
new Persona(82, 'Héctor', 'Serrano Murillo'),
new Persona(83, 'Laia', 'Toledo Reina'),
new Persona(84, 'Marcos', 'Salvador Castañón'),
new Persona(85, 'Andrea', 'Santiago Hervás'),
new Persona(86, 'Joel', 'Pacheco Bermúdez'),
new Persona(87, 'Valeria', 'Lago Bermúdez'),
new Persona(88, 'Álex', 'Medrano Cantero'),
new Persona(89, 'Lidia', 'Ramos Soria'),
new Persona(90, 'Bruno', 'Pastor Arjona'),
new Persona(91, 'Celia', 'Nicolás Arcos'),
new Persona(92, 'Sebastián', 'Román Alarcón'),
new Persona(93, 'Ariadna', 'Peña Carrillo'),
new Persona(94, 'Ignacio', 'Garrido Alvear'),
new Persona(95, 'Jimena', 'Crespo Menéndez'),
new Persona(96, 'Rodrigo', 'Aguirre Girón'),
new Persona(97, 'Triana', 'Martel Pavón'),
new Persona(98, 'Marc', 'Tejada Parejo'),
new Persona(99, 'Amaia', 'Del Río Amador'),
new Persona(100, 'Nicolás', 'Sancho Villar'),
       ];
    }
}

export { IRepositoryPersonas };
*/