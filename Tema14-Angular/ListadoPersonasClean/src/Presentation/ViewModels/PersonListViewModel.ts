import { Injectable, signal } from '@angular/core';
import { PersonDepartmentNameDto } from '../../Domain/dto/PersonDpartmentNameDto';
import { IGetPersonasUseCase } from '../../Domain/Interfaces/IGetPersonasUseCase';
import { inject } from 'inversify';
import { TYPES } from '../../Core/types';
import { container } from '../../Core/container';

@Injectable({
  providedIn: 'root'
})
export class PersonListViewModel {
  private readonly getPersonasUseCase: IGetPersonasUseCase;

  readonly people = signal<PersonDepartmentNameDto[]>([]);
  readonly isLoading = signal<boolean>(false);
  readonly error = signal<string | null>(null);

  constructor() {
    this.getPersonasUseCase = container.get<IGetPersonasUseCase>(TYPES.IGetPersonaUseCase);
  }

  async loadPeople(): Promise<void> {
    this.isLoading.set(true);
    this.error.set(null);

    try {
      const peopleData = await this.getPersonasUseCase.getPeople();
      this.people.set(peopleData);
    } catch (err) {
      this.error.set(err instanceof Error ? err.message : 'Failed to load people');
      console.error('Error loading people:', err);
    } finally {
      this.isLoading.set(false);
    }
  }

  async refreshPeople(): Promise<void> {
    await this.loadPeople();
  }
}