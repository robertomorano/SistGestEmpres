using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Departamento
    {
        private int _id;
        private string _name;

        public Departamento()
        {
        }

        public Departamento(int id, string name)
        {
            this._id = id;
            this._name = name;
        }
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }
}
