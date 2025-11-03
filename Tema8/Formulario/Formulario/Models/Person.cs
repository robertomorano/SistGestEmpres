using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Models
{
    public class Person
    {
        private string name;
        private int age;
        private string surname;
        private int _departamento;

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
