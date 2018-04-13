using System.Collections.Generic;
using EmpiriaGalactica.Managers;

namespace EmpiriaGalactica.Models {
    public class Empire : IModel {
        
        public string Name { get; set; }

        public List<Planet> Planets { get; set; }
        
        public ResourceManager Resources { get; set; }
    }
}