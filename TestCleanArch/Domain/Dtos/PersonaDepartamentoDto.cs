using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    
    public class PersonaDepartamentoDto
    {
        public Person Persona { get; set; }
        public string DepartamentoNombre { get; set; }

        public PersonaDepartamentoDto(Person persona, Departamento departamento)
        {
            Persona = persona;
            DepartamentoNombre = departamento.Name;
        }
        public PersonaDepartamentoDto()
        {

        }
    }
}

