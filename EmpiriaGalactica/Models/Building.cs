using System;
using System.Collections.Generic;

namespace EmpiriaGalactica.Models {
    public class Building : IModel, IInternalName {
        
        /// <summary>
        /// The name of this building.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Name used internally by the game.
        /// </summary>
        public string InternalName { get; set; }
        
        /// <summary>
        /// The base cost of this building.
        /// </summary>
        public List<ResourceInstance> BaseCost { get; set; }
        
        /*
        // Unused for now
        
        /// <summary>
        /// The amount of energy required by this building each update.
        /// </summary>
        public int EnergyRequiredPerUpdate { get; set; }
        
        /// <summary>
        /// The amount of energy supplied by this building each update.
        /// </summary>
        public int EnergySuppliedPerUpdate { get; set; }
        */
        
        /// <summary>
        /// Used to update the building and apply it's effects.
        /// </summary>
        public Action<Planet, BuildingInstance> Update { get; set; }
    }
}