import { injectable } from "inversify";
import { Persona } from "../../Domain/Entities/Persona"
import { IRepositoryPersonas } from "../../Domain/Repositories/IRepositoryPersonas";





@injectable()
export class PersonasRepository implements IRepositoryPersonas{

    _personas = [
            new Persona(1, 'Fernando', 'Galiana Fernández')
        ];
    _nextId:number = 0;
    insertPersona(persona: Persona): number {
        persona.id = this._nextId++;
        this._personas.push(persona);
        
        return persona.id;
    }
    deletePersona(id: number): number {
        const index = this._personas.findIndex(p => p.id === id);

        if (index !== -1) {
            this._personas.splice(index, 1);
        }
        return index
    }
    updatePersona(persona: Persona, id: number): number {
        const index = this._personas.findIndex(p => p.id === id);

        if (index !== -1) {
        
            this._personas[index].nombre = persona.nombre;
            this._personas[index].apellidos = persona.apellidos;
             
        }

        
        return index;
  
    }


    getListadoCompletoPersonas(): Persona[] {


        //En un futuro, esto podría hacer llamadas a una API que nos ofreciera los datos
        return this._personas
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