using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICRUDDepartamentoRepository
    {
        List<Departamento> GetDepartamentos();
        Departamento GetDepartamentoById(int id);
        int CreateDepartamento(Departamento departamento);
        int DeleteDepartamento(int id);
        int UpdateDepartamento(Departamento departamento);
        int CheckPersonasInDepartamento(int idDepartamento);
    }
}
