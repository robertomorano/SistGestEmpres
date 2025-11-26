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
    public class CRUDPersonaUseCase : ICRUDPeopleUseCase
    {
        private readonly ICRUDPeopleRepository _repository;

        public CRUDPersonaUseCase(ICRUDPeopleRepository PeopleListInterface)
        {
            _repository = PeopleListInterface;
        }
            
        public Person[] GetPeopleList()
        {
            return _repository.GetPeopleList();
        }


        public int InsertPeople(Person person)
        {
            throw new NotImplementedException();
        }

        public int UpdatePeople(Person person)
        {
            throw new NotImplementedException();
        }

        public int DeletePeople(Person person)
        {
            throw new NotImplementedException();
        }

        public int 
    }   
}
