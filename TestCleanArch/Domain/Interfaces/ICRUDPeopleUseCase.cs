
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICRUDPeopleUseCase
    {
        Person[] GetPeopleList();
        int InsertPeople(Person person);
        int UpdatePeople(Person person);
        int DeletePeople(Person person);
    }
}
