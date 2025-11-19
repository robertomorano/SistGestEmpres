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
    public class PersonaCRUDUseCase : ICRUDUseCase
    {
        private readonly IGetPeopleListRepository _repository;

        public PersonaCRUDUseCase(IGetPeopleListRepository getPeopleList)
        {
            _repository = getPeopleList;
        }
            
        public Person[] GetPeopleList()
        {
            return _repository.GetPeopleList();
        }
    }   
}
