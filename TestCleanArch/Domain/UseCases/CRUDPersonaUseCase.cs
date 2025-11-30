using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class CRUDPersonaUseCase : ICRUDPeopleUseCase
    {
        private readonly ICRUDPeopleRepository _personaRepo;
        private readonly ICRUDDepartamentoRepository _departamentoRepo;

        public CRUDPersonaUseCase(ICRUDPeopleRepository personaRepo, ICRUDDepartamentoRepository departamentoRepo)
        {
            _personaRepo = personaRepo;
            _departamentoRepo = departamentoRepo;
        }

        public List<PersonaDepartamentoDto> GetPeopleList()
        {
            List<PersonaDepartamentoDto> listaPersonasDepartamento = new List<PersonaDepartamentoDto>();
            List<Person> listaPersonas = _personaRepo.GetPeopleList();

            foreach (Person persona in listaPersonas)
            {
                PersonaDepartamentoDto personaDto = new PersonaDepartamentoDto();
                personaDto.Persona = persona;

                Departamento departamento = _departamentoRepo.GetDepartamentoById(persona.Departamento);
                if (departamento != null)
                {
                    personaDto.DepartamentoNombre = departamento.Name;
                }
                else
                {
                    personaDto.DepartamentoNombre = "Sin departamento";
                }

                listaPersonasDepartamento.Add(personaDto);
            }

            return listaPersonasDepartamento;
        }

        public Person GetPersonById(int id)
        {
            return _personaRepo.GetPersonById(id);
        }

        public PersonaDepartamentoListDto GetPersonaWithDepartamentos(int id)
        {
            PersonaDepartamentoListDto personaConDepartamentos = new PersonaDepartamentoListDto();

            Person persona = _personaRepo.GetPersonById(id);
            if (persona != null)
            {
                personaConDepartamentos.Persona = persona;
                personaConDepartamentos.Departamentos = _departamentoRepo.GetDepartamentos();
            }

            return personaConDepartamentos;
        }

        public int CreatePerson(Person persona)
        {
            return _personaRepo.CreatePerson(persona);
        }

        public int DeletePerson(int id)
        {
            return _personaRepo.DeletePerson(id);
        }

        public int UpdatePerson(Person persona)
        {
            return _personaRepo.UpdatePerson(persona);
        }


    }   
}
