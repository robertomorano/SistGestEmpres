using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PersonaDepartamentoListDto
    {
        public Person Persona { get; set; }
        public List<Departamento> Departamentos { get; set; }

        public PersonaDepartamentoListDto()
        {
            Departamentos = new List<Departamento>();
        }
    }
}
