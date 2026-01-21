import { Container } from "inversify";
import "reflect-metadata";
import { PersonasRepository} from "../Data/Repositories/PersonaRepository";
import {IRepositoryPersonas} from "@/app/Domain/Repositories/IRepositoryPersonas"
import { PeopleListVM } from "../UI/ViewModels/PeopleListVM";
import { TYPES } from "./types";
import { IGetPersonasUseCase } from "../Domain/Interfaces/IGetPersonasUseCase";
import { GetPersonasUseCase } from "../Domain/UseCase/GetPersonasUseCase";


const container = new Container();


// Vinculamos la interfaz con su implementación concreta
container.bind<IRepositoryPersonas>(TYPES.IRepositoryPersonas).to(PersonasRepository);
container.bind<IGetPersonasUseCase>(TYPES.IGetPersonaUseCase).to(GetPersonasUseCase);
container.bind<PeopleListVM>(TYPES.IndexVM).to(PeopleListVM);
export { container };
