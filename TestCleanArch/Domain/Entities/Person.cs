using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Person
    {
        public int ID;
        [Display(Name = "Nombre")]
        public string name;
        
        
        public int age;

        [MaxLength(60),Required]
        public string surname;
        public string direccion;
        public DateTime fechaNac;
        public int _departamento;
        public string telefono;
        public string foto;

        public Person()
        {

        }
        public Person(string name, int age, string surname, int departamento, string direccion, string telefono, DateTime fechaNac)
        {
            this.name = name;
            this.age = age;
            this.surname = surname;
            this._departamento = departamento;
        }
        public int Id
        {
            get { return this.ID; }
            set { this.ID = value; }
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
        public string Foto
        { 
            get { return this.foto; }
            set { this.foto = value; }
        }
        public int Departamento
        {
            get { return this._departamento; }
            set { this._departamento = value; }
        }
    }
}
