using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class CRUDUseCase : IGetPeopleListUseCase
    {
        private readonly IGetPeopleListRepository _repository;

        public CRUDUseCase(IGetPeopleListRepository PeopleListInterface)
        {
            _repository = PeopleListInterface;
        }
            
        public Person[] GetPeopleList()
        {
            return _repository.GetPeopleList();
        }
    }   
}
