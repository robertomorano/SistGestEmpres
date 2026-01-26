import { Container } from "inversify";
import "reflect-metadata";
import { PersonasRepository} from "../Data/Repositories/PersonaRepository";
import { IRepositoryPersonas } from "../Domain/Repositories/IRepositoryPersonas";

import { TYPES } from "./types";
import { IGetPersonasUseCase } from "../Domain/Interfaces/IGetPersonasUseCase";
import { GetPersonasUseCase } from "../Domain/UseCase/GetPersonasUseCase";
import APIAzure from "../Data/Connection/ApisCalling";


const container = new Container();

container.bind(TYPES.Connection).to(APIAzure).inSingletonScope();
// Vinculamos la interfaz con su implementación concreta
container.bind<IRepositoryPersonas>(TYPES.IRepositoryPersonas).to(PersonasRepository);
container.bind<IGetPersonasUseCase>(TYPES.IGetPersonaUseCase).to(GetPersonasUseCase);
//container.bind<PeopleListVM>(TYPES.IndexVM).to(PeopleListVM);
export { container };
