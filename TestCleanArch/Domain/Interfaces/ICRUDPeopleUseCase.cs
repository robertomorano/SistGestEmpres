
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Interfaces
{
    public interface ICRUDPeopleUseCase
    {
        List<Person> GetPeople();
        List<PersonaDepartamentoDto> GetPeopleList();
        Person GetPersonById(int id);
        PersonaDepartamentoDto GetPersonDepById(int id);
        PersonaDepartamentoListDto GetPersonaWithDepartamentos(int id);
        int CreatePerson(Person person);
        int UpdatePerson(Person person);
        int DeletePerson(int person);
    }
}
