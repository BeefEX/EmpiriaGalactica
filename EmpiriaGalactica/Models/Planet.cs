using System.Collections.Generic;

namespace EmpiriaGalactica.Models {
    
    /// <summary>
    /// An planet instance.
    /// </summary>
    public class Planet : IModel {
        
        /// <summary>
        /// Types of planets.
        /// </summary>
        public enum PlanetBiome {
            Humid,
            Hot,
            Cold
        }
        
        /// <summary>
        /// The name of this planet.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The radius of the planet.
        /// </summary>
        public int Radius { get; set; }
        
        /// <summary>
        /// The type of the planet.
        /// </summary>
        public PlanetBiome Biome { get; set; }
        
        /// <summary>
        /// The population of the planet.
        /// </summary>
        public int Pupulation { get; set; }
        
        /// <summary>
        /// The owner of this planet.
        /// </summary>
        public Empire Owner { get; set; }
        
        /// <summary>
        /// The buildings on this planet.
        /// </summary>
        public List<Building> Buildings { get; set; }
    }
}