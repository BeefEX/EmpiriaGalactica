namespace EmpiriaGalactica.Models {
    
    public class Resource : IModel, IInternalName {
        
        /// <summary>
        /// The name of this resource.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The internal name used by the game.
        /// </summary>
        public string InternalName { get; set; }
        
        /// <summary>
        /// The base cost of this resource on the market.
        /// </summary>
        public int BaseCost { get; set; }
    }
}