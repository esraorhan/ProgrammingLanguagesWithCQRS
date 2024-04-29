using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class ProgrammingLanguage :Entity
    {
        public string Name { get; set; }
        public string Version { get; set; }

        public DateTime CreatedTime { get; set; }
        public ProgrammingLanguage() 
        {
        }

        public ProgrammingLanguage(int id,string name, string version, DateTime createdTime) : this()
        {
            Id = id;
            Name = name;
            Version = version;
            CreatedTime = createdTime;
        }      
    }
}
