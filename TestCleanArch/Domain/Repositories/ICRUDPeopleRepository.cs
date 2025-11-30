using Domain.Dtos;
using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICRUDPeopleRepository
    {
        List<Person> GetPeopleList();
        Person GetPersonById(int id);
        int CreatePerson(Person persona);
        int DeletePerson(int id);
        int UpdatePerson(Person persona);
    }
}
