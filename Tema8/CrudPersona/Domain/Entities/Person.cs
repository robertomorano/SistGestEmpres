using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person
    {
        public int ID;
        public string name;
        public int age;
        public string surname;
        public string direccion;
        public DateTime fechaNac;
        public int _departamento;
        public string telefono;

        public Person()
        {

        }
        public Person(string name, int age, string surname, int departamento)
        {
            this.name = name;
            this.age = age;
            this.surname = surname;
            this._departamento = departamento;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public string Surname
        {
            get { return this.surname; }
            set { this.surname = value; }
        }
        public int Departamento
        {
            get { return this._departamento; }
            set { this._departamento = value; }
        }
    }
}
