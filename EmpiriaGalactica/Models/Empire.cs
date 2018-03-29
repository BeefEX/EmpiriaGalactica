using System.Collections.Generic;

namespace EmpiriaGalactica.Models {
    public class Empire : IModel {
        
        public string Name { get; set; }

        public List<Planet> Planets { get; set; }
        
        public Dictionary<string, ResourceInstance> Resources { get; set; }
    }
}