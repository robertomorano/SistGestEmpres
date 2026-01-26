import { Component, OnInit, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonListViewModel } from '../ViewModels/PersonListViewModel';
import { PersonDepartmentNameDto } from '../../Domain/dto/PersonDpartmentNameDto';

@Component({
  selector: 'app-person-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {
  readonly viewModel: PersonListViewModel;
  readonly displayPeople;
  readonly isLoading;
  readonly error;

  constructor(private personListViewModel: PersonListViewModel) {
    this.viewModel = personListViewModel;
    this.displayPeople = computed(() => this.viewModel.people());
    this.isLoading = computed(() => this.viewModel.isLoading());
    this.error = computed(() => this.viewModel.error());
  }

  ngOnInit(): void {
    this.loadPeople();
  }

  async loadPeople(): Promise<void> {
    await this.viewModel.loadPeople();
  }

  async refreshPeople(): Promise<void> {
    await this.viewModel.refreshPeople();
  }

  trackByPersonId(index: number, person: PersonDepartmentNameDto): number {
    return 0;
  }
}