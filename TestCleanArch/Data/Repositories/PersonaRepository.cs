using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PersonaRepository : IGetPeopleListRepository
    {
        Person[] people;
        public PersonaRepository()
        {
            people = [];
            Array.Resize(ref people, 7);
            people[0] = new Person("Juan", 23, "adwsa", 1);
            people[1] = new Person("Maria", 30, "asdasd", 2);
            people[2] = new Person("Pedro", 45, "qweqwe", 3);
            people[3] = new Person("Luisa", 28, "zxcvzx", 4);
            people[4] = new Person("Carlos", 35, "rtyrty", 5);
            people[4] = new Person("Carlos", 35, "rtyrty", 5);
            people[5] = new Person("Carlos", 35, "rtyrty", 5);
            people[6] = new Person("Carlos", 35, "rtyrty", 5);

        }
        

        public Person[] GetPeopleList()
        {
            return [
  new Person("Carlos", 35, "rtyrty", 5),
  new Person("María", 28, "asdfgh", 3),
  new Person("Luis", 42, "qweqwe", 7),
  new Person("Ana", 31, "zxcvbn", 4),
  new Person("Pedro", 26, "hjkhjk", 2),
  new Person("Lucía", 39, "tyutyu", 6),
  new Person("Javier", 33, "cvbcvb", 5),
  new Person("Sofía", 29, "bnmbnm", 4),
  new Person("Miguel", 45, "ghfghf", 8),
  new Person("Elena", 37, "plmplm", 5)
];
        }
    }
}
