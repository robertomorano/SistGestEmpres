import { TYPES } from "../../Core/types";
import { Persona } from "../Entities/Persona";
import { IGetPersonasUseCase } from "../Interfaces/IGetPersonasUseCase";
import { IRepositoryPersonas } from "../Repositories/IRepositoryPersonas";
import { inject } from "inversify";

export class GetPersonasUseCase implements IGetPersonasUseCase{

    _list: Persona[] = []
    constructor(
        @inject(TYPES.IRepositoryPersonas)
        private RepositoryPersonas: IRepositoryPersonas
    ) {
        this._list=this.RepositoryPersonas.getListadoCompletoPersonas();
    }

    execute(): Persona[]{
        return this._list;
    }
}