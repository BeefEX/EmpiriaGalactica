using System.Collections.Generic;

namespace EmpiriaGalactica.Models {
    
    /// <summary>
    /// A model representing an star system.
    /// </summary>
    public class StarSystem : IModel {
        
        /// <summary>
        /// The name of this star system.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The position of this star system.
        /// </summary>
        public Vector Position { get; set; }

        /// <summary>
        /// The planets of this star system.
        /// </summary>
        public List<Planet> Planets { get; set; }
    }
}