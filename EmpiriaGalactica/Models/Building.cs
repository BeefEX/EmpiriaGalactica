using System.Collections.Generic;

namespace EmpiriaGalactica.Models {
    public abstract class Building : IModel, IInternalName {
        
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
        
        /// <summary>
        /// Used to update the building and apply it's effects.
        /// </summary>
        /// <param name="planet">The planet this building is built on.</param>
        public abstract void Update(Planet planet);
    }
}